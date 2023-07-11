using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using webapi.DB_Service;
using webapi.Model.BD_Model;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllDataController : ControllerBase
    {
        private readonly ILogger<AllDataController> _logger;
        readonly DbService db;
        public AllDataController(ILogger<AllDataController> logger, DbService dbService)
        {

            _logger = logger;
            db = dbService;
        }

        [HttpGet]

        public async Task<List<OneEnrolleListModel>> Programs([FromBody] string)
        {
            //string LevelTraining, string FormStudy, string Napravlenie, string Profil
            //[FromForm] string LevelTraining, [FromForm] string FormStudy, [FromForm] string Napravlenie, [FromForm] string Profil
            //List<OneEnrolleListModel> Enrolles = await db.ListEnrolle.Where(x => x.LevelTraining == LevelTraining && x.FormStudy == FormStudy && x.Napravlenie == Napravlenie && x.Profil == Profil).Select(x => new OneEnrolleListModel
            //{
            //    Snils = x.Snils,
            //    AdmissionCategory = x.AdmissionCategory,
            //    FoundationReceipts = x.FoundationReceipts,
            //    HaveDiplomInVus = x.HaveDiplomInVus,
            //    IdEnrolle = x.IdEnrolle,
            //    LevelTraining = x.LevelTraining,
            //    Napravlenie = x.Napravlenie,
            //    Naprav_Group = x.Naprav_Group,
            //    Prioritet = x.Prioritet,
            //    Profil = x.Profil,
            //    Soglasie = x.Soglasie,
            //    SumBall = x.SumBall,
            //    SumBall_ID = x.SumBall_ID,
            //    TypeIsp = x.TypeIsp
            //}).ToListAsync();

            List<OneEnrolleListModel> Enrolles = new();
            Enrolles.Add(new OneEnrolleListModel { IdEnrolle = 10000 });
            Enrolles.Add(new OneEnrolleListModel { IdEnrolle = 10001 });
            Enrolles.Add(new OneEnrolleListModel { IdEnrolle = 10002 });
            Enrolles.Add(new OneEnrolleListModel { IdEnrolle = 10003 });

            return Enrolles;
        }
    }
}
