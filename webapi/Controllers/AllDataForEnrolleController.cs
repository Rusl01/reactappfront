using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DB_Service;
using webapi.Model;
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

        [HttpPost]
        public async Task<List<EnrolleModel>> Programs([FromBody] EnrolleSnils snils)
        {

            List<EnrolleModel> Enrolles = await db.ListEnrolle.Where(x => x.Snils == snils.Snils).OrderBy(x => x.Priority).ToListAsync();

            return Enrolles;
        }
    }
}
