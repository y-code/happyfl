using Microsoft.EntityFrameworkCore;
using HappyFL.DBFactory;

namespace HappyFL.DevDBSetup
{
    public interface IDataProvider<TDbContext> where TDbContext : DbContext
    {
        void CreateData<TFactory>(TFactory factory)
            
            where TFactory : DbContextFactory<TDbContext>;
    }
}
