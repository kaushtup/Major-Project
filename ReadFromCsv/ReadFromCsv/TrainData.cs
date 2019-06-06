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
using System.Xml;

namespace ReadFromCsv
{
    public partial class TrainData : Form
    {
        public TrainData()
        {
            InitializeComponent();
        }
        Train blu = new Train();
        SendInfo si = new SendInfo();
        private void btnTrain_Click(object sender, EventArgs e)
        {
            DataTable dt = blu.GetTrainData();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Claim"].ToString() == "Yes")
                {
                    blu.CreateClaimData(row["Zone"].ToString(), Convert.ToInt32(row["LotNo"].ToString()), Convert.ToInt32(row["YearManufacture"].ToString()), row["TypeCover"].ToString(), row["CompanyName"].ToString(), Convert.ToDecimal(row["CCHP"].ToString()));
                }
                if (row["Claim"].ToString() == "No")
                {
                    blu.CreateUnClaimData(row["Zone"].ToString(), Convert.ToInt32(row["LotNo"].ToString()), Convert.ToInt32(row["YearManufacture"].ToString()), row["TypeCover"].ToString(), row["CompanyName"].ToString(), Convert.ToDecimal(row["CCHP"].ToString()));
                }


            }
            MessageBox.Show("Data Successfully Trained.");
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            prob_Claim();
            writeAllClaim();
            prob_UnClaim();
            writeAllUnClaim();
            MessageBox.Show("Probability Result Successfully Stored");



        }

        decimal prob_yes, prob_Zone_ME_yes, prob_Zone_KO_yes, prob_Zone_SA_yes, prob_Zone_JA_yes, prob_Zone_BA_yes, prob_Zone_NA_yes, prob_Zone_GA_yes, prob_Zone_LU_yes, prob_Zone_DH_yes, prob_Zone_RA_yes, prob_Zone_BHE_yes, prob_Zone_KA_yes, prob_Zone_SE_yes, prob_Zone_MA_yes, prob_LotNo_LT10_yes, prob_LotNo_10T20_yes, prob_LotNo_20T30_yes, prob_LotNo_30T40_yes, prob_LotNo_40T50_yes, prob_LotNo_50T60_yes, prob_LotNo_60T70_yes, prob_LotNo_70T80_yes, prob_LotNo_GT80_yes, prob_YM_LT2010_yes, prob_YM_2010T2015_yes, prob_YM_GT2015_yes, prob_TC_CM_yes, prob_TC_TP_yes, prob_CN_Yamaha_yes, prob_CN_RoyalEnfield_yes, prob_CN_Honda_yes, prob_CN_Hero_yes, prob_CN_HeroHonda_yes, prob_CN_Bajaj_yes, prob_CN_TVS_yes, prob_CN_Suzuki_yes, prob_CN_Mahindra_yes, prob_CN_KTM_yes, prob_CCHP_LT100_yes, prob_CCHP_100T125_yes, prob_CCHP_125T150_yes, prob_CCHP_GT150_yes;

        private void TrainData_Load(object sender, EventArgs e)
        {

        }

        int yes;
        int yes_total;

