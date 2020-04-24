using System;
using System.Threading.Tasks;
using UsersSample.Models.Auth;
using Xamarin.Forms;
using UsersSample.Models.User;
using UsersSample.Helpers;
using System.Collections.Generic;

namespace UsersSample.Services
{
    public class RouteUser
    {
        const string USER_LIST = "/public-api/users";
        /// <summary>
        /// Get users list
        /// </summary>
        /// <returns></returns>
        async internal Task<TransactionResult<Users>> GetUsers()
        {
            DataRequest parameters = new DataRequest();
            parameters.Add("_format", "json");
            parameters.Add("access-token", Parameters.Access_Token);
            String url = DataUtil.buildUrl(USER_LIST, parameters);
            TransactionResult<Users> result = await DependencyService.Get<ApiService>().get<Users>(url);

            return result;
        }
    }
}
