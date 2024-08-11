using Microsoft.AspNetCore.Mvc;
using PizzaPlace.DBContext;
using PizzaPlace.Model;
using PizzaPlace.Repository;

namespace PizzaPlace.Controllers
{
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly ImportCsvData _importService;
        private readonly OrderDetailsRepository _repos;
        private readonly PizzaPlaceDbContext _context;

        public ImportController(PizzaPlaceDbContext context, ImportCsvData importService, OrderDetailsRepository repos)
        {
            _importService = importService;
            _repos = repos;
            _context = context;
        }


        /// <summary>
        /// Import data from csv file, just attached the file path of your csv file
        /// </summary>
        [HttpPost]
        [Route("api/Import/OrderDetails")]
        public IActionResult ImportOrderDetails(string filePath)
        {
            try
            {
                // Import data from CSV
                var result = _importService.ImportOrderDetails(filePath);

                // Save data to database
                if (result != null)
                {
                    _repos.AddOrderDetails(result);
                    return Ok("CSV Imported and loaded to database successfully!");
                }
                throw new Exception("Data not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Import failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Import data from csv file, just attached the file path of your csv file
        /// </summary>
        [HttpPost]
        [Route("api/Import/Order")]
        public IActionResult ImportOrder(string filePath)
        {
            try
            {
                // Import data from CSV
                var result = _importService.ImportOrderTransaction(filePath);

                // Save data to database
                if (result != null)
                {
                    _repos.AddOrderTransactions(result);
                    return Ok("CSV Imported and loaded to database successfully!");
                }
                throw new Exception("Data not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Import failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Import data from csv file, just attached the file path of your csv file
        /// </summary>
        [HttpPost]
        [Route("api/Import/Pizza")]
        public IActionResult ImportPizza(string filePath)
        {
            try
            {
                // Import data from CSV
                var result = _importService.ImportPizza(filePath);

                // Save data to database
                if (result != null)
                {
                    _repos.AddPizza(result);
                    return Ok("CSV Imported and loaded to database successfully!");
                }
                throw new Exception("Data not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Import failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Import data from csv file, just attached the file path of your csv file
        /// </summary>
        [HttpPost]
        [Route("api/Import/PizzaType")]
        public IActionResult ImportPizzaType(string filePath)
        {
            try
            {
                // Import data from CSV
                var result = _importService.ImportPizzaType(filePath);

                // Save data to database
                if (result != null)
                {
                    _repos.AddPizzaTypes(result);
                    return Ok("CSV Imported and loaded to database successfully!");
                }
                throw new Exception("Data not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Import failed: {ex.Message}");
            }
        }
    }
}