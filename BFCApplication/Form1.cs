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

            label7.Visible = true;
            label7.Text = "Not logged in";

            button4.Visible = false;
            button6.Visible = false;

            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
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

        private void button5_Click(object sender, EventArgs e)
        {

            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;

            button6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            apiRequest.ChangeUserInfo(textBox4.Text, textBox5.Text, textBox6.Text, OnSaveUserChanges);
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
                //button2.Enabled = false;
                button2.Visible = false; 
                button4.Enabled = true;
                button4.Visible = true;
                button1.Visible = false;

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

        private void OnChangeUserSettingsDone(ServerResponse response)
        {
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;

            button6.Visible = true;
        }

        private void OnSaveUserChanges(ServerResponse response)
        {
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            button6.Visible = false;
        }

        private void OnLogoutUserDone(ServerResponse response)
        {
            MessageBox.Show(response.Status);

            button2.Enabled = true;
            button4.Enabled = false;
            button2.Visible = true;
            button4.Visible = false;
            button1.Visible = true;

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
