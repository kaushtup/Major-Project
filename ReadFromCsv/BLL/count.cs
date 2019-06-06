using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class count
    {
        public void zone()
        {
            int mec, meu, koc, kou, sac, sau, jac, jau, bac, bau, nac, nau, gac, gau, luc, luu, dhc, dhu, rac, rau, bhec, bheu, kac, kau, sec, seu, mac, mau;
            DataTable dt = GetData();
            mec = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "ME" && x["Claim"].ToString() == "Yes").ToList().Count;
            meu = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "ME" && x["Claim"].ToString() == "No").ToList().Count;
            koc = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "KO" && x["Claim"].ToString() == "Yes").ToList().Count;
            kou = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "KO" && x["Claim"].ToString() == "No").ToList().Count;
            sac = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "SA" && x["Claim"].ToString() == "Yes").ToList().Count;
            sau = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "SA" && x["Claim"].ToString() == "No").ToList().Count;
            jac = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "JA" && x["Claim"].ToString() == "Yes").ToList().Count;
            jau = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "JA" && x["Claim"].ToString() == "No").ToList().Count;
            bac = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "BA" && x["Claim"].ToString() == "Yes").ToList().Count;
            bau = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "BA" && x["Claim"].ToString() == "No").ToList().Count;
            nac = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "NA" && x["Claim"].ToString() == "Yes").ToList().Count;
            nau = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "NA" && x["Claim"].ToString() == "No").ToList().Count;
            gac = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "GA" && x["Claim"].ToString() == "Yes").ToList().Count;
            gau = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "GA" && x["Claim"].ToString() == "No").ToList().Count;
            luc = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "LU" && x["Claim"].ToString() == "Yes").ToList().Count;
            luu = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "LU" && x["Claim"].ToString() == "No").ToList().Count;
            dhc = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "DH" && x["Claim"].ToString() == "Yes").ToList().Count;
            dhu = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "DH" && x["Claim"].ToString() == "No").ToList().Count;
            rac = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "RA" && x["Claim"].ToString() == "Yes").ToList().Count;
            rau = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "RA" && x["Claim"].ToString() == "No").ToList().Count;
            bhec = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "BHE" && x["Claim"].ToString() == "Yes").ToList().Count;
            bheu = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "BHE" && x["Claim"].ToString() == "No").ToList().Count;
            kac = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "KA" && x["Claim"].ToString() == "Yes").ToList().Count;
            kau = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "KA" && x["Claim"].ToString() == "No").ToList().Count;
            sec = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "SE" && x["Claim"].ToString() == "Yes").ToList().Count;
            seu = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "SE" && x["Claim"].ToString() == "No").ToList().Count;
            mac = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "MA" && x["Claim"].ToString() == "Yes").ToList().Count;
            mau = dt.AsEnumerable().Where(x => x["Zone"].ToString() == "MA" && x["Claim"].ToString() == "No").ToList().Count;

            Createtablezone(mec, meu, koc, kou, sac, sau, jac, jau, bac, bau, nac, nau, gac, gau, luc, luu, dhc, dhu, rac, rau, bhec, bheu, kac, kau, sec, seu, mac, mau);
        }

        public void lotno()
        {
            int lt10c, lt20c, lt30c, lt40c, lt50c, lt60c, lt70c, lt80c, lt100c, lt10u, lt20u, lt30u, lt40u, lt50u, lt60u, lt70u, lt80u, lt100u;
            DataTable dt = GetData();
            lt10c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 10 && (Convert.ToInt32(x["LotNo"].ToString())) >= 0 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt10u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 10 && (Convert.ToInt32(x["LotNo"].ToString())) >= 0 && x["Claim"].ToString() == "No").ToList().Count;
            lt20c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 20 && (Convert.ToInt32(x["LotNo"].ToString())) >=10  && x["Claim"].ToString() == "Yes").ToList().Count;
            lt20u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 20 && (Convert.ToInt32(x["LotNo"].ToString())) >= 10 && x["Claim"].ToString() == "No").ToList().Count;
            lt30c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 30 && (Convert.ToInt32(x["LotNo"].ToString())) >= 20 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt30u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 30 && (Convert.ToInt32(x["LotNo"].ToString())) >= 20 && x["Claim"].ToString() == "No").ToList().Count;
            lt40c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 40 && (Convert.ToInt32(x["LotNo"].ToString())) >= 30 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt40u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 40 && (Convert.ToInt32(x["LotNo"].ToString())) >= 30 && x["Claim"].ToString() == "No").ToList().Count;
            lt50c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 50 && (Convert.ToInt32(x["LotNo"].ToString())) >= 40 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt50u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 50 && (Convert.ToInt32(x["LotNo"].ToString())) >= 40 && x["Claim"].ToString() == "No").ToList().Count;
            lt60c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 60 && (Convert.ToInt32(x["LotNo"].ToString())) >= 50 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt60u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 60 && (Convert.ToInt32(x["LotNo"].ToString())) >= 50 && x["Claim"].ToString() == "No").ToList().Count;
            lt70c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 70 && (Convert.ToInt32(x["LotNo"].ToString())) >= 60 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt70u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 70 && (Convert.ToInt32(x["LotNo"].ToString())) >= 60 && x["Claim"].ToString() == "No").ToList().Count;
            lt80c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 80 && (Convert.ToInt32(x["LotNo"].ToString())) >= 70 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt80u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) < 80 && (Convert.ToInt32(x["LotNo"].ToString())) >= 70 && x["Claim"].ToString() == "No").ToList().Count;
            lt100c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) >= 80 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt100u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["LotNo"].ToString())) >= 80 && x["Claim"].ToString() == "No").ToList().Count;

            Createtablelot(lt10c, lt10u, lt20c, lt20u, lt30c, lt30u, lt40c, lt40u, lt50c, lt50u, lt60c, lt60u, lt70c, lt70u, lt80c, lt80u, lt100c, lt100u);
        }

        public void YM()
        {
            int lt2010c, lt2015c, lt2020c,lt2010u,lt2015u, lt2020u;
            DataTable dt = GetData();
            lt2010c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["YearManufacture"].ToString())) < 2010 && (Convert.ToInt32(x["YearManufacture"].ToString())) >= 0 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt2010u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["YearManufacture"].ToString())) < 2010 && (Convert.ToInt32(x["YearManufacture"].ToString())) >= 0 && x["Claim"].ToString() == "No").ToList().Count;
            lt2015c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["YearManufacture"].ToString())) < 2015 && (Convert.ToInt32(x["YearManufacture"].ToString())) >= 2010 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt2015u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["YearManufacture"].ToString())) < 2015 && (Convert.ToInt32(x["YearManufacture"].ToString())) >= 2010 && x["Claim"].ToString() == "No").ToList().Count;
            lt2020c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["YearManufacture"].ToString())) >= 2015 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt2020u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["YearManufacture"].ToString())) >= 2015 && x["Claim"].ToString() == "No").ToList().Count;

            CreatetableYM(lt2010c, lt2010u, lt2015c, lt2015u, lt2020c, lt2020u);
        }

        public void TC()
        {
            int cmc, tpc, cmu, tpu;
            DataTable dt = GetData();
            cmc = dt.AsEnumerable().Where(x => x["TypeCover"].ToString() == "CM" && x["Claim"].ToString() == "Yes").ToList().Count;
            cmu = dt.AsEnumerable().Where(x => x["TypeCover"].ToString() == "CM" && x["Claim"].ToString() == "No").ToList().Count;
            tpc = dt.AsEnumerable().Where(x => x["TypeCover"].ToString() == "TP" && x["Claim"].ToString() == "Yes").ToList().Count;
            tpu = dt.AsEnumerable().Where(x => x["TypeCover"].ToString() == "TP" && x["Claim"].ToString() == "No").ToList().Count;
            CreatetableTC(cmc, cmu, tpc, tpu);
        }

        public void CM()
        {
            int yc, yu, rec, reu, hc, hu, hec, heu, hhc, hhu, bc, bu, tc, tu, sc, su, mc, mu, kc, ku;
            DataTable dt = GetData();
            yc = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Yamaha" && x["Claim"].ToString() == "Yes").ToList().Count;
            yu = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Yamaha" && x["Claim"].ToString() == "No").ToList().Count;
            rec = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "RoyalEnfield" && x["Claim"].ToString() == "Yes").ToList().Count;
            reu = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "RoyalEnfield" && x["Claim"].ToString() == "No").ToList().Count;
            hc = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Honda" && x["Claim"].ToString() == "Yes").ToList().Count;
            hu = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Honda" && x["Claim"].ToString() == "No").ToList().Count;
            hec = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Hero" && x["Claim"].ToString() == "Yes").ToList().Count;
            heu = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Hero" && x["Claim"].ToString() == "No").ToList().Count;
            hhc = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "HeroHonda" && x["Claim"].ToString() == "Yes").ToList().Count;
            hhu = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "HeroHonda" && x["Claim"].ToString() == "No").ToList().Count;
            bc = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Bajaj" && x["Claim"].ToString() == "Yes").ToList().Count;
            bu = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Bajaj" && x["Claim"].ToString() == "No").ToList().Count;
            tc = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "TVS" && x["Claim"].ToString() == "Yes").ToList().Count;
            tu = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "TVS" && x["Claim"].ToString() == "No").ToList().Count;
            sc = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Suzuki" && x["Claim"].ToString() == "Yes").ToList().Count;
            su = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Suzuki" && x["Claim"].ToString() == "No").ToList().Count;
            mc = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Mahindra" && x["Claim"].ToString() == "Yes").ToList().Count;
            mu = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "Mahindra" && x["Claim"].ToString() == "No").ToList().Count;
            kc = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "KTM" && x["Claim"].ToString() == "Yes").ToList().Count;
            ku = dt.AsEnumerable().Where(x => x["CompanyName"].ToString() == "KTM" && x["Claim"].ToString() == "No").ToList().Count;

           CreatetableCN(yc, yu, rec, reu, hc, hu, hec, heu, hhc, hhu, bc, bu, tc, tu, sc, su, mc, mu, kc, ku);
        }

        public void CCHP()
        {
            int lt100c, lt125c, lt150c, lt200c, lt100u, lt125u, lt150u, lt200u;
            DataTable dt = GetData();
            lt100c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["CCHP"].ToString())) < 100 && (Convert.ToInt32(x["CCHP"].ToString())) >= 0 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt100u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["CCHP"].ToString())) < 100 && (Convert.ToInt32(x["CCHP"].ToString())) >= 0 && x["Claim"].ToString() == "No").ToList().Count;
            lt125c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["CCHP"].ToString())) < 125 && (Convert.ToInt32(x["CCHP"].ToString())) >= 100 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt125u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["CCHP"].ToString())) < 125 && (Convert.ToInt32(x["CCHP"].ToString())) >= 100 && x["Claim"].ToString() == "No").ToList().Count;
            lt150c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["CCHP"].ToString())) < 150 && (Convert.ToInt32(x["CCHP"].ToString())) >= 125 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt150u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["CCHP"].ToString())) < 150 && (Convert.ToInt32(x["CCHP"].ToString())) >= 125 && x["Claim"].ToString() == "No").ToList().Count;
            lt200c = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["CCHP"].ToString())) >= 150 && x["Claim"].ToString() == "Yes").ToList().Count;
            lt200u = dt.AsEnumerable().Where(x => (Convert.ToInt32(x["CCHP"].ToString())) >= 150 && x["Claim"].ToString() == "No").ToList().Count;

            CreatetableCCHP(lt100c,lt100u,lt125c,lt125u,lt150c,lt150u,lt200c,lt200u);

        }


        public DataTable GetData()
        {
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("select  * from tblTrainingSet", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void Createtablezone (int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p, int q, int r , int s, int t, int u, int v, int w, int x, int y, int z, int aa, int bb)
        {

          
            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("insert into tblZone values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@p,@q,@r,@s,@t,@u,@v,@w,@x,@y,@z,@aa,@bb)", con);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@e", e);
            cmd.Parameters.AddWithValue("@f", f);
            cmd.Parameters.AddWithValue("@g", g);
            cmd.Parameters.AddWithValue("@h", h);
            cmd.Parameters.AddWithValue("@i", i);
            cmd.Parameters.AddWithValue("@j", j);
            cmd.Parameters.AddWithValue("@k", k);
            cmd.Parameters.AddWithValue("@l", l);
            cmd.Parameters.AddWithValue("@m", m);
            cmd.Parameters.AddWithValue("@n", n);
            cmd.Parameters.AddWithValue("@o", o);
            cmd.Parameters.AddWithValue("@p", p);
            cmd.Parameters.AddWithValue("@q", q);
            cmd.Parameters.AddWithValue("@r", r);
            cmd.Parameters.AddWithValue("@s", s);
            cmd.Parameters.AddWithValue("@t", t);
            cmd.Parameters.AddWithValue("@u", u);
            cmd.Parameters.AddWithValue("@v", v);
            cmd.Parameters.AddWithValue("@w", w);
            cmd.Parameters.AddWithValue("@x", x);
            cmd.Parameters.AddWithValue("@y", y);
            cmd.Parameters.AddWithValue("@z", z);
            cmd.Parameters.AddWithValue("@aa", aa);
            cmd.Parameters.AddWithValue("@bb", bb);




            con.Open();
           cmd.ExecuteNonQuery();
            con.Close();
            
        }


        public void Createtablelot(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p, int q, int r)
        {


            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("insert into tblLoteNo values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@p,@q,@r)", con);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@e", e);
            cmd.Parameters.AddWithValue("@f", f);
            cmd.Parameters.AddWithValue("@g", g);
            cmd.Parameters.AddWithValue("@h", h);
            cmd.Parameters.AddWithValue("@i", i);
            cmd.Parameters.AddWithValue("@j", j);
            cmd.Parameters.AddWithValue("@k", k);
            cmd.Parameters.AddWithValue("@l", l);
            cmd.Parameters.AddWithValue("@m", m);
            cmd.Parameters.AddWithValue("@n", n);
            cmd.Parameters.AddWithValue("@o", o);
            cmd.Parameters.AddWithValue("@p", p);
            cmd.Parameters.AddWithValue("@q", q);
            cmd.Parameters.AddWithValue("@r", r);
            



            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
        }



        public void CreatetableYM(int a, int b, int c, int d, int e, int f)
        {


            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("insert into tblYM values(@a,@b,@c,@d,@e,@f)", con);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@e", e);
            cmd.Parameters.AddWithValue("@f", f);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
           
        }



        public void CreatetableTC(int a, int b, int c, int d)
        {


            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("insert into tblTypeCover values(@a,@b,@c,@d)", con);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            con.Open();
           cmd.ExecuteNonQuery();
            con.Close();
            
        }


        public void CreatetableCN(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j, int k, int l, int m, int n, int o, int p, int q, int r, int s, int t)
        {


            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("insert into tblCompanyName values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@p,@q,@r,@s,@t)", con);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@e", e);
            cmd.Parameters.AddWithValue("@f", f);
            cmd.Parameters.AddWithValue("@g", g);
            cmd.Parameters.AddWithValue("@h", h);
            cmd.Parameters.AddWithValue("@i", i);
            cmd.Parameters.AddWithValue("@j", j);
            cmd.Parameters.AddWithValue("@k", k);
            cmd.Parameters.AddWithValue("@l", l);
            cmd.Parameters.AddWithValue("@m", m);
            cmd.Parameters.AddWithValue("@n", n);
            cmd.Parameters.AddWithValue("@o", o);
            cmd.Parameters.AddWithValue("@p", p);
            cmd.Parameters.AddWithValue("@q", q);
            cmd.Parameters.AddWithValue("@r", r);
            cmd.Parameters.AddWithValue("@s", s);
            cmd.Parameters.AddWithValue("@t", t);
           




            con.Open();
           cmd.ExecuteNonQuery();
            con.Close();
            
        }


        public void CreatetableCCHP(int a, int b, int c, int d, int e, int f, int g, int h)
        {


            SqlConnection con = new SqlConnection("Data Source=.; Integrated Security=true; Database=BikeInsurance");
            SqlCommand cmd = new SqlCommand("insert into tblCCHP values(@a,@b,@c,@d,@e,@f,@g,@h)", con);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@e", e);
            cmd.Parameters.AddWithValue("@f", f);
            cmd.Parameters.AddWithValue("@g", g);
            cmd.Parameters.AddWithValue("@h", h);
                   con.Open();
             cmd.ExecuteNonQuery();
            con.Close();
           
        }

    }
}
