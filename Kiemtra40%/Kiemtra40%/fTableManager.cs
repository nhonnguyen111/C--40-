using DocuSign.eSign.Model;
using Kiemtra40_.DAO;
using Kiemtra40_.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = Kiemtra40_.DTO.Menu;

namespace Kiemtra40_
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;
        
        
        public Account LoginAccount1 { 
            get => loginAccount;
            set { loginAccount = value;
                ChangAccount(loginAccount.Type);
            } }

        
        public fTableManager(Account acc)
        {
            InitializeComponent();

            this.LoginAccount1 = acc;
            
            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbTable);
            
        }

        #region Method
        void ChangAccount(int type)
        {
            //adminToolStripMenuItem_Click(this, new EventArgs());
            adminToolStripMenuItem.Enabled = type == 1;
            tàiKhoảnCáNhânToolStripMenuItem.Text += "(" + loginAccount.Displayname + ")";
        }
        void LoadCategory()
        {
            List<Category> list = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = list;
            cbCategory.DisplayMember = "Name";
            
            
        }
        void LoadFoodCategory(int id)
        {
            List<Foods> foods = FoodDAO.Instance.GetFoods(id);
            cbFoods.DataSource = foods;
            cbFoods.DisplayMember = "Name";
        }
        void LoadTable()
        {
            pnTable.Controls.Clear();
            List<Table> list = TableListDAO.TableDAO.Instance.GetLoadTableList();
            foreach(Table item in list)
            {
                Button btn = new Button() {Width = TableListDAO.TableDAO.TableWidth, Height = TableListDAO.TableDAO.TableHeight  };
                btn.Text = item.Name +Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                pnTable.Controls.Add(btn);
                switch(item.Status)
                {
                    case "Trống" :
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.AntiqueWhite;
                        break;
                }
            }
        }

        void ShowBill(int id)
        {
            lswBill.Items.Clear();
            List<Menu> lisbillinfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach(Menu item in lisbillinfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName1.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lswBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            txbtotalPrice.Text = totalPrice.ToString("c", culture);
            
        }
        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableListDAO.TableDAO.Instance.GetLoadTableList();
            cb.DisplayMember = "Name";
        }
        #endregion
        #region Events
        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddFood_Click(this, new EventArgs());
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCheckout_Click(this, new EventArgs());
        }
        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lswBill.Tag = (sender as Button).Tag; 
            ShowBill(tableID);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tàiKhoảnCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fProfile fProfile = new fProfile(loginAccount);
            fProfile.Updateaccount += fProfile_Updateaccount;
            fProfile.ShowDialog();
        }
        void fProfile_Updateaccount(object sender, AccountEvent e)
        {
            tàiKhoảnCáNhânToolStripMenuItem.Text = "Tài khoản cá nhân (" + e.Acc.Displayname + ")";
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            fAdmin.loginAccount = loginAccount;
            fAdmin.Insertfoods += fAdmin_Insertfoods;
            fAdmin.UpdateFoods += fAdmin_UpdateFoods;
            fAdmin.DeleteFoods += fAdmin_DeleteFoods;
            fAdmin.ShowDialog();   
        }

        private void fAdmin_DeleteFoods(object sender, EventArgs e)
        {
            LoadFoodCategory((cbCategory.SelectedItem as Category).ID);
            if(lswBill.Tag != null)
                ShowBill((lswBill.Tag as Table).ID);
            LoadTable();
        }

        private void fAdmin_UpdateFoods(object sender, EventArgs e)
        {
            LoadFoodCategory((cbCategory.SelectedItem as Category).ID);
            if (lswBill.Tag != null)
                ShowBill((lswBill.Tag as Table).ID);
        }

        private void fAdmin_Insertfoods(object sender, EventArgs e)
        {
            LoadFoodCategory((cbCategory.SelectedItem as Category).ID);
            if (lswBill.Tag != null)
                ShowBill((lswBill.Tag as Table).ID);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            LoadFoodCategory(id);
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lswBill.Tag as Table;

            if(table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }


            int idBill = BillDAO.Instance.GetBillByIDTable(table.ID);
            int foodId = (cbFoods.SelectedItem as Foods).ID;
            int count = (int)numberFood.Value;
            if(idBill == -1)
            {
                BillDAO.Instance.InserBill(table.ID);
                BillinfoDAO.Instance.InserBillInfo(BillDAO.Instance.GetBill(),foodId, count);
            }
            else
            {
                BillinfoDAO.Instance.InserBillInfo(idBill, foodId, count);
            }
            ShowBill(table.ID);
            LoadTable();
        }
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Table table = lswBill.Tag as Table;
            int idBill = BillDAO.Instance.GetBillByIDTable(table.ID);
            int discount  = (int)mnDiscount.Value;
            double totalPrice  = Convert.ToDouble(txbtotalPrice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            if (idBill != -1)
            {
                if(MessageBox.Show("Bạn muốn thanh toán hóa đơn cho " + table.Name, "Thông báo",MessageBoxButtons.OKCancel)== System.Windows.Forms.DialogResult.OK)
                {   
                        BillDAO.Instance.CheckOut(idBill, discount,(float) finalTotalPrice);
                        MessageBox.Show(string.Format("Số bàn : {0}\n Tổng tiền : {1} \n Giảm giá : {2} \n Thành tiền : {3}", table.Name + "\n", totalPrice + "000 đồng", discount + "%", finalTotalPrice + "000 đồng"), "Hóa đơn", MessageBoxButtons.OK);
                        ShowBill(table.ID);
                        LoadTable();              
                }
            }
        }
        private void btnTable_Click(object sender, EventArgs e)
        {
           
            int id1 =(lswBill.Tag as Table).ID;
            int id2 = (cbTable.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn muốn chuyển bàn {0} qua bàn {1}", (lswBill.Tag as Table).Name, (cbTable.SelectedItem as Table).Name),"Thông báo",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableListDAO.TableDAO.Instance.SwitchTable(id1, id2);
                LoadTable();
            }
           
        }


        #endregion

        
    }
}
