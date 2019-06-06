using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadFromCsv
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {


            foreach (Form frm in this.MdiChildren)
            {
                if (!frm.Focused)
                {
                    frm.Visible = false;
                    frm.Dispose();
                }
            }

            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Form1")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                Form1 frm1 = new Form1();
                frm1.MdiParent = this;
                frm1.Show();
                frm1.WindowState = FormWindowState.Maximized;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {


            foreach (Form frm in this.MdiChildren)
            {
                if (!frm.Focused)
                {
                    frm.Visible = false;
                    frm.Dispose();
                }
            }

            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "TrainData")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                TrainData frm1 = new TrainData();
                frm1.MdiParent = this;
                frm1.Show();
                frm1.WindowState = FormWindowState.Maximized;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {


            foreach (Form frm in this.MdiChildren)
            {
                if (!frm.Focused)
                {
                    frm.Visible = false;
                    frm.Dispose();
                }
            }

            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "TestData")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                TestData frm1 = new TestData();
                frm1.MdiParent = this;
                frm1.Show();
                frm1.WindowState = FormWindowState.Maximized;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (!frm.Focused)
                {
                    frm.Visible = false;
                    frm.Dispose();
                }
            }

            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "ConfusionMatrix")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                ConfusionMatrix frm1 = new ConfusionMatrix();
                frm1.MdiParent = this;
                frm1.Show();
                frm1.WindowState = FormWindowState.Maximized;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    }
