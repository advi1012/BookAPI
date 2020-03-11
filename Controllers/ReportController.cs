using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BooksApi.Modelle;
using BooksApi.Dienste;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }


        // GET: api/Report
        [HttpGet]
        public ActionResult<List<Report>> Get() =>
            _reportService.Get();



        // GET: api/Report/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Report> Get(string id)
        {
            var report = _reportService.GetById(id);
            if (report == null)
            {
                return NotFound();
            }

            return report;
        }

        // POST: api/Report
        [HttpPost]
        [Consumes("application/csp-report")]
        public ActionResult<Report> Post(Report value)
        {
            _reportService.Create(value);

            return CreatedAtRoute("GetReport", new { id = value.Id.ToString() }, value);
        }

        
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Report reportIn)
        {
            var report = _reportService.GetById(id);
            if (report == null)
            {
                return NotFound();
            }
            _reportService.Update(id, reportIn);

            return NoContent();
        }

        
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var report = _reportService.GetById(id);

            if (report == null)
            {
                return NotFound();
            }

            _reportService.Remove(report.Id);

            return NoContent();


        }
    }
}
