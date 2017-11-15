using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RemotingObject
{
    public class TableSelecter : System.MarshalByRefObject
    {

        public DataTable GetTableFromDB()
        {
            MessageBox.Show("I am object");
            SqlConnection conn = new SqlConnection(@"Data Source=YAROSLAV-PC; Initial Catalog=MYDB; Integrated Security=True");
            DataTable dt = new DataTable();

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Couriers", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            conn.Close();

            return dt;
        }
    }
}
