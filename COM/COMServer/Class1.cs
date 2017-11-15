using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace COMServer
{
    public interface IGetInf
    {
        DataTable GetDeliveryList(SqlConnection conn);

        DataTable GetCourierList(SqlConnection conn);
    }

    public interface ISetInf
    {
        void InsertNewDeliveryList(SqlConnection conn, string address, int courierID, string good);

        void InsertNewCourier(SqlConnection conn, string name, string surname, int age);
    }

    public interface IDelInf
    {
        void DelDeliveryList(SqlConnection conn, int id);

        void DelCourier(SqlConnection conn, int id);
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class DeliveryWorking : IGetInf, ISetInf, IDelInf
    {
        public DataTable GetDeliveryList(SqlConnection conn)
        {
            DataTable dt = new DataTable();

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM DeliveryList", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            conn.Close();

            return dt;
        }

        public DataTable GetCourierList(SqlConnection conn)
        {
            DataTable dt = new DataTable();

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Couriers", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            conn.Close();

            return dt;
        }

        public void InsertNewCourier(SqlConnection conn, string name, string surname, int age)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO Couriers (Name, Surname, Age) VALUES('{0}','{1}',{2})", name, surname, age), conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void InsertNewDeliveryList(SqlConnection conn, string address, int courierID, string good)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO DeliveryList (Good, Address, CourierID) VALUES('{0}','{1}',{2})", good, address, courierID), conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void DelDeliveryList(SqlConnection conn, int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(string.Format("DELETE DeliveryList WHERE CourierID=" + id), conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void DelCourier(SqlConnection conn, int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(string.Format("DELETE Couriers WHERE Age=" + id), conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }


    public interface Itable
    {
        DataTable FuncTableList(string dbName);
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class TableList : Itable
    {
        public DataTable FuncTableList(string dbName)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(@"Data Source=YAROSLAV-PC; Initial Catalog=" + dbName + "; Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM sys.objects where type='U'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            conn.Close();

            return dt;
        }
    }
}