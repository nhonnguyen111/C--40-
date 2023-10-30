using Kiemtra40_.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kiemtra40_.DAO.TableListDAO;

namespace Kiemtra40_.DAO
{
    public class BillinfoDAO
    {
        private static BillinfoDAO instance;

        public static BillinfoDAO Instance
        {
            get { if (instance == null) instance = new BillinfoDAO(); return instance; }
            private set { instance = value; }
        }
        public BillinfoDAO() { }
        public void DeleteBillInfoFood(int id) 
        {
            DataProvider.Instance.ExecuQuery("DELETE dbo.BillInfo WHERE idFood = " + id);
        }
        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> list = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + id);
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                list.Add(info);
            }
            return list;
          
        }
        public void InserBillInfo(int idBill, int idFood, int count)
        {
            string query = $"EXEC USP_InsertBillInfo @idBill={idBill}, @idFood={idFood}, @count={count}";
            SqlConnection conn = new SqlConnection(DataProvider.Instance.connectionData);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.ExecuteNonQuery();
        }
    }
}
