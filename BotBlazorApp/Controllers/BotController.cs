using System.Text.Json;
using BotBlazorApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace BotBlazorApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BotController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BotController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet,ActionName("chartData")]
        public async Task Get()
        {
            HttpContext.Response.Headers.Add("Cache-Control", "no-cache");
            HttpContext.Response.Headers.Add("Content-Type", "text/event-stream");
            await HttpContext.Response.Body.FlushAsync();

            var data = await _unitOfWork.BotChartDataRepository.GetAsync(s => s.Date > DateTime.Now.AddMinutes(-1), x => x.OrderByDescending(z => z.Id));
         
            await HttpContext.Response.WriteAsync("data: " + JsonSerializer.Serialize(data[0])+ "\n");

            await HttpContext.Response.Body.FlushAsync();
        }
    }
}
