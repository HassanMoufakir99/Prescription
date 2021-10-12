using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace prescription.Pre_Layer
{
    public partial class Form_BackUp: Form
    {
        // this for move form
        int p0;
        int x;
        int y;
        string dbName;
       
       SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hassan\Desktop\c sharp jeux\prescription\prescription\DbPrescription.mdf;Integrated Security=True");
        SqlCommand cmd;
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hassan\Desktop\c sharp jeux\prescription\prescription\DbPrescription.mdf
        public Form_BackUp()
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
            Pre_Layer.Form_Home f = new Form_Home();
            f.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            var rs = f.ShowDialog();
            if(rs==DialogResult.OK)
            {
                dbName = f.FileName;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                dbName = f.SelectedPath;
            }
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                txt_FileName.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void bunifuImageButton1_Click_2(object sender, EventArgs e)
        {            
            string filename = txt_FileName.Text + "\\DbPrescription"+DateTime.Now.ToShortDateString().Replace('/','-')
                +"-"+DateTime.Now.ToShortTimeString().Replace(':','-');
            string qr = "BACKUP DATABASE ["+dbName+"] To Disk='" + filename+".bak'";
            cmd = new SqlCommand(qr, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم النسخ الاحتياطي بنجاح");
        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
   
        }

        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
