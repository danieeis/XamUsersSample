using System;
using UsersSample.Models.Auth;

namespace UsersSample.Helpers
{
    public class DataUtil
    {
        /// <summary>
        /// Build a URL for make a petition
        /// </summary>
        /// <returns>The URL.</returns>
        /// <param name="path">Path.</param>
        /// <param name="queryParams">Query parameters.</param>
        public static String buildUrl(String path, DataRequest queryParams)
        {
            String url = path;
            if (path == null || path.Length == 0)
            {
                throw new Exception("The path of url can't be empty");
            }
            int position1 = path.IndexOf("&");
            int position2 = path.IndexOf("?");
            int position3 = path.IndexOf("=");
            if (position1 != -1 && position2 == -1)
            {
                throw new Exception(string.Format("The path '{0}' is malformed.", path));
            }

            if (position1 != -1 && position2 != -1 && position1 < position2)
            {
                throw new Exception(string.Format("The path '{0}' is malformed.", path));
            }

            if (position2 == -1)
            {
                url += "?";
            }
            else if (position3 != -1)
            {
                url += "&";
            }
            string query = "";
            string separator = "&";
            foreach (Parameter parameter in queryParams.Parameters)
            {
                query += parameter.name + "=" + parameter.val;
                if (!queryParams.Parameters.IndexOf(parameter).Equals(queryParams.Parameters.Count - 1))
                    query += separator;
            }
            url += query;
            return url;
        }
    }
}
