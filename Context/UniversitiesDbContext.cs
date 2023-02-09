using Microsoft.EntityFrameworkCore;

namespace DOTNET5.Context
{
    public class UniversitiesDbContext : DbContext
    {
        public UniversitiesDbContext(DbContextOptions<UniversitiesDbContext> options) : base(options)
        {
        }

        public List<Universities> Universities { get; set; } = new List<Universities>();
    }
}
