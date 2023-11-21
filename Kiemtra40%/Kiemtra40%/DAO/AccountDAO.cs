using Kiemtra40_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kiemtra40_.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance {
            get { if (instance == null) instance = new AccountDAO(); return instance; } 
            private set { instance = value;}
           
    }
        private AccountDAO() { }
        public bool Login(string userName, string passWord) {

            

            string query = "select * from Account where UserName = N'"+userName+"' and PassWord = N'"+passWord+"'";
            DataTable result = DataProvider.Instance.ExecuQuery(query, new object[] {userName, passWord});
            return result.Rows.Count > 0;
        }
        public bool UpdateAccount(string username, string displayname, string pass, string newpass)
        {
            using (SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionData))
            {
                using (SqlCommand command = new SqlCommand("USP_UpdateAccount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userName", username);
                    command.Parameters.AddWithValue("@displayName", displayname);
                    command.Parameters.AddWithValue("@passWord", pass);
                    command.Parameters.AddWithValue("@newPassword", newpass);

                    connection.Open();
                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows > 0;
                }
            }
            //int rs = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateAccount @userName, @displayName , @passWord, @newPassword ", new object[] {username, displayname, pass, newpass});
            //return rs > 0;
        }
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuQuery("SELECT UserName , DisplayName, type FROM Account");
        }
        public Account GetAccountByUserName(string userName)
        {
           DataTable data = DataProvider.Instance.ExecuQuery("SELECT * FROM Account WHERE UserName = '" + userName+"'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool InsertAccount(string userName, string displayName, int type)
        {
            string query = string.Format("INSERT dbo.Account (Username ,DisplayName, type)VALUES (N'{0}',N'{1}',{2})", userName, displayName, type);
            int rs = DataProvider.Instance.ExecuteNonQuery(query);
            return rs > 0;
        }
        public bool UpdateAccount(string userName, string displayName, int type)
        {
            string query = string.Format("UPDATE Account SET  DisplayName = N'{1}', Type = {2} where UserName = N'{0}'", userName, displayName, type);
            int rs = DataProvider.Instance.ExecuteNonQuery(query);
            return rs > 0;
        }
        public bool DeleteAccount(string userName)
        {
            
            string query = string.Format("DELETE Account WHERE UserName = N'{0}'", userName);
            int rs = DataProvider.Instance.ExecuteNonQuery(query);
            return rs > 0;
        }
        public bool ResetPassword(string name)
        {
            string query = string.Format("UPDATE Account SET Password = N'0' WHERE UserName = N'{0}'", name);
            int rs = DataProvider.Instance.ExecuteNonQuery(query);
            return rs > 0;
        }
    }
}
