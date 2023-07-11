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
    public class AllDirectionsController : ControllerBase
    {
        private readonly ILogger<AllDirectionsController> _logger;
        readonly DbService db;
        public AllDirectionsController(ILogger<AllDirectionsController> logger, DbService dbService)
        {

            _logger = logger;
            db = dbService;
        }

        [HttpGet]
        //public async Task<KashaModel> Programs(string LevelTraining, string FormStudy)
        //{
        //    KashaModel Summary = new();
        //    var AllNaprav = await db.ListEnrolle
        //        .Where(x => x.LevelTraining == LevelTraining && x.FormStudy == FormStudy)
        //        .Take(50)
        //        .ToListAsync();
        //    //var AllNaprav = await db.ListEnrolle.Where(x => x.LevelTraining == LevelTraining && x.FormStudy == FormStudy).Select(x=>x.Napravlenie).Distinct().ToListAsync();
        //    Summary.enrolleeModels = AllNaprav;
        //    Summary.strings = AllNaprav.Select(x => x.Napravlenie).Distinct().ToList();

        //    return Summary;
        //}
        public Task<IActionResult> Programs()
        {
            //KashaModel Summary = new();
            //var AllNaprav = await db.ListEnrolle
            //    .Where(x => x.LevelTraining == LevelTraining && x.FormStudy == FormStudy)
            //    .Take(50)
            //    .ToListAsync();
            ////var AllNaprav = await db.ListEnrolle.Where(x => x.LevelTraining == LevelTraining && x.FormStudy == FormStudy).Select(x=>x.Napravlenie).Distinct().ToListAsync();
            //Summary.enrolleeModels = AllNaprav;
            //Summary.strings = AllNaprav.Select(x => x.Napravlenie).Distinct().ToList();

            return (Task<IActionResult>)Results.Ok();
        }

    }
}
