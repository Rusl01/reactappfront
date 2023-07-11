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
        public async Task<string> GetExcelAsync(string NameFile)
        {

            string NameFiles = "wwwroot/" + NameFile;
            string webRootPath = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(webRootPath, NameFiles); // Замените "файл.xlsx" на имя вашего файла

            FileInfo fileInfo = new FileInfo(filePath);
            try
            {

                ExcelPackage package = new ExcelPackage(fileInfo);

                ExcelWorksheet worksheet = package.Workbook.Worksheets["Данные"]; // Индекс первого листа

                int rowCount = worksheet.Dimension.Rows;

                for (int row = 1; row <= rowCount; row++)
                {  
                    string cellValue = worksheet.Cells[row, 1].Value?.ToString();
                    // Обработка значения ячейки

                    // Задержка для примера (может быть не нужна в реальном коде)
                }

                return "Загружено";
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return "Ошибка";
            }

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
