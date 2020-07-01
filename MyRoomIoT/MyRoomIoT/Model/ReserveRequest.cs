using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MyRoomIoT.Model
{
    internal class ReserveRequest
    {
        internal static async System.Threading.Tasks.Task<string> SendPostAsync(string fileName ,string dateTime)
        {
            string result = "";
            var parameters = new Dictionary<string, string>()
            {
                {"pass", MyData.PASS },
                {"data", fileName },
                {"time",dateTime }
            };
            var content = new FormUrlEncodedContent(parameters);
            //オレオレ証明書対策
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = delegate { return true; };
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                HttpResponseMessage respns;
                //家庭内LANかどうかを識別出来たら例外で分岐しなくてよくなりそう
                try
                {
                    respns = await httpClient.PostAsync(MyData.URL_R_HOME, content);
                    result = await respns.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(result);
                }
                catch (HttpRequestException e)
                {
                    try
                    {
                        respns = await httpClient.PostAsync(MyData.URL_R, content);
                        result = await respns.Content.ReadAsStringAsync();
                        System.Diagnostics.Debug.WriteLine(result);
                    }
                    catch
                    {
                        Exception ex = e;
                        result = "失敗しました！\n";
                        while (ex != null)
                        {
                            System.Diagnostics.Debug.WriteLine("例外メッセージ ", ex.Message);
                            ex = ex.InnerException;
                            result += ex.Message + "\n";
                        }
                    }
                }
            }
            return result;
        }
    }
}