using System;

namespace CovidWebService.Models
{
    /// <summary>
    /// Interface defining properties and methods for a person's COVID-19 data.
    /// </summary>
    public interface IIndicator
    {
        /// <summary> Number of infected individuals. </summary>
        int Infected { get; set; }

        /// <summary> Number of recovered individuals. </summary>
        int Recovered { get; set; }

        /// <summary> Number of deaths. </summary>
        int Deaths { get; set; }

        /// <summary> Date associated with the data. </summary>
        string Date { get; set; }

        /// <summary>
        /// Method to add to the number of infected individuals.
        /// </summary>
        /// <param name="value">Value to add.</param>
        void AddInfected(int value);

        /// <summary>
        /// Method to add to the number of recovered individuals.
        /// </summary>
        /// <param name="value">Value to add.</param>
        void AddRecovered(int value);

        /// <summary>
        /// Method to add to the number of deaths.
        /// </summary>
        /// <param name="value">Value to add.</param>
        void AddDeaths(int value);
    }

    [Serializable]
    /// <summary>
    /// Class implementing the IPerson interface to represent COVID-19 data for an individual.
    /// </summary>
    public class Indicator : IIndicator
    {
        // Private fields to store the total numbers and the date
        private int totalInfected;
        private int totalRecovered;
        private int totalDeaths;
        private string day;

        #region Methods

        /// <summary>
        /// Constructor to initialize the object with default values.
        /// </summary>
        public Indicator()
        {
            totalInfected = 0;
            totalRecovered = 0;
            totalDeaths = 0;
            day = DateTime.Today.ToString();   // Set the date to today
        }

        /// <summary> Property to get or set the date associated with the data. </summary>
        public string Date { get => day; set => day = value; }

        /// <summary>
        /// Property and method for the number of infected individuals.
        /// </summary>
        /// <remarks>
        /// Setting the value updates the count and sets the date to the current date and time.
        /// </remarks>
        public int Infected
        {
            get { return totalInfected; }
            set { totalInfected += value; day = DateTime.Now.ToString(); }
        }

        /// <summary>
        /// Property and method for the number of recovered individuals.
        /// </summary>
        /// <remarks>
        /// Setting the value updates the count and sets the date to the current date and time.
        /// </remarks>
        public int Recovered
        {
            get { return totalRecovered; }
            set { totalRecovered += value; day = DateTime.Now.ToString(); }
        }

        /// <summary>
        /// Property and method for the number of deaths.
        /// </summary>
        /// <remarks>
        /// Setting the value updates the count and sets the date to the current date and time.
        /// </remarks>
        public int Deaths
        {
            get { return totalDeaths; }
            set { totalDeaths += value; day = DateTime.Now.ToString(); }
        }

        /// <summary>
        /// Method to add to the number of infected individuals with input validation.
        /// </summary>
        /// <param name="value">Value to add.</param>
        public void AddInfected(int value)
        {
            if (value > 0)
            {
                totalInfected += value;
                day = DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// Method to add to the number of recovered individuals with input validation.
        /// </summary>
        /// <param name="value">Value to add.</param>
        public void AddRecovered(int value)
        {
            if (value > 0)
            {
                totalRecovered += value;
                day = DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// Method to add to the number of deaths with input validation.
        /// </summary>
        /// <param name="value">Value to add.</param>
        public void AddDeaths(int value)
        {
            if (value > 0)
            {
                totalDeaths += value;
                day = DateTime.Now.ToString();
            }
        }

        #endregion
    }
}
