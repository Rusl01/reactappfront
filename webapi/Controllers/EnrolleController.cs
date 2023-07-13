using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DB_Service;
using webapi.Model;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnrolleController : ControllerBase
    {


        private readonly ILogger<EnrolleController> _logger;
        readonly DbService db;
        public EnrolleController(ILogger<EnrolleController> logger, DbService dbService)
        {
            //var a = jjs;
            _logger = logger;
            db = dbService;
        }


        [HttpPost]
        public async Task<bool> Programs([FromBody] EnrolleSnils enrolleSnils)
        {
            var ExistEnrolle = await db.ListEnrolle.Where(x => x.Snils == enrolleSnils.Snils).FirstOrDefaultAsync();
            if (ExistEnrolle == null)
                return false;
            else
                return true;
        }
    }
}
