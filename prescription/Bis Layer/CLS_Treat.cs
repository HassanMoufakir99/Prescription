using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace prescription.Bis_Layer
{
    class CLS_Treat
    {
        // instance from dal
        Data_Acces_Layer.DataAccesLayer dal = new prescription.Data_Acces_Layer.DataAccesLayer();
        // load data tretment
        public DataTable loadTreat()
        {
            SqlParameter[] pr = null;
            return dal.read("SP_LoadTreat",pr);
        }
        // insert treat  data
         public void insert_treat(string treat_name)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("Treat_Name", treat_name);
            dal.conopen();
            dal.Excute("ST_InsertTreat",pr);
            dal.conclose();
        }
        // delete treat  data
        public void delete_treat(int Treat_ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("Treat_ID", Treat_ID);
            dal.conopen();
            dal.Excute("SP_DeleteTreat", pr);
            dal.conclose();
        }
        // Update treat  data
        public void Update_treat(string Treat_name , int Treat_ID)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("Treat_ID", Treat_ID);
            pr[1] = new SqlParameter("Treat_name", Treat_name);
            dal.conopen();
            dal.Excute("SP_Update", pr);
            dal.conclose();
        }

        // Rechercher data
        public DataTable Rechrcher_Treat(string Treat_Name)
        {
            SqlParameter[] pr =new SqlParameter[1];
            pr[0] = new SqlParameter("Treat_Name", Treat_Name);
            return dal.read("SP_RechercherTreat", pr);
        }
        // methode for patents

        // load data patents
        public DataTable loadPatents()
        {
            SqlParameter[] pr = null;
            return dal.read("SP_LoadPat", pr);

        }
        // Delete Patents
        public void delete_Pat(int Patients_ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("Patients_ID", Patients_ID);
            dal.conopen();
            dal.Excute("SP_DeletePat", pr);
            dal.conclose();
        }
        // Rechercher data pat
        public DataTable Rechrcher_Patients(string Patients_Search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("Patients_Search", Patients_Search);
            return dal.read("SP_SearchPat", pr);
        }
        // SP_LoadPatTreat
        // Rechercher data pat
        public DataTable Load_Treat_Pat(int Patients_ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("Patients_ID", Patients_ID);
            return dal.read("SP_LoadPatTreat", pr);
        }
        //SP_LoadUser
        //Methode of load users
        public DataTable loadUsers()
        {
            SqlParameter[] pr = null;
            return dal.read("SP_LoadUser", pr);

        }
        // Insert Users
        public void insert_Users(string Name, string User_Name, string PassWord, string User_Roll, string User_State)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("Name", Name);
            pr[1] = new SqlParameter("User_Name", User_Name);
            pr[2] = new SqlParameter("PassWord", PassWord);
            pr[3] = new SqlParameter("User_Roll", User_Roll);
            pr[4] = new SqlParameter("User_State", User_State);
            dal.conopen();
            dal.Excute("SP_InsertUsers", pr);
            dal.conclose();
        }
        // Update Users
        public void Update_Users(int User_ID,string Name, string User_Name, string PassWord, string User_Roll)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("Name", Name);
            pr[1] = new SqlParameter("User_Name", User_Name);
            pr[2] = new SqlParameter("PassWord", PassWord);
            pr[3] = new SqlParameter("User_Roll", User_Roll);
            pr[4] = new SqlParameter("User_ID", User_ID);
            dal.conopen();
            dal.Excute("SP_UpdatetUsers", pr);
            dal.conclose();
        }
        // Delete User
        public void delete_User(int User_ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("User_ID", User_ID);
            dal.conopen();
            dal.Excute("SP_Delete", pr);
            dal.conclose();
        }
    }
}
