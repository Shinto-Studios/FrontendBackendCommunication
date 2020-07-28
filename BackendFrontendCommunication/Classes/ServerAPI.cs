using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ServerAPIStuff
{
    class ServerAPI
    {
        private readonly string website = "https://shintostudios.net/fbc/";
        private readonly Uri websiteRegister;
        private readonly Uri websiteLogin;

        private readonly HttpClient httpClient;

        public ServerAPI()
        {
            websiteRegister = new Uri(website + "register.php");
            websiteLogin = new Uri(website + "login.php");

            httpClient = new HttpClient();
        }

        public async void RegisterUser(string username, string password)
        {
            FormUrlEncodedContent postValues = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            HttpResponseMessage response = await httpClient.PostAsync(websiteRegister, postValues);

            StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync());

            MessageBox.Show("Server Response: " + reader.ReadToEnd());
        }

        public async void LoginUser(string username, string password)
        {
            FormUrlEncodedContent postValues = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            HttpResponseMessage response = await httpClient.PostAsync(websiteLogin, postValues);

            StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync());

            MessageBox.Show("Server Response: " + reader.ReadToEnd());
        }
    }
}
