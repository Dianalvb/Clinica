namespace Clinica.API.Data
{
    public class SeederDB
    {
        private readonly DataContext dataContext;
        public SeederDB(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
        }
    }
}
