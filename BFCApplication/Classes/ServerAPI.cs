using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;

namespace ServerAPIStuff
{
    public class ServerResponse
    {
        public string Status { get; set; }
        public string Username { get; set; }
        public string Rank { get; set; }
        public string Mail { get; set; }
        public string ID { get; set; }
    }

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

        public async void RegisterUser(string username, string password, string email, Action<ServerResponse> callback = null)
        {
            FormUrlEncodedContent postValues = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("email", email)
            });

            HttpResponseMessage response = await httpClient.PostAsync(websiteRegister, postValues);

            StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync());

            callback?.Invoke(JsonSerializer.Deserialize<ServerResponse>(reader.ReadToEnd()));
        }

        public async void LoginUser(string username, string password, Action<ServerResponse> callback = null)
        {
            FormUrlEncodedContent postValues = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("login", username),
                new KeyValuePair<string, string>("password", password)
            });

            HttpResponseMessage response = await httpClient.PostAsync(websiteLogin, postValues);

            StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync());

            callback?.Invoke(JsonSerializer.Deserialize<ServerResponse>(reader.ReadToEnd()));
        }

        
        public async void FetchUser(string username, Action<ServerResponse> callback)
        {
            FormUrlEncodedContent postValues = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("login", username),
            });

            HttpResponseMessage response = await httpClient.PostAsync(websiteFetch, postValues);

            StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync());

            callback(JsonSerializer.Deserialize<ServerResponse>(reader.ReadToEnd()));
        }

        public async void LogoutUser(Action<ServerResponse> callback = null)
        {
            HttpResponseMessage response = await httpClient.GetAsync(websiteLogout);

            StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync());

            callback?.Invoke(JsonSerializer.Deserialize<ServerResponse>(reader.ReadToEnd()));
        }
    }
}