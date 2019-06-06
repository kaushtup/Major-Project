using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class confusionmatrix
    {

        public DataTable GetTestData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  *from tblTestingSet", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable ReadCsv(string filename)
        {
            DataTable dt = new DataTable("Data");


            using (OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" +
                    Path.GetDirectoryName(filename) + "\";Extended Properties='text;HDR=yes;FMT=Delimited(,)';"))
            {
                using (OleDbCommand cmd = new OleDbCommand(string.Format("select * from [{0}]", new FileInfo(filename).Name), cn))
                {
                    cn.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;

        }

        public decimal classify_yes(string Zone, int LotNo, int YearManufacture, string TypeCover, string CompanyName, decimal CCHP)
        {
            decimal prob_zone = 0, prob_lotno = 0, prob_ym = 0, prob_type = 0, prob_cm = 0, prob_cchp = 0, prior_prob_yes = 0;
            DataTable dt = ReadCsv("C:/Users/Kaushtup Bista/Desktop/probability_yes.txt");
            string zone_name = $"prob_Zone_{Zone}_yes";
            string lotno_name = classifylotno(LotNo);
            string ym_name = classifyym(YearManufacture);
            string type_name = $"prob_TC_{TypeCover}_yes";
            string company_name = $"prob_CN_{CompanyName}_yes";
            string cc_name = classifycchp(CCHP);
            decimal prob_yes = Convert.ToDecimal(dt.Rows[0][1].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == zone_name)
                {
                    prob_zone = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
                if (dt.Rows[i][0].ToString() == lotno_name)
                {
                    prob_lotno = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
                if (dt.Rows[i][0].ToString() == ym_name)
                {
                    prob_ym = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
                if (dt.Rows[i][0].ToString() == type_name)
                {
                    prob_type = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
                if (dt.Rows[i][0].ToString() == company_name)
                {
                    prob_cm = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
                if (dt.Rows[i][0].ToString() == cc_name)
                {
                    prob_cchp = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
            }
            prior_prob_yes = (prob_zone * prob_lotno * prob_ym * prob_type * prob_cm * prob_cchp * prob_yes);
            return prior_prob_yes;
        }

        public string classifylotno(int LN)
        {
            string lot_name;
            if (LN < 10)
            {
                lot_name = "prob_LotNo_LT10_yes";
            }
            else if (LN >= 10 && LN < 20)
            {
                lot_name = "prob_LotNo_10T20_yes";
            }
            else if (LN >= 20 && LN < 30)
            {
                lot_name = "prob_LotNo_20T30_yes";
            }
            else if (LN >= 30 && LN < 40)
            {
                lot_name = "prob_LotNo_30T40_yes";
            }
            else if (LN >= 40 && LN < 50)
            {
                lot_name = "prob_LotNo_40T50_yes";
            }
            else if (LN >= 50 && LN < 60)
            {
                lot_name = "prob_LotNo_50T60_yes";
            }
            else if (LN >= 60 && LN < 70)
            {
                lot_name = "prob_LotNo_60T70_yes";
            }
            else if (LN >= 70 && LN < 80)
            {
                lot_name = "prob_LotNo_70T80_yes";
            }
            else
            {
                lot_name = "prob_LotNo_GT80_yes";
            }
            return lot_name;
        }

        public string classifyym(int YM)
        {
            string year_name;
            if (YM < 2010)
            {
                year_name = "prob_YM_LT2010_yes";
            }
            else if (YM > 2015)
            {
                year_name = "prob_YM_GT2015_yes";
            }
            else
            {
                year_name = "prob_YM_2010T2015_yes";
            }
            return year_name;
        }



        public string classifycchp(decimal CCN)
        {
            string cchp_name;
            if (CCN < 100)
            {
                cchp_name = "prob_CCHP_LT100_yes";
            }
            else if (CCN >= 100 && CCN < 125)
            {
                cchp_name = "prob_CCHP_100T125_yes";
            }
            else if (CCN >= 125 && CCN < 150)
            {
                cchp_name = "prob_CCHP_125T150_yes";
            }
            else
            {
                cchp_name = "prob_CCHP_GT150_yes";
            }
            return cchp_name;
        }




        public decimal classify_no(string Zone, int LotNo, int YearManufacture, string TypeCover, string CompanyName, decimal CCHP)
        {
            decimal prob_zone = 0, prob_lotno = 0, prob_ym = 0, prob_type = 0, prob_cm = 0, prob_cchp = 0, prior_prob_no = 0;
            DataTable dt = ReadCsv("C:/Users/Kaushtup Bista/Desktop/probability_no.txt");
            string zone_name = $"prob_Zone_{Zone}_no";
            string lotno_name = classifylotnono(LotNo);
            string ym_name = classifyymno(YearManufacture);
            string type_name = $"prob_TC_{TypeCover}_no";
            string company_name = $"prob_CN_{CompanyName}_no";
            string cc_name = classifycchpno(CCHP); 
            decimal prob_no = Convert.ToDecimal(dt.Rows[0][1].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == zone_name)
                {
                    prob_zone = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
                if (dt.Rows[i][0].ToString() == lotno_name)
                {
                    prob_lotno = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
                if (dt.Rows[i][0].ToString() == ym_name)
                {
                    prob_ym = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
                if (dt.Rows[i][0].ToString() == type_name)
                {
                    prob_type = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
                if (dt.Rows[i][0].ToString() == company_name)
                {
                    prob_cm = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
                if (dt.Rows[i][0].ToString() == cc_name)
                {
                    prob_cchp = Convert.ToDecimal(dt.Rows[i][1].ToString());
                }
            }
            prior_prob_no = (prob_zone * prob_lotno * prob_ym * prob_type * prob_cm * prob_cchp * prob_no);
            return prior_prob_no;
        }



        public string classifylotnono(int LN)
        {
            string lot_name;
            if (LN < 10)
            {
                lot_name = "prob_LotNo_LT10_no";
            }
            else if (LN >= 10 && LN < 20)
            {
                lot_name = "prob_LotNo_10T20_no";
            }
            else if (LN >= 20 && LN < 30)
            {
                lot_name = "prob_LotNo_20T30_no";
            }
            else if (LN >= 30 && LN < 40)
            {
                lot_name = "prob_LotNo_30T40_no";
            }
            else if (LN >= 40 && LN < 50)
            {
                lot_name = "prob_LotNo_40T50_no";
            }
            else if (LN >= 50 && LN < 60)
            {
                lot_name = "prob_LotNo_50T60_no";
            }
            else if (LN >= 60 && LN < 70)
            {
                lot_name = "prob_LotNo_60T70_no";
            }
            else if (LN >= 70 && LN < 80)
            {
                lot_name = "prob_LotNo_70T80_no";
            }
            else
            {
                lot_name = "prob_LotNo_GT80_no";
            }
            return lot_name;
        }

        public string classifyymno(int YM)
        {
            string year_name;
            if (YM < 2010)
            {
                year_name = "prob_YM_LT2010_no";
            }
            else if (YM > 2015)
            {
                year_name = "prob_YM_GT2015_no";
            }
            else
            {
                year_name = "prob_YM_2010T2015_no";
            }
            return year_name;
        }



        public string classifycchpno(decimal CCN)
        {
            string cchp_name;
            if (CCN < 100)
            {
                cchp_name = "prob_CCHP_LT100_no";
            }
            else if (CCN >= 100 && CCN < 125)
            {
                cchp_name = "prob_CCHP_100T125_no";
            }
            else if (CCN >= 125 && CCN < 150)
            {
                cchp_name = "prob_CCHP_125T150_no";
            }
            else
            {
                cchp_name = "prob_CCHP_GT150_no";
            }
            return cchp_name;
        }



      
    }
}
