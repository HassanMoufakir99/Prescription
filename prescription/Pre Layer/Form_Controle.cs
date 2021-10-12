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
    public partial class Form_Controle: Form
    {
        // this for move form
        int p0;
        int x;
        int y;
        // instance from class
       
        Bis_Layer.CLS_Treat bl = new Bis_Layer.CLS_Treat();
        public string user_state;
        public Form_Controle()
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

       

        private void Form_Controle_Load(object sender, EventArgs e)
        {
            pn_option.BringToFront();
            if (user_state=="مدير")
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            if (Side_bar.Width==65)
            {
                Side_bar.Width = 230;
            }
            else
            {
                Side_bar.Width = 65;
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Pre_Layer.Form_Home f = new Form_Home();
            f.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            // for impramant tretments
            if (txt_dep.Text=="" || txt_docdes.Text=="" || txt_height.Text=="" || txt_name.Text=="" || txt_othersdes.Text=="" || txt_phone.Text=="" || txt_title.Text=="" || txt_width.Text=="")
            {
                label10.Text = "اكمل متطلبات الادخال ";
                bunifuTransition1.ShowSync(panel2);
            }
            else
            {
                Properties.Settings.Default.width =Convert.ToInt16( txt_width.Text);
                Properties.Settings.Default.height = Convert.ToInt16(txt_height.Text);
                Properties.Settings.Default.name = txt_name.Text;
                Properties.Settings.Default.dep = txt_dep.Text;
                Properties.Settings.Default.docdes = txt_docdes.Text;
                Properties.Settings.Default.title = txt_title.Text;
                Properties.Settings.Default.phone = txt_phone.Text;
                Properties.Settings.Default.othersdes = txt_othersdes.Text;
                Properties.Settings.Default.Save();
                label10.Text = "تم الحفظ بنجاح";
                bunifuTransition1.ShowSync(panel2);
                
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Form_Print f = new Form_Print();
            f.Show();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void pn_treatments_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pn_option.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pn_treatments.BringToFront();
        }

        private void Form_Controle_Activated(object sender, EventArgs e)
        {
            // load tretments
            DataTable dt1 = new DataTable();
            dt1 = bl.loadTreat();
            dgv_treat.DataSource = dt1;
            dgv_treat.Columns[0].HeaderText = "التسلسل";
            dgv_treat.Columns[1].HeaderText = "اسم العلاج";
            // load Patents
            DataTable dt2 = new DataTable();
            dt2 = bl.loadPatents();
            dgv_pat.DataSource = dt2;
            dgv_pat.Columns[0].HeaderText = "التسلسل";
            dgv_pat.Columns[1].HeaderText = "اسم المريض";
            dgv_pat.Columns[2].HeaderText = "عمر المريض";
            dgv_pat.Columns[3].HeaderText = "جنس المريض";
            // Load users
            DataTable dt3 = new DataTable();
            dt3 = bl.loadUsers();
            dgv_Users.DataSource = dt3;
            dgv_Users.Columns[0].HeaderText = "التسلسل";
            dgv_Users.Columns[1].HeaderText = "الاسم الكامل";
            dgv_Users.Columns[2].HeaderText = "اسم المستخدم";
            dgv_Users.Columns[3].HeaderText = "كلمة السر";
            dgv_Users.Columns[4].HeaderText = "الصلاحية";
            dgv_Users.Columns[5].HeaderText = "حالة الدخول";
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click_1(object sender, EventArgs e)
        {
            // Add tretments
            try
            {
                if (txt_insert_treat.Text != dgv_treat.CurrentRow.Cells[1].Value.ToString())
                {
                    bl.insert_treat(txt_insert_treat.Text);
                    MessageBox.Show("تمت عملية الاضافة بنجاح");
                }
                else
                {
                    MessageBox.Show("العلاج موجود");
                }

            }
            catch (Exception ex)
            {

               MessageBox.Show( ex.Message);
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            // Delete tretments
            try
            {
                bl.delete_treat(Convert.ToInt16( dgv_treat.CurrentRow.Cells[0].Value));
                MessageBox.Show("تمت عملية الحذف بنجاح");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_treat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var st= dgv_treat.CurrentRow.Cells[1].Value ;
            txt_insert_treat.Text = st.ToString();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            // Update tretments
            try
            {
                bl.Update_treat(txt_insert_treat.Text,Convert.ToInt16(dgv_treat.CurrentRow.Cells[0].Value));
                MessageBox.Show("تمت عملية التعديل بنجاح");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txt_insert_treat_TextChanged(object sender, EventArgs e)
        {
            // search tretments
            DataTable dt = new DataTable();
            dt = bl.Rechrcher_Treat(txt_insert_treat.Text);
            dgv_treat.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pn_prescription.BringToFront();
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            // Delete Patents
            try
            {
                bl.delete_Pat(Convert.ToInt16(dgv_pat.CurrentRow.Cells[0].Value));
                MessageBox.Show("تمت عملية الحذف بنجاح");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txt_pat_TextChanged(object sender, EventArgs e)
        {
            // search Patents
            DataTable dt3 = new DataTable();
            dt3 = bl.Rechrcher_Patients(txt_pat.Text);
            dgv_pat.DataSource = dt3;

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            // search treat for Patents
            Form_Print f = new Form_Print();
            DataTable dt3 = new DataTable();
            dt3 = bl.Load_Treat_Pat(Convert.ToInt16(dgv_pat.CurrentRow.Cells[0].Value));
            f.dgv_print.DataSource = dt3;
            f.dgv_print.Columns[0].HeaderText = "اسم العلاج";
            f.dgv_print.Columns[1].HeaderText = "كل";
            f.dgv_print.Columns[2].HeaderText = "لمدة";
            f.dgv_print.Columns[3].HeaderText = "الوقت";
            f.txt_name.Text = dgv_pat.CurrentRow.Cells[1].Value.ToString();
            f.txt_age.Text = dgv_pat.CurrentRow.Cells[2].Value.ToString();
            f.txt_type.Text = dgv_pat.CurrentRow.Cells[3].Value.ToString();
            f.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pn_user.BringToFront();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            try
            {
                if (Lb_Name.Text != dgv_Users.CurrentRow.Cells[1].Value.ToString() )
                {
                    bl.insert_Users(Lb_Name.Text,Lb_Users.Text,Lb_PassWord.Text,Lb_Roll.Text,"false");
                MessageBox.Show("تمت عملية الاضافة بنجاح");
                }
                else
                {
                    MessageBox.Show("المستخدم موجود");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            bl.Update_Users(Convert.ToInt16( dgv_Users.CurrentRow.Cells[0].Value),Lb_Name.Text, Lb_Users.Text, Lb_PassWord.Text, Lb_Roll.Text);
            MessageBox.Show("تمت عملية التعديل بنجاح");
        }

        private void dgv_Users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Lb_Name.Text = dgv_Users.CurrentRow.Cells[1].Value.ToString();
            Lb_Users.Text = dgv_Users.CurrentRow.Cells[2].Value.ToString();
            Lb_PassWord.Text = dgv_Users.CurrentRow.Cells[3].Value.ToString();
            Lb_Roll.Text = dgv_Users.CurrentRow.Cells[4].Value.ToString();
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            bl.delete_User(Convert.ToInt16(dgv_Users.CurrentRow.Cells[0].Value));
            MessageBox.Show("تمت عملية الحذف بنجاح");
            Lb_Name.Text = "";
            Lb_Users.Text = "";
            Lb_PassWord.Text = "";
            Lb_Roll.Text = "";
        }

        private void dgv_Users_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
       
        }
    }
}
