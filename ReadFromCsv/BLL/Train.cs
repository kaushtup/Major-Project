using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Train
    {

        public DataTable GetTrainData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  *from tblTrainingSet", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
           return dt;
        }

        public int CreateClaimData(string a, int b, int c, string d, string e, decimal f)//, string f, string g, string h, string i, string j, string k, string l, string m)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("insert into tblClaimData values(@a,@b,@c,@d,@e,@f)", con);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@e", e);
            cmd.Parameters.AddWithValue("@f", f);
            //cmd.Parameters.AddWithValue("@g", g);
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
        public int CreateUnClaimData(string a, int b, int c, string d, string e, decimal f)//, string f, string g, string h, string i, string j, string k, string l, string m)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("insert into tblUnclaimData values(@a,@b,@c,@d,@e,@f)", con);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@e", e);
            cmd.Parameters.AddWithValue("@f", f);
            //cmd.Parameters.AddWithValue("@g", g);
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
        decimal yes;
        decimal no;
        public decimal CalculateClaim(string name, string value)
        {
            
            DataTable dt = GetClaimData();
            yes = dt.Rows.Count;
            decimal n = dt.AsEnumerable().Where(x => x[name].ToString() == value).ToList().Count;
            
                return (n + 1)/(yes+1);
            
            
        }

        public decimal CalculateClaimLT(string name, decimal value)
        {
            decimal n = 0;
            DataTable dt = GetClaimData();
            try
            {
                n = dt.AsEnumerable().Where(x => Convert.ToInt32(x[name]) < value).ToList().Count; ;
            }
            catch (FormatException)
            {


            }

             return (n + 1) / (yes + 1);
            

        }

        public decimal CalculateClaimMV(string name, decimal value1, decimal value2)
        {
            decimal n = 0;
            DataTable dt = GetClaimData();
            
            n = dt.AsEnumerable().Where(x => Convert.ToInt32(x[name]) >= value1 && Convert.ToInt32(x[name]) < value2).ToList().Count; ;
          
                     
                return (n + 1) / (yes + 1);
           

        }

        public decimal CalculateClaimGT(string name, decimal value)
        {
            
            DataTable dt = GetClaimData();
            decimal n = 0;
            try
                {
                     n = dt.AsEnumerable().Where(x => Convert.ToInt32(x[name]) >= value).ToList().Count; 
                }
                catch (FormatException)
                {


                }
            
                return (n + 1) / (yes + 1);
            
        }


        public decimal CalculateUnClaim(string name, string value)
        {
            DataTable dt = GetUnClaimData();
            no = dt.Rows.Count;
            decimal n = dt.AsEnumerable().Where(x => x[name].ToString() == value).ToList().Count;
            
                return (n + 1) / (no + 1);
                    }

        public decimal CalculateUnClaimLT(string name, decimal value)
        {
            DataTable dt = GetUnClaimData();
            decimal n = 0;
            try
            {
                n = dt.AsEnumerable().Where(x => Convert.ToInt32(x[name]) < value).ToList().Count;
            }
            catch (FormatException)
            {


            }


                     return (n + 1) / (no + 1);
             }

        public decimal CalculateUnClaimMV(string name, decimal value1, decimal value2)
        {
            decimal n = 0;
            DataTable dt = GetClaimData();
            try
            {
                n = dt.AsEnumerable().Where(x => Convert.ToInt32(x[name]) >= value1 && Convert.ToInt32(x[name]) < value2).ToList().Count; 
            }
            catch (FormatException)
            {


            }
            
                return (n + 1) / (no + 1);
            

        }

        public decimal CalculateUnClaimGT(string name, decimal value)
        {
            DataTable dt = GetUnClaimData();
            decimal n = 0;
            try
            {
                n = dt.AsEnumerable().Where(x => Convert.ToInt32(x[name]) >= value).ToList().Count;
            }
            catch (FormatException)
            {


            }


            
                return (n + 1) / (no + 1);
           
        }


    }
}
