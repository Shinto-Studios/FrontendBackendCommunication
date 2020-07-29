using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerAPIStuff;

namespace BFCApplication
{
    public partial class Form1 : Form
    {
        private readonly ServerAPI apiRequest;

        public Form1()
        {
            InitializeComponent();

            apiRequest = new ServerAPI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            apiRequest.RegisterUser(textBox1.Text, textBox2.Text, textBox3.Text, OnRegisterUserDone);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            apiRequest.LoginUser(textBox1.Text, textBox2.Text, OnLoginUserDone);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            apiRequest.FetchUser(textBox1.Text, OnFetchUserDone);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            apiRequest.LogoutUser(OnLogoutUserDone);
        }

        private void OnRegisterUserDone(ServerResponse response)
        {
            MessageBox.Show(response.Status);
        }

        private void OnLoginUserDone(ServerResponse response)
        {
            MessageBox.Show(response.Status);

            if(response.Status == "Login success")
            {
                MessageBox.Show("ID: " + response.ID);

                button2.Enabled = false;
                button4.Enabled = true;
            }
        }

        private void OnFetchUserDone(ServerResponse response)
        {
            MessageBox.Show(response.Status);
            MessageBox.Show(response.Username);
            MessageBox.Show(response.ID);
            MessageBox.Show(response.Mail);
            MessageBox.Show(response.Rank);
        }

        private void OnLogoutUserDone(ServerResponse response)
        {
            MessageBox.Show(response.Status);

            button2.Enabled = true;
            button4.Enabled = false;
        }
    }
}
