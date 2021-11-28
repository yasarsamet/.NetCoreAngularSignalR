using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRExampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidsController : ControllerBase
    {
        private readonly CovidService _service;

        public CovidsController(CovidService covidService)
        {
            _service = covidService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveCovid(Covid covid)
        {
            await _service.SaveCovid(covid);
            //IQueryable<Covid> covidList = _service.GetList();
            return Ok(_service.GetCovidChartList());
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> InitialCovid()
        {
            Random r = new Random();

            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (ECity item in Enum.GetValues(typeof(ECity)))
                {
                    var newcoid = new Covid
                    {
                        City = item,
                        Count = r.Next(100, 1000),
                        CovidDate = DateTime.Now.AddDays(x)
                    };
                    _service.SaveCovid(newcoid).Wait();
                    System.Threading.Thread.Sleep(1000);
                }
            });
            return Ok("Covid vakaları veri tabanına kaydedildi");
        }
    }
}
