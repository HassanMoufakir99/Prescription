using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace prescription.Bis_Layer
{
    class Cls_Users
    {
        // instance from dal
        Data_Acces_Layer.DataAccesLayer dal = new prescription.Data_Acces_Layer.DataAccesLayer();
        // load data user
        public DataTable Load_Login(string User_Name,string PassWord)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("User_Name", User_Name);
            pr[1] = new SqlParameter("PassWord", PassWord);
            return dal.read("SP_Login", pr);
        }
        // Update state  data
        public void Update_State(int User_ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("User_ID", User_ID);
            dal.conopen();
            dal.Excute("SP_UpdateLogin", pr);
            dal.conclose();
        }
        // Update state  data
        public void Logout()
        {
            SqlParameter[] pr =null;     
            dal.conopen();
            dal.Excute("SP_Logout", pr);
            dal.conclose();
        }
        // Load start
        public DataTable load_Start()
        {
            SqlParameter[] pr = null;
            return dal.read("SP_Start", pr);
        }
    }
}
