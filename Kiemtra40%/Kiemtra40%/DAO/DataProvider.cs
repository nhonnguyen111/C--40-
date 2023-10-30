using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiemtra40_.DAO
{
    internal class DataProvider
    {
        private static DataProvider instance;
        internal static DataProvider Instance {
            get {  if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }
        
        public string connectionData = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyQuanCaPhe;Integrated Security=True";
        public DataTable ExecuQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionData))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                if(parameter != null )
                {
                    string[] listPara = query.Split(',');
                    int i = 0;
                    foreach ( string item in listPara )
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data);

                connection.Close();
            }
          return data;            
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionData))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(',');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }


               data = cmd.ExecuteNonQuery();
                
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionData))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(',');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteScalar();

                connection.Close();
            }
            return data;
        }

        internal DataTable ExecuteQuery(string query, object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
