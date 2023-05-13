namespace WebApiDemo.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext context;

        public SuperHeroService(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<SuperHero>> AddHeroAsync(SuperHero hero)
        {
            await context.AddAsync(hero);
            await context.SaveChangesAsync();

            return await context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHeroAsync(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            if (hero == null) { return null; }

            context.SuperHeroes.Remove(hero);
            await context.SaveChangesAsync();

            return await context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroesAsync()
        {
            var heroes = await context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetHeroAsync(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            if (hero == null) { return null; }
            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHeroAsync(int id, SuperHero request)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            if (hero == null) { return null; }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await context.SaveChangesAsync();

            return await context.SuperHeroes.ToListAsync();
        }
    }
}
