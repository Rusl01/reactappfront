using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DB_Service;
using webapi.Model.BD_Model;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllDataForEnrolleController : ControllerBase
    {
        private readonly ILogger<AllDataForEnrolleController> _logger;
        readonly DbService db;
        public AllDataForEnrolleController(ILogger<AllDataForEnrolleController> logger, DbService dbService)
        {

            _logger = logger;
            db = dbService;
        }

        [HttpGet]
        public async Task<List<OneEnrolleListModel>> Programs(string Snils)
        {
            List<OneEnrolleListModel> Enrolles = await db.ListEnrolle.Where(x => x.Snils == Snils).Select(x => new OneEnrolleListModel
            {
                Snils = x.Snils,
                AdmissionCategory = x.AdmissionCategory,
                FoundationReceipts = x.FoundationReceipts,
                HaveDiplomInVus = x.HaveDiplomInVus,
                IdEnrolle = x.IdEnrolle,
                LevelTraining = x.LevelTraining,
                Napravlenie = x.Napravlenie,
                Naprav_Group = x.Naprav_Group,
                Prioritet = x.Prioritet,
                Profil = x.Profil,
                Soglasie = x.Soglasie,
                SumBall = x.SumBall,
                SumBall_ID = x.SumBall_ID,
                TypeIsp = x.TypeIsp
            }).ToListAsync();

            return Enrolles;
        }
    }
}
