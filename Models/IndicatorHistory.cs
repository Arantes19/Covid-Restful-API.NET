using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidWebService.Models
{
    /// <summary>
    /// Interface defining methods for managing a history of indicators for COVID-19 data.
    /// </summary>
    public interface IIndicatorHistory
    {
        /// <summary> Retrieve a list of all indicators in the history. </summary>
        List<IIndicator> GetAllIndicators();

        /// <summary> Get an indicator from the history by a specified date. </summary>
        Indicator GetIndicator(string day);

        /// <summary> Asynchronously get an indicator from the history by a specified date. </summary>
        Task<Indicator> GetIndicatorAsync(string day);

        /// <summary> Add an indicator to the history. </summary>
        bool AddIndicator(IIndicator indicator);

        /// <summary> Asynchronously add an indicator to the history. </summary>
        Task<bool> AddIndicatorAsync(IIndicator indicator);

        /// <summary> Save the history to a file. </summary>
        bool SaveHistory(string filename);

        /// <summary> Load the history from a file. </summary>
        bool LoadHistory(string filename);
    }

    [Serializable]
    /// <summary>
    /// Class implementing IIndicatorHistory for managing a history of indicators for COVID-19 data.
    /// </summary>
    public class IndicatorHistory : IIndicatorHistory
    {
        // Simulate Database
        private List<IIndicator> indicatorHistory;

        /// <summary>
        /// Constructor to initialize the IndicatorHistory object.
        /// </summary>
        public IndicatorHistory()
        {
            if (indicatorHistory == null) indicatorHistory = new List<IIndicator>();
        }

        /// <summary> Retrieve a list of all indicators in the history. </summary>
        public List<IIndicator> GetAllIndicators()
        {
            return indicatorHistory.GetRange(0, indicatorHistory.Count);
        }

        /// <summary>
        /// Get an indicator from the history by a specified date.
        /// </summary>
        /// <param name="day">Date of the indicator.</param>
        /// <returns></returns>
        public Indicator GetIndicator(string day)
        {
            foreach (Indicator indicator in indicatorHistory)
            {
                if (indicator.Date == day) return indicator;
            }
            return null;
        }

        /// <summary>
        /// Asynchronously get an indicator from the history by a specified date.
        /// </summary>
        /// <param name="day">Date of the indicator.</param>
        /// <returns></returns>
        public async Task<Indicator> GetIndicatorAsync(string day)
        {
            foreach (Indicator indicator in indicatorHistory)
            {
                if (indicator.Date == day) return indicator;
            }
            await Task.Delay(3000);
            return null;
        }

        /// <summary>
        /// Add an indicator to the history.
        /// </summary>
        /// <param name="indicator">Indicator to add.</param>
        /// <returns></returns>
        public bool AddIndicator(IIndicator indicator)
        {
            if ((indicatorHistory != null) && (!indicatorHistory.Contains(indicator)))
            {
                Indicator newIndicator = new Indicator();
                newIndicator = (Indicator)indicator;
                indicatorHistory.Add(newIndicator);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Asynchronously add an indicator to the history.
        /// </summary>
        /// <param name="indicator">Indicator to add.</param>
        /// <returns></returns>
        public async Task<bool> AddIndicatorAsync(IIndicator indicator)
        {
            // Simulate Database
            if ((indicatorHistory != null) && (!indicatorHistory.Contains(indicator)))
            {
                Indicator aux = new Indicator();
                aux.Date = indicator.Date;
                aux.Infected = indicator.Infected;
                aux.Deaths = indicator.Deaths;
                aux.Recovered = indicator.Recovered;
                indicatorHistory.Add(aux);
                await Task.Delay(3000);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Save the history to a file.
        /// </summary>
        /// <param name="fileName">The name of the file to save the history to.</param>
        /// <returns>True if the save operation is successful, otherwise false.</returns>
        public bool SaveHistory(string fileName)
        {
            // Database Handling

            #region File
            //if (File.Exists(fileName))
            //{
            //    try
            //    {
            //        Stream stream = File.Open(fileName, FileMode.OpenOrCreate,FileAccess.ReadWrite);
            //        BinaryFormatter bin = new BinaryFormatter();
            //#pragma warning disable SYSLIB0011 // Type or member is obsolete
            //        bin.Serialize(stream, hist);
            //#pragma warning restore SYSLIB0011 // Type or member is obsolete
            //        stream.Close();
            //        return true;
            //    }
            //    catch (IOException e)
            //    {
            //        throw new Exception(e.Message+"- Saving Problems");
            //    }
            //}
            #endregion
            return true;
        }

        /// <summary>
        /// Load the history from a file.
        /// </summary>
        /// <param name="fileName">The name of the file to load the history from.</param>
        /// <returns>True if the load operation is successful, otherwise false.</returns>
        public bool LoadHistory(string fileName)
        {
            // Database Handling

            #region File
            //if (File.Exists(fileName))
            //{
            //    try
            //    {
            //        Stream stream = File.Open(fileName, FileMode.Open);
            //        BinaryFormatter bin = new BinaryFormatter();
            //#pragma warning disable SYSLIB0011 // Type or member is obsolete
            //        hist = (List<IIndicadoresModel>)bin.Deserialize(stream);
            //#pragma warning restore SYSLIB0011 // Type or member is obsolete
            //        stream.Close();
            //        return true;
            //    }
            //    catch (IOException e)
            //    {
            //        throw new Exception(e.Message + " - Loading Problems");
            //    }
            //}
            //return false;
            #endregion
            return true;
        }
    }
}
