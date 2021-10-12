using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace prescription.Data_Acces_Layer
{
    class DataAccesLayer
    {
        SqlConnection con;

        public DataAccesLayer()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hassan\Desktop\c sharp jeux\prescription\prescription\DbPrescription.mdf;Integrated Security=True");
        }
        // con open
        public void conopen()
        {
            if (con.State==ConnectionState.Closed || con.State==ConnectionState.Broken)
            {
                con.Open();
            }
        }
        // con close 
        public void conclose()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }


        // fun load to data 
        public DataTable read(string store, SqlParameter[] pram)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pram!=null)
            {
                cmd.Parameters.AddRange(pram);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // void for insert ; delete , update 
        public void Excute(string store, SqlParameter[] pram)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pram != null)
            {
                cmd.Parameters.AddRange(pram);
            }
            cmd.ExecuteNonQuery();
            
        }


    }
}
