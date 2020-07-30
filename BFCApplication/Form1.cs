using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Mail;
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

            label7.Visible = true;
            label7.Text = "Not logged in";
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
                //MessageBox.Show("ID: " + response.ID);

                button2.Enabled = false;
                button4.Enabled = true;

                //Login labels response 
                label4.Text = "ID: " + response.ID;
                label5.Text = "Username: " + response.Username;
                label6.Text = "Mail: " + response.Mail;
                label7.Text = "Rank: " + response.Rank;

                //Making login labels visible 
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                
            }
        }

        private void OnFetchUserDone(ServerResponse response)
        {
            /*MessageBox.Show(response.Status);
            MessageBox.Show(response.Username);
            MessageBox.Show(response.ID);
            MessageBox.Show(response.Mail);
            MessageBox.Show(response.Rank);*/

            //Fetch Label responses
            id_label.Text = "ID: " + response.ID;
            name_label.Text = "Username: " + response.Username;
            email_label.Text = "Email: " + response.Mail;
            rank_label.Text = "Rank: " + response.Rank;

            //Making Fetch Label visible 
            id_label.Visible = true;
            name_label.Visible = true;
            email_label.Visible = true;
            rank_label.Visible = true;
        }

        private void OnLogoutUserDone(ServerResponse response)
        {
            MessageBox.Show(response.Status);

            button2.Enabled = true;
            button4.Enabled = false;

            //Fetch labels
            id_label.Visible = false;
            name_label.Visible = false;
            email_label.Visible = false;
            rank_label.Visible = false;
            
            //Login labels
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            //Not logged in label
            label7.Text = "Not logged in";
        }
    }
}
