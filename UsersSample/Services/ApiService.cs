using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UsersSample.Models.Auth;

namespace UsersSample.Services
{
    /// <summary>
    /// Class for connect with the API
    /// </summary>
    public class ApiService
    {
        /// <summary>
        /// Tag
        /// </summary>
        string TAG = "ApiService: ";
        /// <summary>
        /// Api url
        /// </summary>
        public const string REST_URL = Parameters.REST_URL;
        /// <summary>
        /// Constructor
        /// </summary>
        public ApiService()
        {
            System.Console.WriteLine(TAG + "Instanciando ApiService " + REST_URL);
            handler = new HttpClientHandler() {  };
            client = new HttpClient(handler)
            {
                BaseAddress = new Uri(REST_URL),
                MaxResponseContentBufferSize = 9999999,
                Timeout = TimeSpan.FromSeconds(60)
            };
        }
        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        public HttpClient client { get; }
        /// <summary>
        /// Gets the handler.
        /// </summary>
        /// <value>
        /// The handler.
        /// </value>
        public HttpClientHandler handler { get; }
        /// <summary>
        /// GET method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="cts"></param>
        /// <returns></returns>
        public async Task<TransactionResult<T>> get<T>(String url, CancellationTokenSource cts = null)
        {
            if (cts == null)
            {
                cts = new CancellationTokenSource();
            }
            HttpResponseMessage response = null;
            try
            {
                Console.WriteLine(TAG + ".GET:" + url);
                response = await client.GetAsync(url, cts.Token);
                var result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new TransactionResult<T>
                    {
                        Success = false,
                        RawValue = result,
                    };
                }

                string contentType = null;
                if (response.Content.Headers.Contains("Content-Type"))
                {
                    contentType = response.Content.Headers.GetValues("Content-Type").ToList().First();
                }
                object content = null;
                bool readString = false;
                string contentString = null;
                if (typeof(T).FullName == typeof(Stream).FullName)
                {
                    content = await response.Content.ReadAsStreamAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        readString = true;
                    }
                }
                else
                {
                    readString = true;
                }

                if (readString)
                {
                    contentString = await response.Content.ReadAsStringAsync();
                    content = contentString;
                }

                Console.WriteLine(TAG + ".GET " + url + " response(" + ((int)response.StatusCode) + " " + contentType + "):" + content + "");

                T resultValue = default(T);
                if (contentString != null)
                {
                    resultValue = response.IsSuccessStatusCode == true ? (typeof(T) == typeof(string) ? ((T)Convert.ChangeType(content, typeof(T))) : JsonConvert.DeserializeObject<T>(contentString)) : default(T);
                }
                else
                {
                    resultValue = (T)content;
                }

                return new TransactionResult<T>
                {
                    Success = true,
                    RawValue = contentString,
                    Value = resultValue,
                };
            }
            catch (Exception ex)
            {
                return await BuilFromExceptionAsync<T>("GET", response, ex);
            }
        }
        
        /// <summary>
        /// Build exception async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <param name="response"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private async Task<TransactionResult<T>> BuilFromExceptionAsync<T>(string method, HttpResponseMessage response, Exception ex)
        {
            int statusCode = 500;
            string errorMessage = null;
            if (ex is TaskCanceledException)
            {
                var t = ex as TaskCanceledException;
                errorMessage = "Operación cancelada";
            }
            string content = null;
            if (response != null)
            {
                statusCode = (int)response.StatusCode;
                if (response.Content != null)
                {
                    content = await response.Content.ReadAsStringAsync();
                }
            }
            Console.WriteLine(TAG + method + " (" + statusCode + ")" + " BuilFromException " + errorMessage + " __ \n" + ex.ToString());

            return new TransactionResult<T>()
            {
                Success = false,
                ErrorMessage = errorMessage,
                RawValue = content,
                Value = default(T),
                HttpStatus = statusCode
            };
        }
    }
}