using HappyFL.DB;

namespace HappyFL.DBFactory
{
    public class HappyFLDbContextFactory : DbContextFactory<HappyFLDbContext>
    {
        public override HappyFLDbContext CreateDbContext(params string[] args)
            => new HappyFLDbContext(optionsBuilder.Options);
    }
}
