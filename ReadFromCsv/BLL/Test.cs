using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
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
    }
}