        public void prob_Claim()
        {
            DataTable dt = blu.GetClaimData();
            DataTable dt1 = si.GetAllTrainingData();
            yes_total = dt1.Rows.Count;
            yes = dt.Rows.Count;

            //probability of claim

            prob_yes = (decimal)yes / (decimal)yes_total; 
            //probability of zones
            prob_Zone_ME_yes = (blu.CalculateClaim("Zone", "ME"));
            prob_Zone_KO_yes = (blu.CalculateClaim("Zone", "KO"));
            prob_Zone_SA_yes = (blu.CalculateClaim("Zone", "SA"));
            prob_Zone_JA_yes = (blu.CalculateClaim("Zone", "JA"));
            prob_Zone_BA_yes = (blu.CalculateClaim("Zone", "BA"));
            prob_Zone_NA_yes = (blu.CalculateClaim("Zone", "NA"));
            prob_Zone_GA_yes = (blu.CalculateClaim("Zone", "GA"));
            prob_Zone_LU_yes = (blu.CalculateClaim("Zone", "LU"));
            prob_Zone_DH_yes = (blu.CalculateClaim("Zone", "DH"));
            prob_Zone_RA_yes = (blu.CalculateClaim("Zone", "RA"));
            prob_Zone_BHE_yes = (blu.CalculateClaim("Zone", "BHE"));
            prob_Zone_KA_yes = (blu.CalculateClaim("Zone", "KA"));
            prob_Zone_SE_yes = (blu.CalculateClaim("Zone", "SE"));
            prob_Zone_MA_yes = (blu.CalculateClaim("Zone", "MA"));

            //probability of LotNo
            prob_LotNo_LT10_yes = (blu.CalculateClaimLT("LotNo", 10));
            prob_LotNo_10T20_yes = (blu.CalculateClaimMV("LotNo", 10, 20));
            prob_LotNo_20T30_yes = (blu.CalculateClaimMV("LotNo", 20, 30));
            prob_LotNo_30T40_yes = (blu.CalculateClaimMV("LotNo", 30, 40));
            prob_LotNo_40T50_yes = (blu.CalculateClaimMV("LotNo", 40, 50));
            prob_LotNo_50T60_yes = (blu.CalculateClaimMV("LotNo", 50, 60));
            prob_LotNo_60T70_yes = (blu.CalculateClaimMV("LotNo", 60, 70));
            prob_LotNo_70T80_yes = (blu.CalculateClaimMV("LotNo", 70, 80));
            prob_LotNo_GT80_yes = (blu.CalculateClaimGT("LotNo", 80));

            //Probaility of YearManufacture
            prob_YM_LT2010_yes = (blu.CalculateClaimLT("YearManufacture", 2010));
            prob_YM_2010T2015_yes = (blu.CalculateClaimMV("YearManufacture", 2010, 2015));
            prob_YM_GT2015_yes = (blu.CalculateClaimGT("YearManufacture", 2015));
            

            //Probability of Type Cover
            prob_TC_CM_yes = (blu.CalculateClaim("TypeCover", "CM"));
            prob_TC_TP_yes = (blu.CalculateClaim("TypeCover", "TP"));

            //Probability of Company Name
            prob_CN_Yamaha_yes = (blu.CalculateClaim("CompanyName", "Yamaha"));
            prob_CN_RoyalEnfield_yes = (blu.CalculateClaim("CompanyName", "RoyalEnfield"));
            prob_CN_Honda_yes = (blu.CalculateClaim("CompanyName", "Honda"));
            prob_CN_Hero_yes = (blu.CalculateClaim("CompanyName", "Hero"));
            prob_CN_HeroHonda_yes = (blu.CalculateClaim("CompanyName", "HeroHonda"));
            prob_CN_Bajaj_yes = (blu.CalculateClaim("CompanyName", "Bajaj"));
            prob_CN_TVS_yes = (blu.CalculateClaim("CompanyName", "TVS"));
            prob_CN_Suzuki_yes = (blu.CalculateClaim("CompanyName", "Suzuki"));
            prob_CN_Mahindra_yes = (blu.CalculateClaim("CompanyName", "Mahindra"));
            prob_CN_KTM_yes = (blu.CalculateClaim("CompanyName", "KTM"));

            //Probability of CCHP
            prob_CCHP_LT100_yes = (blu.CalculateClaimLT("CCHP", 100));
            prob_CCHP_100T125_yes = (blu.CalculateClaimMV("CCHP", 100, 125));
            prob_CCHP_125T150_yes = (blu.CalculateClaimMV("CCHP", 125, 150));
            prob_CCHP_GT150_yes = (blu.CalculateClaimGT("CCHP", 150));
         }

