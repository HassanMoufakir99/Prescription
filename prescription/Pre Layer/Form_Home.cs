using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace prescription.Pre_Layer
{
    public partial class Form_Home : Form
    {
        // this for move form
        int p0;
        int x;
        int y;
        Bis_Layer.Cls_Users us = new Bis_Layer.Cls_Users();
        public Form_Home()
        {
            InitializeComponent();
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Pre_Layer.Form_Writepres f = new Form_Writepres();
            f.Show();
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (WindowState==FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            p0 = 1;
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            p0 = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (p0==1)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Black;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Transparent;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Black;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Transparent;
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Black;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Transparent;
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Pre_Layer.Form_Controle f = new Form_Controle();
            f.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Pre_Layer.Form_Controle f = new Form_Controle();
            f.user_state = txt_doc_roll.Text;
            f.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Pre_Layer.Form_Controle f = new Form_Controle();
            f.Show();
            this.Hide();
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Black;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Transparent;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Black;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Transparent;
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Black;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Transparent;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Pre_Layer.Form_Writepres f = new Form_Writepres();
            f.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Pre_Layer.Form_Writepres f = new Form_Writepres();
            f.Show();
            this.Hide();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Pre_Layer.Form_BackUp f = new Form_BackUp();
            f.Show();
            this.Hide();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            


        }

        private void bunifuImageButton5_Click_1(object sender, EventArgs e)
        {
           

        }

        private void bunifuImageButton5_Click_2(object sender, EventArgs e)
        {
            us.Logout();
            Pre_Layer.Form_Login f = new Form_Login();
            f.Show();
            this.Hide();

        }

        private void Form_Home_Load(object sender, EventArgs e)
        {
            txt_doc_Name.Text = Properties.Settings.Default.username;
            txt_doc_Name2.Text = Properties.Settings.Default.username;
            txt_doc_roll.Text = Properties.Settings.Default.roll;
            if (txt_doc_roll.Text=="مدير")
            {
                panel5.Enabled = true;
            }
            else
            {
                panel5.Enabled = false;
            }
        }
    }
}
