using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using webapi.DB_Service;
using webapi.Model;
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
            //var a = jjs;
            _logger = logger;
            db = dbService;
        }

        [HttpPost]
        public async Task<List<EnrolleModel>> Programs([FromBody] GetDataForAllData Data)
        {
            List<EnrolleModel> ListEnrolle = new();

            switch (Data.ReasonForAdmission)
            {
                case "На общих основаниях":
                    {
                        ListEnrolle = await db.ListEnrolle.Where(x => x.ReasonForAdmission == "Бюджетная основа" && x.AdmissionCategory == "На общих основаниях").ToListAsync();
                        break;
                    }

                case "Целевая квота":
                    {
                        ListEnrolle = await db.ListEnrolle.Where(x => x.ReasonForAdmission == "Целевой прием").ToListAsync();
                        break;
                    }

                case "Отдельная квота":
                    {
                        ListEnrolle = await db.ListEnrolle.Where(x => x.ReceptionFeatures == "Отдельная квота").ToListAsync();

                        break;
                    }

                case "Специальная квота":
                    {
                        ListEnrolle = await db.ListEnrolle.Where(x => x.AdmissionCategory == "Имеющие особое право" && x.ReasonForAdmission == "Общие места").ToListAsync();

                        break;
                    }

                case "Полное возмещение затрат":
                    {
                        ListEnrolle = await db.ListEnrolle.Where(x => x.ReasonForAdmission == "Полное возмещение затрат").ToListAsync();

                        break;
                    }
            }

            ListEnrolle.OrderBy(x => x.SumBal_ID);

            for (int i = 0; i < ListEnrolle.Count; i++)
            {
                ListEnrolle[i].key = i + 1;
            }
            return ListEnrolle;
        }
    }
}