        public void write_yes(string name, decimal value)
        {
            using (StreamWriter swExtLogFile = new StreamWriter("C:/Users/Kaushtup Bista/Desktop/probability_yes.txt", true))
            {
                swExtLogFile.WriteLine(name +","+ value.ToString());
               

            }
           

        }
        public void writeAllClaim()
        {
            write_yes("name", 0);
            write_yes("prob_yes", prob_yes);
            write_yes("prob_Zone_ME_yes", prob_Zone_ME_yes); 
            write_yes("prob_Zone_KO_yes", prob_Zone_KO_yes);
            write_yes("prob_Zone_SA_yes", prob_Zone_SA_yes);
            write_yes("prob_Zone_JA_yes", prob_Zone_JA_yes);
            write_yes("prob_Zone_BA_yes", prob_Zone_BA_yes);
            write_yes("prob_Zone_NA_yes", prob_Zone_NA_yes);
            write_yes("prob_Zone_GA_yes", prob_Zone_GA_yes);
            write_yes("prob_Zone_LU_yes", prob_Zone_LU_yes);
            write_yes("prob_Zone_DH_yes", prob_Zone_DH_yes);
            write_yes("prob_Zone_RA_yes", prob_Zone_RA_yes);
            write_yes("prob_Zone_BHE_yes", prob_Zone_BHE_yes);
            write_yes("prob_Zone_KA_yes", prob_Zone_KA_yes);
            write_yes("prob_Zone_SE_yes", prob_Zone_SE_yes);
            write_yes("prob_Zone_MA_yes", prob_Zone_MA_yes);
            write_yes("prob_LotNo_LT10_yes", prob_LotNo_LT10_yes);
            write_yes("prob_LotNo_10T20_yes", prob_LotNo_10T20_yes);
            write_yes("prob_LotNo_20T30_yes", prob_LotNo_20T30_yes);
            write_yes("prob_LotNo_30T40_yes", prob_LotNo_30T40_yes);
            write_yes("prob_LotNo_40T50_yes", prob_LotNo_40T50_yes);
            write_yes("prob_LotNo_50T60_yes", prob_LotNo_50T60_yes);
            write_yes("prob_LotNo_60T70_yes", prob_LotNo_60T70_yes);
            write_yes("prob_LotNo_70T80_yes", prob_LotNo_70T80_yes);
            write_yes("prob_LotNo_GT80_yes", prob_LotNo_GT80_yes);
            write_yes("prob_YM_LT2010_yes", prob_YM_LT2010_yes);
            write_yes("prob_YM_2010T2015_yes", prob_YM_2010T2015_yes);
            write_yes("prob_YM_GT2015_yes", prob_YM_GT2015_yes);
            write_yes("prob_TC_CM_yes", prob_TC_CM_yes);
            write_yes("prob_TC_TP_yes", prob_TC_TP_yes);
            write_yes("prob_CN_Yamaha_yes", prob_CN_Yamaha_yes);
            write_yes("prob_CN_RoyalEnfield_yes", prob_CN_RoyalEnfield_yes);
            write_yes("prob_CN_Honda_yes", prob_CN_Honda_yes);
            write_yes("prob_CN_Hero_yes", prob_CN_Hero_yes);
            write_yes("prob_CN_HeroHonda_yes", prob_CN_HeroHonda_yes);
            write_yes("prob_CN_Bajaj_yes", prob_CN_Bajaj_yes);
            write_yes("prob_CN_TVS_yes", prob_CN_TVS_yes);
            write_yes("prob_CN_Suzuki_yes", prob_CN_Suzuki_yes);
            write_yes("prob_CN_Mahindra_yes", prob_CN_Mahindra_yes);
            write_yes("prob_CN_KTM_yes", prob_CN_KTM_yes);
            write_yes("prob_CCHP_LT100_yes", prob_CCHP_LT100_yes);
            write_yes("prob_CCHP_100T125_yes", prob_CCHP_100T125_yes);
            write_yes("prob_CCHP_125T150_yes", prob_CCHP_125T150_yes);
            write_yes("prob_CCHP_GT150_yes", prob_CCHP_GT150_yes);
        }

        decimal prob_no, prob_Zone_ME_no, prob_Zone_KO_no, prob_Zone_SA_no, prob_Zone_JA_no, prob_Zone_BA_no, prob_Zone_NA_no, prob_Zone_GA_no, prob_Zone_LU_no, prob_Zone_DH_no, prob_Zone_RA_no, prob_Zone_BHE_no, prob_Zone_KA_no, prob_Zone_SE_no, prob_Zone_MA_no, prob_LotNo_LT10_no, prob_LotNo_10T20_no, prob_LotNo_20T30_no, prob_LotNo_30T40_no, prob_LotNo_40T50_no, prob_LotNo_50T60_no, prob_LotNo_60T70_no, prob_LotNo_70T80_no, prob_LotNo_GT80_no, prob_YM_LT2010_no, prob_YM_2010T2015_no, prob_YM_GT2015_no, prob_TC_CM_no, prob_TC_TP_no, prob_CN_Yamaha_no, prob_CN_RoyalEnfield_no, prob_CN_Honda_no, prob_CN_Hero_no, prob_CN_HeroHonda_no, prob_CN_Bajaj_no, prob_CN_TVS_no, prob_CN_Suzuki_no, prob_CN_Mahindra_no, prob_CN_KTM_no, prob_CCHP_LT100_no, prob_CCHP_100T125_no, prob_CCHP_125T150_no, prob_CCHP_GT150_no;
        int no;
        int no_total;

