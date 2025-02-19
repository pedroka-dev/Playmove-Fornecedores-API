using Fornecedores_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        DbContext supplierDbContext;
        private readonly ILogger<BaseEntity> _logger;

        public SupplierController(ILogger<BaseEntity> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<BaseEntity> Get()
        {
            throw new NotImplementedException();
            //return Enumerable.Range(1, 5).Select(index => new BaseEntity
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
