namespace WebApiDemo.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        public Task<List<SuperHero>> GetAllHeroesAsync();
        public Task<SuperHero?> GetHeroAsync(int id);
        public Task<List<SuperHero>> AddHeroAsync(SuperHero hero);
        public Task<List<SuperHero>?> UpdateHeroAsync(int id, SuperHero request);
        public Task<List<SuperHero>?> DeleteHeroAsync(int id);
    }
}