        public void prob_UnClaim()
        {
            DataTable dt = blu.GetUnClaimData();
            DataTable dt1 = si.GetAllTrainingData();
            no_total = dt1.Rows.Count;
            no = dt.Rows.Count;

            //probability of UnClaim

            prob_no = (decimal)no / (decimal)no_total;
            //probability of zones
            prob_Zone_ME_no = (blu.CalculateUnClaim("Zone", "ME"));
            prob_Zone_KO_no = (blu.CalculateUnClaim("Zone", "KO"));
            prob_Zone_SA_no = (blu.CalculateUnClaim("Zone", "SA"));
            prob_Zone_JA_no = (blu.CalculateUnClaim("Zone", "JA"));
            prob_Zone_BA_no = (blu.CalculateUnClaim("Zone", "BA"));
            prob_Zone_NA_no = (blu.CalculateUnClaim("Zone", "NA"));
            prob_Zone_GA_no = (blu.CalculateUnClaim("Zone", "GA"));
            prob_Zone_LU_no = (blu.CalculateUnClaim("Zone", "LU"));
            prob_Zone_DH_no = (blu.CalculateUnClaim("Zone", "DH"));
            prob_Zone_RA_no = (blu.CalculateUnClaim("Zone", "RA"));
            prob_Zone_BHE_no = (blu.CalculateUnClaim("Zone", "BHE"));
            prob_Zone_KA_no = (blu.CalculateUnClaim("Zone", "KA"));
            prob_Zone_SE_no = (blu.CalculateUnClaim("Zone", "SE"));
            prob_Zone_MA_no = (blu.CalculateUnClaim("Zone", "MA"));

            //probability of LotNo
            prob_LotNo_LT10_no = (blu.CalculateUnClaimLT("LotNo", 10));
            prob_LotNo_10T20_no = (blu.CalculateUnClaimMV("LotNo", 10, 20));
            prob_LotNo_20T30_no = (blu.CalculateUnClaimMV("LotNo", 20, 30));
            prob_LotNo_30T40_no = (blu.CalculateUnClaimMV("LotNo", 30, 40));
            prob_LotNo_40T50_no = (blu.CalculateUnClaimMV("LotNo", 40, 50));
            prob_LotNo_50T60_no = (blu.CalculateUnClaimMV("LotNo", 50, 60));
            prob_LotNo_60T70_no = (blu.CalculateUnClaimMV("LotNo", 60, 70));
            prob_LotNo_70T80_no = (blu.CalculateUnClaimMV("LotNo", 70, 80));
            prob_LotNo_GT80_no = (blu.CalculateUnClaimGT("LotNo", 80));

            //Probaility of YearManufacture
            prob_YM_LT2010_no = (blu.CalculateUnClaimLT("YearManufacture", 2010));
            prob_YM_2010T2015_no = (blu.CalculateUnClaimMV("YearManufacture", 2010, 2015));
            prob_YM_GT2015_no = (blu.CalculateUnClaimGT("YearManufacture", 2015));


            //Probability of Type Cover
            prob_TC_CM_no = (blu.CalculateUnClaim("TypeCover", "CM"));
            prob_TC_TP_no = (blu.CalculateUnClaim("TypeCover", "TP"));

            //Probability of Company Name
            prob_CN_Yamaha_no = (blu.CalculateUnClaim("CompanyName", "Yamaha"));
            prob_CN_RoyalEnfield_no = (blu.CalculateUnClaim("CompanyName", "RoyalEnfield"));
            prob_CN_Honda_no = (blu.CalculateUnClaim("CompanyName", "Honda"));
            prob_CN_Hero_no = (blu.CalculateUnClaim("CompanyName", "Hero"));
            prob_CN_HeroHonda_no = (blu.CalculateUnClaim("CompanyName", "HeroHonda"));
            prob_CN_Bajaj_no = (blu.CalculateUnClaim("CompanyName", "Bajaj"));
            prob_CN_TVS_no = (blu.CalculateUnClaim("CompanyName", "TVS"));
            prob_CN_Suzuki_no = (blu.CalculateUnClaim("CompanyName", "Suzuki"));
            prob_CN_Mahindra_no = (blu.CalculateUnClaim("CompanyName", "Mahindra"));
            prob_CN_KTM_no = (blu.CalculateUnClaim("CompanyName", "KTM"));

            //Probability of CCHP
            prob_CCHP_LT100_no = (blu.CalculateUnClaimLT("CCHP", 100));
            prob_CCHP_100T125_no = (blu.CalculateUnClaimMV("CCHP", 100, 125));
            prob_CCHP_125T150_no = (blu.CalculateUnClaimMV("CCHP", 125, 150));
            prob_CCHP_GT150_no = (blu.CalculateUnClaimGT("CCHP", 150));
        }

