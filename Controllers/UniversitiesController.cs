using DOTNET5.Context;
using Newtonsoft.Json;
namespace DOTNET5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversitiesController : ControllerBase
    {
        private readonly UniversitiesDbContext _context;

        public UniversitiesController(UniversitiesDbContext context)
        {
            _context = context;
        }

        private async Task<List<Universities>> GetUniversitiesList(string country)
        {
        // URL to fetch the list of universities
        var url = "https://github.com/Hipo/university-domains-list/blob/master/world_universities_and_domains.json";

        // Get the JSON data from the URL
        var data = await new HttpClient().GetStringAsync(url);

        try
        {
            // Deserialize the JSON data into a list of Universities objects
            var universities = JsonConvert.DeserializeObject<List<Universities>>(data);
            return universities?.Where(u => u.Country == country)?.ToList() ?? new List<Universities>();
        }
        catch (JsonException ex)
        {
            // Log the exception and return an empty list
            Console.WriteLine(ex.Message);
            return new List<Universities>();
        }
        }

        [HttpPost]
        public async Task<ActionResult<Universities>> PostUniversities(string country)
        {
        // Fetch the list of universities from the given URL
        var universities = await GetUniversitiesList(country);

        // Store the data in the database
        foreach (var university in universities)
        {
            
            
        // Check if the university already exists in the database
        var existingUniversity = _context.Universities.FirstOrDefault(u =>
            u.Country == university.Country &&
            u.UniName == university.UniName &&
            u.UniWebpage == university.UniWebpage);

            if (existingUniversity == null)
            {
                _context.Universities.Add(university);
            }
        }

            await _context.SaveChangesAsync();

            // Return the result in JSON format
            return CreatedAtAction("GetUniversities", new { id = universities.First().Id }, universities);
    }



        [HttpGet]
        [HttpPost]
        [Route("search")]
        public ActionResult<List<Universities>> SearchUniversities(string searchTerm)
        {
            if (_context.Universities == null)
            {
                return NotFound();
            }
            // Get all universities from the database
            var universities = _context.Universities.ToList();

            // Filter the universities that contain the search term in their name
            var filteredUniversities = universities.Where(u => u.UniName.Contains(searchTerm)).ToList();

            // Return the filtered list as a JSON response
            return Ok(filteredUniversities);
        }



    }
}