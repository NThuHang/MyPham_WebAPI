using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MyPham_WebAPP
{
    public class ketnoi
    {
        public static HttpClient webApiClient = new HttpClient();
        internal static object content;

        static ketnoi()
        {
            webApiClient.BaseAddress = new Uri("https://localhost:44336/api/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}