using Kiemtra40_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiemtra40_.DAO
{
    internal class TableListDAO
    {
        public class TableDAO
        {
            private static TableDAO instance;

            public static TableDAO Instance
            {
                get { if (instance == null) instance = new TableDAO(); return instance; }
                private set { instance = value; }
            }
            public static int TableWidth = 92;
            public static int TableHeight = 92;
            public TableDAO() { }
            public void SwitchTable(int id1, int id2)
            {
                string query = $"EXEC USP_SwitchTable @idTable1 ={id1}, @idTable2 = {id2}";
                // 
                SqlConnection conn = new SqlConnection(DataProvider.Instance.connectionData);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();


                //DataProvider.Instance.ExecuQuery("USP_SwitchTable @idTable1, @idTable2", new object[] {id1, id2});
            }
            public List<Table> GetLoadTableList()
            {

                List<Table> list = new List<Table>();
                DataTable data = DataProvider.Instance.ExecuQuery("USP_GetTableList");
                foreach (DataRow item in data.Rows)
                {
                    Table table = new Table(item);
                    list.Add(table);
                }
                return list;

            }
            public bool InsertTable(string name)
            {
                string query = string.Format("INSERT TableFood(name) VALUES(N'{0}')", name);
                int rs = DataProvider.Instance.ExecuteNonQuery(query);
                return rs > 0;
            }
            public bool UpdateTable(int id, string name)
            {
                string query = string.Format("UPDATE TableFood SET name = N'{0}'  WHERE id = {1}", name, id);
                int rs = DataProvider.Instance.ExecuteNonQuery(query);
                return rs > 0;
            }
            public bool DeleteTable(int idTable)
            {
                
                string query = string.Format("DELETE TableFood WHERE id = {0}", idTable);
                int rs = DataProvider.Instance.ExecuteNonQuery(query);
                return rs > 0;
            }


        }
    }
}
