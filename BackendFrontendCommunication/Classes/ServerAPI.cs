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
        private string website = "https://amdigg.com/fbc/";
        private Uri websiteRegister;
        private Uri websiteLogin;

        private HttpClient httpClient;

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
    }
}
