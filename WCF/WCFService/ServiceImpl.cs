using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace WCFService
{
   [DataContract]
    public class Boat 
    {
        [DataMember]
        public double corn=20;
        public double leng;
    }
    public class ServiceImpl : IService, IServTP, IBoat
    {
        SqlConnection conn = new SqlConnection(@"Data Source=Yaroslav-PC; Initial Catalog=MYDB; Integrated Security=True");

        public DataTable GetCourierList()
        {
            DataTable dt = new DataTable();

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Couriers", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            conn.Close();

            dt.TableName = "Couriers";

            return dt;
        }

        public void InsertNewCourier(string name, string surname, int age)
        {
            
        }

        public void DelCourier(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(string.Format("DELETE Couriers WHERE ID=" + id), conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public DataTable GetSystemInfo(string param)
        {
            DataTable dt = new DataTable();

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM sys.objects where type= '"+param+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            conn.Close();

            dt.TableName = "Couriers";

            return dt;
        }


        public double Sinn(Boat par) 
        {
            return Math.Sin(par.corn) ;
        }
    }

}
