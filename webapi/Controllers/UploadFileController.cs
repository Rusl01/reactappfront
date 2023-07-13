using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using webapi.DB_Service;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly ILogger<UploadFileController> _logger;
        readonly DbService db;
        public UploadFileController(ILogger<UploadFileController> logger, DbService dbService)
        {

            _logger = logger;
            db = dbService;
        }
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            // Проверка, что файл существует
            if (file == null || file.Length <= 0)
            {
                return BadRequest("Файл не найден");
            }

            // Проверка расширения файла
            if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Неверный формат файла. Ожидается файл Excel (.xlsx)");
            }

            // Чтение данных из файла Excel
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);

                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Первый лист в файле

                    // Обработка данных из файла Excel
                    // Например, чтение значений ячеек, сохранение данных и дальнейшая логика

                    // Пример чтения значения из ячейки A1
                    var valueA1 = worksheet.Cells["A1"].Value.ToString();

                    // Пример чтения значений из столбца A
                    var columnA = new List<string>();
                    int rows = worksheet.Dimension.Rows;
                    for (int i = 1; i <= rows; i++)
                    {
                        var cellValue = worksheet.Cells[i, 1].Value;
                        if (cellValue != null)
                        {
                            columnA.Add(cellValue.ToString());
                        }
                    }

                    // Пример чтения значений из определенного диапазона ячеек
                    var dataRange = worksheet.Cells["A1:C10"];
                    var valuesInRange = new List<string>();
                    foreach (var cell in dataRange)
                    {
                        valuesInRange.Add(cell.Value.ToString());
                    }

                    // Ваши дальнейшие действия с данными из файла Excel

                    return Ok("Данные из файла Excel успешно обработаны");
                }
            }
        }

    }
}
