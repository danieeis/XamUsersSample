using System;
using System.Collections.Generic;
using System.Linq;

namespace UsersSample.Models.Auth
{
    /// <summary>
    /// class that prepares the data to send requests to the server 
    /// </summary>
    public class DataRequest
    {

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public List<Parameter> Parameters { get { return Values.Values.ToList(); } }
        /// <summary>
        /// The values
        /// </summary>
        private Dictionary<String, Parameter> Values;
        /// <summary>
        /// Constructor of the class
        /// </summary>
        public DataRequest()
        {
            Values = new Dictionary<string, Parameter>();
        }
        /// <summary>
        /// Add data in the request
        /// </summary>
        /// <param name="key">key of the request</param>
        /// <param name="v">value</param>
        /// <returns></returns>
        public DataRequest Add(string key, Object v)
        {
            if (Values.ContainsKey(key))
            {
                Values.Remove(key);
            }
            Values.Add(key, new Parameter(key, v));
            return this;
        }
        /// <summary>
        /// comprove if the contains any key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>true or false</returns>
        public bool ContainsKey(string key)
        {
            return Values.ContainsKey(key);
        }
        /// <summary>
        /// Clear all the data in the request
        /// </summary>
        /// <returns></returns>
        public DataRequest Clear()
        {
            Values.Clear();
            return this;
        }
    }
}