using BLL;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace ReadFromCsv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        SendInfo blu = new SendInfo();
        count blc = new count();

        public string[] send = new string[1000];
        public string[] name = new string[1000];
        public string[] a = new string[1000];
        public string[] b = new string[1000];
        public string[] c = new string[1000];
        public string[] d = new string[1000];

        public string[] f = new string[1000];
        public string[] g = new string[1000];
        //public string[] h = new string[1000];
        //public string[] l = new string[1000];
        //public string[] m = new string[1000];
        //public string[] n = new string[1000];
        //public string[] o = new string[1000];
        //public string[] p = new string[1000];
        //public string[] q = new string[100];
        //public string[] r = new string[100];




        public string[] result = new string[1000];
        public int u = 0;
        public int k = 0;
        public int x;
        public int eighty;



        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)

        {

            DataTable csvData = new DataTable();

            try

            {

                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))

                {

                    csvReader.SetDelimiters(new string[] { "," });

                    csvReader.HasFieldsEnclosedInQuotes = true;

                    string[] colFields = csvReader.ReadFields();

                    foreach (string column in colFields)

                    {

                        DataColumn datecolumn = new DataColumn(column);

                        datecolumn.AllowDBNull = true;

                        csvData.Columns.Add(datecolumn);

                    }

                    while (!csvReader.EndOfData)

                    {

                        string[] fieldData = csvReader.ReadFields();

                        //Making empty value as null

                        for (int i = 0; i < fieldData.Length; i++)

                        {

                            if (fieldData[i] == "")

                            {

                                fieldData[i] = null;

                            }

                        }

                        csvData.Rows.Add(fieldData);

                    }

                }

            }

            catch (Exception ex)

            {

            }

            return csvData;

        }



        private void btnOpen_Click(object sender, EventArgs e)
        {
            blu.DeleteOrder();
            MessageBox.Show("Deleted Successfully");


        }


        public void sendName(string[] send)
        {

            name[u] = send[0];
            a[u] = send[1];
            b[u] = send[2];
            c[u] = send[3];
            d[u] = send[4];
            f[u] = send[5];
            g[u] = send[6];
            //h[u] = send[7];
            //l[u] = send[8];
            //m[u] = send[9];
            //n[u] = send[10];
            //o[u] = send[11];
            //p[u] = send[12];
            //q[j] = send[14];
            //r[j] = send[15];


            u++;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {



            string csv_file_path = @"C:\Users\Kaushtup Bista\Desktop\Data.csv";

            DataTable csvData = GetDataTabletFromCSVFile(csv_file_path);                                     
            x = csvData.Rows.Count;
            x = x + 1;
            int i = 0;

            eighty = Convert.ToInt32 (0.9 * x) ;
            foreach (DataRow row in csvData.Rows)
            {
                if (i < eighty)
                {

                    blu.CreateUser(row["Zone"].ToString(), Convert.ToInt32( row["LotNo"].ToString()), Convert.ToInt32( row["YearManufacture"].ToString()), row["TypeCover"].ToString(), row["CompanyName"].ToString(), Convert.ToDecimal( row["CCHP"].ToString()), row["Claim"].ToString());
                }
                
                else
                {
                blu.CreateUserNew(row["Zone"].ToString(), Convert.ToInt32(row["LotNo"].ToString()), Convert.ToInt32(row["YearManufacture"].ToString()), row["TypeCover"].ToString(), row["CompanyName"].ToString(), Convert.ToDecimal(row["CCHP"].ToString()), row["Claim"].ToString());
            }
                i++;


        }
        MessageBox.Show("Data Successfully Added");
            count();
        }

        private void count()
        {
            blc.zone();
            blc.lotno();
            blc.YM();
            blc.TC();
            blc.CM();
            blc.CCHP();
        }
}    }







