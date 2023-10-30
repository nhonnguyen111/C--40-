using Kiemtra40_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kiemtra40_.DAO.TableListDAO;

namespace Kiemtra40_.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set { instance = value; }
        }
        private BillDAO() { }
        //Thành công :  bill ID
        //Thất bại : -1
        public int GetBillByIDTable(int id)
        {
            DataTable data = DataProvider.Instance.ExecuQuery("SELECT * FROM dbo.Bill WHERE idTable = "+id+" AND status = 0");
            if(data.Rows.Count > 0 )
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public void CheckOut(int id, int discount,float totalprice)
        {
            string query = "UPDATE Bill SET DateCheckOut = GETDATE(), status  = 1, discount =" + discount + ",totalPrice = " + totalprice + "WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);

        }
        public void InserBill(int id)
        {
            string query = $"EXEC USP_InsertBill @idTable={id}";
            // 
            SqlConnection conn = new SqlConnection(DataProvider.Instance.connectionData);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.ExecuteNonQuery();
        
        }

        public DataTable GetBillListDate(DateTime checkIn, DateTime checkOut)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionData);
            
                connection.Open();
                SqlCommand command = new SqlCommand("USP_GetListBillDate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CheckIn", checkIn);
                command.Parameters.AddWithValue("@CheckOut", checkOut);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            
            return dt;

        }
        public int GetBill()
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM Bill");
        }
    }
}
