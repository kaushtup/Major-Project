using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadFromCsv
{
    public partial class ConfusionMatrix : Form
    {
        public ConfusionMatrix()
        {
            InitializeComponent();
        }

        confusionmatrix blu = new confusionmatrix();

        int TP = 0;
        int FP = 0;
        int TN = 0;
        int FN = 0;
        private void btntest_Click(object sender, EventArgs e)
        {
                
            DataTable dt = blu.GetTestData();
            int total = dt.Rows.Count;
            string claim;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                decimal prob_yes = blu.classify_yes(row["Zone"].ToString(), Convert.ToInt32(row["LotNo"].ToString()), Convert.ToInt32(row["YearManufacture"].ToString()), row["TypeCover"].ToString(), row["CompanyName"].ToString(), Convert.ToDecimal(row["CCHP"].ToString()));
                decimal prob_no = blu.classify_no(row["Zone"].ToString(), Convert.ToInt32(row["LotNo"].ToString()), Convert.ToInt32(row["YearManufacture"].ToString()), row["TypeCover"].ToString(), row["CompanyName"].ToString(), Convert.ToDecimal(row["CCHP"].ToString()));
                if (prob_yes > prob_no)
                {
                    claim = "Yes";
                }
                else
                {
                    claim = "No";
                }
                Test(claim, row["Claim"].ToString());
                lblFN.Text = FN.ToString();
                lblFP.Text = FP.ToString();
                lblTN.Text = TN.ToString();
                lblTP.Text = TP.ToString();
                label6.Text = string.Format("Iteration is :{0}", i);
                label6.Update();
                lblFN.Update();
                lblFP.Update();
                lblTN.Update();
                lblTP.Update();

                //System.Threading.Thread.Sleep(100);
                i++;
            }
            decimal accuracy = (Convert.ToDecimal(TP + TN) / Convert.ToDecimal(TN + TP + FP + FN))*100;
            System.Math.Round(accuracy, 2);
            lblAccuracy.Text = accuracy.ToString();
            MessageBox.Show("Testing Completed.");

        }


       
        public void Test(string calculate_claim, string actual_claim)
            {
                if (string.Compare(calculate_claim,"Yes") == 0 && string.Compare(actual_claim,"Yes") ==0)
                {
                        TP++;
                }
                else if(string.Compare(calculate_claim, "Yes") == 0 && string.Compare(actual_claim, "No") == 0)
                {
                         FP++;
                }
              
                else if (string.Compare(calculate_claim, "No") == 0 && string.Compare(actual_claim, "Yes") == 0)
                {
                        FN++;
                }

                else if (string.Compare(calculate_claim, "No") == 0 && string.Compare(actual_claim, "No") == 0)
                {
                        TN++;
                }
              

                
                 
        }

        private void ConfusionMatrix_Load(object sender, EventArgs e)
        {

        }
    }
}
