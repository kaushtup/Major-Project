using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace BikeInsurance.Controllers
{
    public class Test
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

        public DataTable GetTrainData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  *from tblTrainingSet", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetClaimData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  * from tblClaimData", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable GetUnClaimData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  * from tblUnclaimData", con);

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

        public DataTable GetZoneData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  * from tblZone", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable GetLoteNoData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  *from tblLoteNo", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable GetYearManufactureData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  *from tblYM", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        public DataTable GetTypeCoverData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  *from tblTypeCover", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        public DataTable GetCompanyNameData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  *from tblCompanyName", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        public DataTable GetCCHPData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  *from tblCCHP", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}