        public void write_no(string name, decimal value)
        {
            using (StreamWriter swExtLogFile = new StreamWriter("C:/Users/Kaushtup Bista/Desktop/probability_no.txt", true))
            {
                swExtLogFile.WriteLine(name + "," + value.ToString());


            }


        }
        public void writeAllUnClaim()
        {
            write_no("name", 0);
            write_no("prob_no", prob_no);
            write_no("prob_Zone_ME_no", prob_Zone_ME_no);
            write_no("prob_Zone_KO_no", prob_Zone_KO_no);
            write_no("prob_Zone_SA_no", prob_Zone_SA_no);
            write_no("prob_Zone_JA_no", prob_Zone_JA_no);
            write_no("prob_Zone_BA_no", prob_Zone_BA_no);
            write_no("prob_Zone_NA_no", prob_Zone_NA_no);
            write_no("prob_Zone_GA_no", prob_Zone_GA_no);
            write_no("prob_Zone_LU_no", prob_Zone_LU_no);
            write_no("prob_Zone_DH_no", prob_Zone_DH_no);
            write_no("prob_Zone_RA_no", prob_Zone_RA_no);
            write_no("prob_Zone_BHE_no", prob_Zone_BHE_no);
            write_no("prob_Zone_KA_no", prob_Zone_KA_no);
            write_no("prob_Zone_SE_no", prob_Zone_SE_no);
            write_no("prob_Zone_MA_no", prob_Zone_MA_no);
            write_no("prob_LotNo_LT10_no", prob_LotNo_LT10_no);
            write_no("prob_LotNo_10T20_no", prob_LotNo_10T20_no);
            write_no("prob_LotNo_20T30_no", prob_LotNo_20T30_no);
            write_no("prob_LotNo_30T40_no", prob_LotNo_30T40_no);
            write_no("prob_LotNo_40T50_no", prob_LotNo_40T50_no);
            write_no("prob_LotNo_50T60_no", prob_LotNo_50T60_no);
            write_no("prob_LotNo_60T70_no", prob_LotNo_60T70_no);
            write_no("prob_LotNo_70T80_no", prob_LotNo_70T80_no);
            write_no("prob_LotNo_GT80_no", prob_LotNo_GT80_no);
            write_no("prob_YM_LT2010_no", prob_YM_LT2010_no);
            write_no("prob_YM_2010T2015_no", prob_YM_2010T2015_no);
            write_no("prob_YM_GT2015_no", prob_YM_GT2015_no);
            write_no("prob_TC_CM_no", prob_TC_CM_no);
            write_no("prob_TC_TP_no", prob_TC_TP_no);
            write_no("prob_CN_Yamaha_no", prob_CN_Yamaha_no);
            write_no("prob_CN_RoyalEnfield_no", prob_CN_RoyalEnfield_no);
            write_no("prob_CN_Honda_no", prob_CN_Honda_no);
            write_no("prob_CN_Hero_no", prob_CN_Hero_no);
            write_no("prob_CN_HeroHonda_no", prob_CN_HeroHonda_no);
            write_no("prob_CN_Bajaj_no", prob_CN_Bajaj_no);
            write_no("prob_CN_TVS_no", prob_CN_TVS_no);
            write_no("prob_CN_Suzuki_no", prob_CN_Suzuki_no);
            write_no("prob_CN_Mahindra_no", prob_CN_Mahindra_no);
            write_no("prob_CN_KTM_no", prob_CN_KTM_no);
            write_no("prob_CCHP_LT100_no", prob_CCHP_LT100_no);
            write_no("prob_CCHP_100T125_no", prob_CCHP_100T125_no);
            write_no("prob_CCHP_125T150_no", prob_CCHP_125T150_no);
            write_no("prob_CCHP_GT150_no", prob_CCHP_GT150_no);
        }

    }
}
