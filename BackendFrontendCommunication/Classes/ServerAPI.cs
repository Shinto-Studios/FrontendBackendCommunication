using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;

namespace ServerAPIStuff
{
    class ServerAPI
    {
        private readonly string website = "https://shintostudios.net/fbc/";
        private readonly Uri websiteRegister;
        private readonly Uri websiteLogin;
        private readonly Uri websiteFetch;
        private readonly Uri websiteLogout;

        private readonly HttpClient httpClient;

        public ServerAPI()
        {
            websiteRegister = new Uri(website + "register.php");
            websiteLogin = new Uri(website + "login.php");
            websiteFetch = new Uri(website + "fetch.php");
            websiteLogout = new Uri(website + "logout.php");

            httpClient = new HttpClient();
        }

        public async void RegisterUser(string username, string password, string email, Action<string> callback = null)
        {
            FormUrlEncodedContent postValues = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("email", email)
              
             
            });

            HttpResponseMessage response = await httpClient.PostAsync(websiteRegister, postValues);

            StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync());

            callback?.Invoke(reader.ReadToEnd());
        }

        public async void LoginUser(string username, string password, Action<string> callback = null)
        {
            FormUrlEncodedContent postValues = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("login", username),
                new KeyValuePair<string, string>("password", password)
            });

            HttpResponseMessage response = await httpClient.PostAsync(websiteLogin, postValues);

            StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync());

            callback?.Invoke(reader.ReadToEnd());
        }

        public async void FetchUser(string username, Action<string> callback)
        {
            FormUrlEncodedContent postValues = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username)
            });

            HttpResponseMessage response = await httpClient.PostAsync(websiteFetch, postValues);

            StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync());

            callback(reader.ReadToEnd());
        }

        public async void LogoutUser(Action<string> callback = null)
        {
            HttpResponseMessage response = await httpClient.GetAsync(websiteLogout);

            StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync());

            callback?.Invoke(reader.ReadToEnd());
        }
    }
}
