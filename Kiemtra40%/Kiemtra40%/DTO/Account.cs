using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiemtra40_.DTO
{
    public class Account
    {
        public Account(string username, string displayname,int type, string password = null)
        {
            this.Username = username;
            this.Displayname = displayname;
            this.Type = type;
            this.Password = password;
        }    
        public Account(DataRow row) 
        {
            this.Username = row["UserName"].ToString();
            this.Displayname = row["DisplayName"].ToString();
            this.Type = (int)row["type"];
            this.Password = row["password"].ToString();
        }
        private string username;
        
        
        
        [DisplayName("Tài khoản")]
        public string Username { get => username; set => username = value; }
        private string password;
        [DisplayName("Mật khẩu")]
        public string Password { get => password; set => password = value; }
        private string displayname;
        [DisplayName("Tên hiển thị")]
        public string Displayname { get => displayname; set => displayname = value; }
        private int type;
        [DisplayName("Chức vụ")]
        public int Type { get => type; set => type = value; }
    }
}
