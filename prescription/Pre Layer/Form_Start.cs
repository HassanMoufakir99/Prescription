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
    public partial class Form_Start : Form
    {
        Bis_Layer.Cls_Users user = new Bis_Layer.Cls_Users();
        public Form_Start()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = user.load_Start();
                if (dt.Rows.Count > 0)
                {
                    object ob = dt.Rows[0][0];
                    int ID = Convert.ToInt32(ob);
                    object name = dt.Rows[0][1];
                    object Roll = dt.Rows[0][4];

                    user.Update_State(ID);
                    Pre_Layer.Form_Home f = new Form_Home();
                    f.txt_doc_Name.Text = "د." + name.ToString();
                    f.txt_doc_Name2.Text = name.ToString();
                    f.txt_doc_roll.Text = Roll.ToString();
                    Properties.Settings.Default.username = "د." + name.ToString();
                    Properties.Settings.Default.roll = Roll.ToString();
                    Properties.Settings.Default.Save();
                    f.Show();
                    this.Hide();
                    timer1.Enabled = false;

                }
                else
                {
                    Pre_Layer.Form_Login flog = new Form_Login();
                    flog.Show();
                    this.Hide();
                    timer1.Enabled = false;
                }
            }
            catch 
            {
                
               
            }
        }
    }
}
