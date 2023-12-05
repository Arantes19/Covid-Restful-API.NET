using Microsoft.AspNetCore.Mvc;
using System;

namespace CovidWebService.Controllers
{
    /// <summary>
    /// Controller for handling COVID-19 data-related operations.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : BaseController
    {
        #region GET

        /// <summary>
        /// Endpoint to get the number of infected individuals.
        /// </summary>
        /// <returns>The number of infected individuals.</returns>
        [HttpGet("GetInfects")]
        public int GetInfects()
        {
            return indicator.Infected;
        }

        /// <summary>
        /// Endpoint to get the number of recovered individuals.
        /// </summary>
        /// <returns>The number of recovered individuals.</returns>
        [HttpGet("GetRecovers")]
        public int GetRecovers()
        {
            return indicator.Recovered;
        }

        /// <summary>
        /// Endpoint to get the number of deaths.
        /// </summary>
        /// <returns>The number of deaths.</returns>
        [HttpGet("GetDeaths")]
        public int GetDeaths()
        {
            return indicator.Deaths;
        }

        #endregion

        #region POST

        /// <summary>
        /// Endpoint to post the number of infected individuals.
        /// </summary>
        /// <param name="x">The value to add to the number of infected individuals.</param>
        /// <returns>True if the operation is successful, otherwise false.</returns>
        [HttpPost("PostInfect")]
        public bool PostInfect(int x)
        {
            if (indicator != null)
            {
                indicator.Infected += x;
                indicator.Date = DateTime.Now.ToString();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Endpoint to post the number of recovered individuals.
        /// </summary>
        /// <param name="x">The value to add to the number of recovered individuals.</param>
        /// <returns>True if the operation is successful, otherwise false.</returns>
        [HttpPost("PostRecover")]
        public bool PostRecover(int x)
        {
            if (indicator != null)
            {
                indicator.Recovered += x;
                indicator.Date = DateTime.Now.ToString();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Endpoint to post the number of deaths.
        /// </summary>
        /// <param name="x">The value to add to the number of deaths.</param>
        /// <returns>True if the operation is successful, otherwise false.</returns>
        [HttpPost("PostDeath")]
        public bool PostDeath(int x)
        {
            if (indicator != null)
            {
                indicator.Deaths += x;
                indicator.Date = DateTime.Now.ToString();
                return true;
            }
            return false;
        }

        #endregion
    }
}
