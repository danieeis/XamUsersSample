using System;
namespace UsersSample.Models.Auth
{
    /// <summary>
    /// Class for parameter in the request
    /// </summary>
    public class Parameter
    {
        private Object originalVal;
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; private set; }

        /// <summary>
        /// Value of parameter in the request
        /// </summary>
        /// <value>The value.</value>
        public Object val
        {
            get
            {
               return this.originalVal;
            }
        }
        /// <summary>
        /// Parameter contructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="val"></param>
        public Parameter(string name, Object val)
        {
            this.name = name;
            this.originalVal = val;
        }
    }
}
