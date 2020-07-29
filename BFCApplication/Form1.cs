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

        private void OnRegisterUserDone(string response)
        {
            MessageBox.Show(response);
        }

        private void OnLoginUserDone(string response)
        {
            MessageBox.Show(response);

            button2.Enabled = false;
            button4.Enabled = true;
        }

        private void OnFetchUserDone(string response)
        {
            MessageBox.Show(response);
        }

        private void OnLogoutUserDone(string response)
        {
            MessageBox.Show(response);

            button2.Enabled = true;
            button4.Enabled = false;
        }
    }
}
