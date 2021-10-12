using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prescription
{
    public partial class Form_Print : Form
    {
        public Form_Print()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form_Print_Activated(object sender, EventArgs e)
        {

           pn_sheet.Width= Properties.Settings.Default.width;
           pn_sheet.Height= Properties.Settings.Default.height;
           txt_doc.Text= Properties.Settings.Default.name;
            txt_dep.Text=Properties.Settings.Default.dep;
            txt_docdesc.Text=Properties.Settings.Default.docdes;
            txt_title.Text=Properties.Settings.Default.title;
            txt_phone.Text=Properties.Settings.Default.phone;
            txt_otherdesc.Text=Properties.Settings.Default.othersdes; 
            
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap img = new Bitmap(pn_sheet.Width,pn_sheet.Height);
            pn_sheet.DrawToBitmap(img, new Rectangle(Point.Empty, pn_sheet.Size));
            e.Graphics.DrawImage(img, 0, 0);
        }
    }
}
