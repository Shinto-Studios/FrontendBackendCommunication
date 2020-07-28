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

namespace BackendFrontendCommunication
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
            apiRequest.RegisterUser(textBox1.Text, textBox2.Text, OnRegisterUserDone);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            apiRequest.LoginUser(textBox1.Text, textBox2.Text, OnLoginUserDone);
        }

        private void OnRegisterUserDone(string response)
        {
            MessageBox.Show("Respons: " + response);
        }

        private void OnLoginUserDone(string response)
        {
            MessageBox.Show("Respons Login: " + response);
        }
    }
}
