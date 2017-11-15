using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RemotingObject
{
    public class CourierWorker : System.MarshalByRefObject
    {
        public void SetTableToDB(string name, string surname, int age)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=YAROSLAV-PC; Initial Catalog=MYDB; Integrated Security=True");
            
            conn.Open();
            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO Couriers (Name, Surname, Age) VALUES('{0}','{1}',{2})", name, surname, age), conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void DeleteRow(int id)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=YAROSLAV-PC; Initial Catalog=MYDB; Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand(string.Format("DELETE Couriers WHERE Age=" + id), conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
