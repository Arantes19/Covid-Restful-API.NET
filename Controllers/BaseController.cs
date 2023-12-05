using CovidWebService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CovidWebService.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected static IIndicator indicator;
        protected static IIndicatorHistory hindicator;

        /// <summary>
        /// SingleTon
        /// </summary>
        public BaseController()
        {
            if(indicator == null) indicator = new Indicator();
            if(hindicator == null) hindicator = new IndicatorHistory();
        }
    }
}
