using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace prescription.Bis_Layer
{
    class CLS_Pres
    {
        // instance from dal
        Data_Acces_Layer.DataAccesLayer dal = new prescription.Data_Acces_Layer.DataAccesLayer();
        // insert patentes  data
        public void insert_Pat_info(string Pat_name,int Pat_age,string Pat_type)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("Pat_Name", Pat_name);
            pr[1] = new SqlParameter("Pat_Age", Pat_age);
            pr[2] = new SqlParameter("Pat_Type", Pat_type);
            dal.conopen();
            dal.Excute("SP_InsertPatInfo", pr);
            dal.conclose();
        }
        // load data tretment
        public DataTable loadTreat()
        {
            SqlParameter[] pr = null;
            return dal.read("SP_LoadPatForTreat", pr);
        }
        // insert Treatpatentes  data
        public void insert_Treat(int Patients_ID, string Treat_Name, string Treat_All,string Treat_Dur,string Treat_Time)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("Patients_ID", Patients_ID);
            pr[1] = new SqlParameter("Treat_Name", Treat_Name);
            pr[2] = new SqlParameter("Treat_All", Treat_All);
            pr[3] = new SqlParameter("Treat_Dur", Treat_Dur);
            pr[4] = new SqlParameter("Treat_Time", Treat_Time);
            dal.conopen();
            dal.Excute("SP_InsertTreatForPat", pr);
            dal.conclose();
        }
    }
}
