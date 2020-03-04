using System.Collections.Generic;
using System.Net.Http;

namespace MyRoomIoT.Model
{
    internal class HTMLRequest
    {
        internal static async System.Threading.Tasks.Task<string> SendPostAsync(string fileName)
        {
            string result ="";
            var parameters = new Dictionary<string, string>()
            {
                {"pass", MyData.PASS },
                {"data", fileName }
            };
            var content = new FormUrlEncodedContent(parameters);
            using(var httpClient = new HttpClient())
            {
                var respns = await httpClient.PostAsync(MyData.URL, content);
                result = respns.ToString();
            }

            return result;
        }
    }
}
