using Kiemtra40_.DAO;
using Kiemtra40_.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kiemtra40_
{
    
    public partial class fProfile : Form
    {
        private Account loginAccount;

        public Account LoginAccount {
            get => loginAccount;
            set { loginAccount = value;
                ChangAccount(LoginAccount);
            }  }

        public fProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void ChangAccount(Account acc)
        {
            txbUsername.Text = LoginAccount.Username;
            txtDisplay.Text = LoginAccount.Displayname;
        }
        void UpdateAccount()
        {
            string username = txbUsername.Text;
            string displayname = txtDisplay.Text;
            string password = txtPassword.Text;
            string renterpass= txtRePass.Text;
            string newpass= txtResetPass.Text;
            if(!newpass.Equals(renterpass))
            {
                MessageBox.Show("Mật khẩu không trùng với mật khẩu mới !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(username, displayname, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if(updateAccount != null)
                    {
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(username)));
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> Updateaccount
        {
            add { updateAccount += value; } remove
            {
                updateAccount -= value;
            }
        }
        private void fProfile_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

    }
    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc { get => acc; set => acc = value; }
        public AccountEvent(Account acc)
        {
            this.acc = acc;
        }
    }
}
