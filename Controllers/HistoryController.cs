using CovidWebService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CovidWebService.Controllers
{
    /// <summary>
    /// Controller for managing COVID-19 history-related operations.
    /// </summary>
    [Route("api/[controller]")]
    public class HistoryController : BaseController
    {
        public HistoryController() { }

        #region History

        /// <summary>
        /// Endpoint to retrieve an indicator's data from the history by date.
        /// </summary>
        /// <param name="date">The date to search for.</param>
        /// <returns>The indicator's data if found, otherwise NotFound.</returns>
        [HttpGet("indicator/{date}")]
        public ActionResult<Indicator> Indicator(string date) // date == Data a procurar
        {
            if (hindicator != null)
            {
                return hindicator.GetIndicator(date);
            }
            return NotFound(); // 404 StatusCodes.Status404NotFound
        }

        /// <summary>
        /// Asynchronously endpoint to retrieve an indicator's data from the history by date.
        /// </summary>
        /// <param name="date">The date to search for.</param>
        /// <returns>The indicator's data if found, otherwise NotFound.</returns>
        [HttpGet("IndicatorSync/{date}")]  // date == Data a procurar
        public async Task<ActionResult<Indicator>> IndicatorAsync(string date)
        {
            if (hindicator != null)
            {
                return await hindicator.GetIndicatorAsync(date);
            }
            return NotFound(); // 404 StatusCodes.Status404NotFound
        }

        /// <summary>
        /// Endpoint to save the current indicator's data to the history.
        /// </summary>
        /// <returns>HTTP response indicating success or unauthorized access.</returns>
        [HttpPost("saveCurrentIndicator")]
        public ActionResult Insert()
        {
            if (hindicator.AddIndicator(indicator)) return Ok(); //  200 StatusCodes.Status200OK
            else return Unauthorized();
        }

        /// <summary>
        /// Endpoint to add a new indicator's data to the history.
        /// </summary>
        /// <param name="i">The indicator representing the person's data.</param>
        /// <returns>HTTP response indicating success or unauthorized access.</returns>
        [HttpPost("newCurrentIndicator")]
        public ActionResult Insert(Indicator i)
        {
            if (!hindicator.AddIndicator(i)) return Ok(); //  200 StatusCodes.Status200OK
            else return Unauthorized();
        }


        /// <summary>
        /// Asynchronously endpoint to insert a new indicator's data to the history.
        /// </summary>
        /// <param name="p">The indicator representing the person's data.</param>
        /// <returns>HTTP response indicating success or unauthorized access.</returns>
        [HttpPost("newIndicatorSync")]
        public async Task<ActionResult> InsertSync(Indicator p)   // insere o indicador corrente
        {
            bool aux = await hindicator.AddIndicatorAsync(p);

            if (aux)
                return Ok();            //  200 StatusCodes.Status200OK
            else
                return Unauthorized();  //  404 StatusCodes.Status404NotFound
        }

        #endregion
    }
}
