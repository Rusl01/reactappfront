using webapi.Model;
using webapi.Model.BD_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using webapi.DB_Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllProfilesOfDirectionsController : ControllerBase
    {
        private readonly ILogger<AllProfilesOfDirectionsController> _logger;
        readonly DbService db;
        public AllProfilesOfDirectionsController(ILogger<AllProfilesOfDirectionsController> logger, DbService dbService)
        {

            _logger = logger;
            db = dbService;
        }

        [HttpGet]
        public async Task<List<string>> Programs(string LevelTraining, string FormStudy, string Napravlenie)
        {
            var Profils = await db.ListEnrolle.Where(x => x.LevelTraining == LevelTraining && x.FormStudy == FormStudy && x.Napravlenie == Napravlenie).Select(x => x.Profil).Distinct().ToListAsync();

            return Profils;
        }

    }
}
