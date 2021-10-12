using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prescription.Pre_Layer
{
    public partial class Form_Login: Form
    {
        // this for move form
        int p0;
        int x;
        int y;
        Bis_Layer.Cls_Users user = new Bis_Layer.Cls_Users();
        public Form_Login()
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
            f.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Pre_Layer.Form_Controle f = new Form_Controle();
            f.Show();
            this.Hide();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            if(txt_UserName.Text=="" || txt_PassWord.Text=="")
            {
                MessageBox.Show("اكمل معلومات تسجيل الدخول");
            }
            else
            {
                try
                {

                DataTable dt = new DataTable();
                dt = user.Load_Login(txt_UserName.Text, txt_PassWord.Text);
                if (dt.Rows.Count>0)
                {
                        object ob = dt.Rows[0][0];
                        int ID = Convert.ToInt32(ob);
                        object name = dt.Rows[0][1];
                        object Roll = dt.Rows[0][4];
                       
                        user.Update_State(ID);
                        Pre_Layer.Form_Home f = new Form_Home();
                        f.txt_doc_Name.Text ="د."+ name.ToString();
                        f.txt_doc_Name2.Text = name.ToString();
                        f.txt_doc_roll.Text = Roll.ToString();
                       Properties.Settings.Default.username = "د." + name.ToString();
                        Properties.Settings.Default.roll = Roll.ToString();
                        Properties.Settings.Default.Save();
                        f.Show();
                    this.Hide();

                }
                    else
                    {
                        MessageBox.Show("خطأ في معلومات تسجيل الدخول");
                    }   
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
        }
    }
}
