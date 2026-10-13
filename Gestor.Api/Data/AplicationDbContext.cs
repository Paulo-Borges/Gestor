using Microsoft.EntityFrameworkCore;

namespace Gestor.Api.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options) {}
    }
}
