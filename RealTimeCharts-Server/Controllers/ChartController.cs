using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeCharts_Server.DataStorage;
using RealTimeCharts_Server.HubConfig;
using RealTimeCharts_Server.TimeFeatures;

namespace RealTimeCharts_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChartController : Controller
    {
        private readonly IHubContext<ChartHub> _hub;
        public ChartController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var timer = new TimeManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));
            
            return Ok( new { Message = "Request Complete" });
        }
    }
}
