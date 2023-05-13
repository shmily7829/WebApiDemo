using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Services.SuperHeroService;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            this.superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroesAsync()
        {
            return await superHeroService.GetAllHeroesAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await superHeroService.GetHeroAsync(id);
            if (hero == null)
            {
                return NotFound("this hero doesn't exist.");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            List<SuperHero> heroes = await superHeroService.AddHeroAsync(hero);
            return Ok(heroes);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var heroes = await superHeroService.UpdateHeroAsync(id, request);
            if (heroes == null)
            {
                return NotFound("this hero doesn't exist.");
            }
            return Ok(heroes);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var heros = await superHeroService.DeleteHeroAsync(id);
            if (heros == null)
            {
                return NotFound("this hero doesn't exist.");
            }
            
            return Ok(heros);
        }
    }
}

