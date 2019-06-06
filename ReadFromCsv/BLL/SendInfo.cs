using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SendInfo
    {
        public int CreateUser(string a, int b, int c, string d, string e, decimal f, string g)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("insert into tblTrainingSet values(@a,@b,@c,@d,@e,@f,@g)", con);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@e", e);
            cmd.Parameters.AddWithValue("@f", f);
            cmd.Parameters.AddWithValue("@g", g);
            //cmd.Parameters.AddWithValue("@h", h);
            //cmd.Parameters.AddWithValue("@i", i);
            //cmd.Parameters.AddWithValue("@j", j);
            //cmd.Parameters.AddWithValue("@k", k);
            //cmd.Parameters.AddWithValue("@l", l);
            //cmd.Parameters.AddWithValue("@m", m);           

            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
            return n;
        }

        public int CreateUserNew(string a, int b, int c, string d, string e, decimal f, string g)//, string f, string g, string h, string i, string j, string k, string l, string m)
        {


            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("insert into tblTestingSet values(@a,@b,@c,@d,@e,@f,@g)", con);
            
                    
                cmd.Parameters.AddWithValue("@a", a);                  
                cmd.Parameters.AddWithValue("@b", b);                 
                cmd.Parameters.AddWithValue("@c", c);          
                cmd.Parameters.AddWithValue("@d", d);            
                cmd.Parameters.AddWithValue("@e", e);
                cmd.Parameters.AddWithValue("@f", f);
                cmd.Parameters.AddWithValue("@g", g);

          
           
          

            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
            return n;
        }


        public DataTable GetAllTrainingData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select *from tblTrainingSet", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public void DeleteOrder()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("delete from tblTrainingSet", con);
            SqlCommand cmd1 = new SqlCommand("delete from tblTestingSet", con);
            SqlCommand cmd2 = new SqlCommand("delete from tblClaimData", con);
            SqlCommand cmd3 = new SqlCommand("delete from tblUnclaimData", con);
            SqlCommand cmd4 = new SqlCommand("delete from tblZone", con);
            SqlCommand cmd5 = new SqlCommand("delete from tblLoteNo", con);
            SqlCommand cmd6 = new SqlCommand("delete from tblYM", con);
            SqlCommand cmd7 = new SqlCommand("delete from tblTypeCover", con);
            SqlCommand cmd8 = new SqlCommand("delete from tblCompanyName", con);
            SqlCommand cmd9 = new SqlCommand("delete from tblCCHP", con);

            con.Open();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();
            cmd5.ExecuteNonQuery();
            cmd6.ExecuteNonQuery();
            cmd7.ExecuteNonQuery();
            cmd8.ExecuteNonQuery();
            cmd9.ExecuteNonQuery();
            con.Close();
        }

    }
}
