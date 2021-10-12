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
    public partial class Form_Writepres: Form
    {
        // this for move form
        int p0;
        int x;
        int y;
        // instant class
        Bis_Layer.CLS_Pres BlPres = new Bis_Layer.CLS_Pres();
        Bis_Layer.CLS_Treat bl = new Bis_Layer.CLS_Treat();
        public Form_Writepres()
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pn_pat_treat_info_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Pre_Layer.Form_Home f = new Form_Home();
            f.Show();
            this.Close();
        }

        private void Form_Writepres_Load(object sender, EventArgs e)
        {
            pn_pat_treat_info.BringToFront();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (txt_name.Text=="" || txt_name.Text=="" || combo_type.Text=="")
            {
                MessageBox.Show("اكمل متطلبات الادخال اولا ");
            }
            else
            {
                BlPres.insert_Pat_info(txt_name.Text,Convert.ToInt16( txt_age.Text), combo_type.Text);
               pn_pat_treat_info.BringToFront();
                txt_name.Text = "";
                txt_name.Text = "";
                combo_type.Text = "";
            }
            
        }

        private void Form_Writepres_Activated(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = BlPres.loadTreat();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                coll.Add(row[0].ToString());
            }
            txt_treat_name.AutoCompleteCustomSource = coll;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //|| combo_treat_All.Text=="" || txt_treat_Dur.Text=="" || combo_Treat_Time.Text==""
            if (txt_treat_name.Text=="" )
            {
                MessageBox.Show("رجاءا اتمم متطلبت العلاج ");
            }
            else
            {
                DataTable dt2 = new DataTable();
                dt2 = bl.loadPatents();
                int lastrow = dt2.Rows.Count-1;
                object ob1 = dt2.Rows[lastrow][0];
                int Patients_ID = Convert.ToInt32(ob1);
                BlPres.insert_Treat(Patients_ID, txt_treat_name.Text, combo_treat_All.Text, txt_treat_Dur.Text, combo_Treat_Time.Text);
                txt_treat_name.Text = combo_treat_All.Text = txt_treat_Dur.Text = combo_Treat_Time.Text="";
                MessageBox.Show("تمت الاضافة  العلاج بنجاح ");
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2 = bl.loadPatents();
            int Pat_ID;
            string Pat_Name;
            int Pat_Age;
            string Pat_type;
            int lastrow = dt2.Rows.Count - 1;
            object ob1 = dt2.Rows[lastrow][0];
            object ob2 = dt2.Rows[lastrow][1];
            object ob3 = dt2.Rows[lastrow][2];
            object ob4 = dt2.Rows[lastrow][3];
            Pat_ID = Convert.ToInt32(ob1);
            Pat_Name = Convert.ToString(ob2);
            Pat_Age = Convert.ToInt32(ob3);
            Pat_type = Convert.ToString(ob4);

            // search treat for Patents
            Form_Print f = new Form_Print();
            DataTable dt3 = new DataTable();
            dt3 = bl.Load_Treat_Pat(Convert.ToInt16(Pat_ID));
            f.dgv_print.DataSource = dt3;
            f.dgv_print.Columns[0].HeaderText = "اسم العلاج";
            f.dgv_print.Columns[1].HeaderText = "كل";
            f.dgv_print.Columns[2].HeaderText = "لمدة";
            f.dgv_print.Columns[3].HeaderText = "الوقت";
            f.txt_name.Text = Pat_Name;
            f.txt_age.Text = Pat_Age.ToString();
            f.txt_type.Text = Pat_type.ToString();
            f.Show();
            txt_treat_name.Text = combo_treat_All.Text = txt_treat_Dur.Text = combo_Treat_Time.Text = "";
            pn_pat_info.BringToFront();

        }
    }
}
