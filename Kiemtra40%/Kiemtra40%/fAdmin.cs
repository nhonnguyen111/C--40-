
using Kiemtra40_.DAO;
using Kiemtra40_.DTO;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace Kiemtra40_
{
    public partial class fAdmin : Form
    {
        BindingSource foodlist =new BindingSource();
        BindingSource accountlist =new BindingSource();
        BindingSource categorylist =new BindingSource();
        BindingSource tableList =new BindingSource();
        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            dtgvFood.DataSource = foodlist;
            dtgvAccount.DataSource = accountlist;
            dtgvCategory.DataSource = categorylist;
            dtgvTable.DataSource = tableList;
            LoadListBillByDate(dtpkStart.Value, dtpkEnd.Value);
            LoadDateTimePickerBill();
            LoadlistFood();
            LoadListCategory();
            LoadAccount();
            AddFoodBinding();
            LoadCategoryIntoCombox(cbFoodCategory);
            
            AddAcountBinding(); 
            AddCategoryBinding();
            LoadListTable();
            AddTableBinding();
        }
        #region methods
        void AddAcountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text",dtgvAccount.DataSource,"UserName",true,DataSourceUpdateMode.Never));
            txbDisplay.DataBindings.Add(new Binding("Text",dtgvAccount.DataSource,"DisplayName", true, DataSourceUpdateMode.Never));
            mnTypeAccount.DataBindings.Add(new Binding("Value",dtgvAccount.DataSource,"Type", true, DataSourceUpdateMode.Never));
        }
        
        void LoadAccount()
        {
            accountlist.DataSource = AccountDAO.Instance.GetListAccount();
        }
        List<Foods> SearchFoodByName(string name)
        {
            List<Foods> listfood = FoodDAO.Instance.SearchFoodByName(name);
            
            return listfood;
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkStart.Value = new DateTime(today.Year, today.Month, 1);
            dtpkEnd.Value = dtpkStart.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource= BillDAO.Instance.GetBillListDate(checkIn, checkOut);
        }
        void LoadListCategory()
        {
            categorylist.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void AddCategoryBinding()
        {
            txbIDCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "id",true, DataSourceUpdateMode.Never));
            txbCategory.DataBindings.Add(new Binding("Text",dtgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
        }
        void LoadlistFood()
        {
            foodlist.DataSource = FoodDAO.Instance.GetListFoods();
        }
        void LoadListTable()
        {
            tableList.DataSource = TableListDAO.TableDAO.Instance.GetLoadTableList();
        }
        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "name",true,DataSourceUpdateMode.Never));
            txbIDFood.DataBindings.Add(new Binding("Text",dtgvFood.DataSource, "id", true, DataSourceUpdateMode.Never));
            mnFoodPrice.DataBindings.Add(new Binding("Value",dtgvFood.DataSource,"Price1", true, DataSourceUpdateMode.Never));
        }
        void AddTableBinding()
        {
            txbstatusTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "status",true, DataSourceUpdateMode.Never));
            txbIDTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "id",true,DataSourceUpdateMode.Never));
            txbNumberTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "name",true,DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoCombox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        
        void AddCategory(string name)
        {
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Tạo danh mục sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Tạo danh mục thất bại thất bại");
            }
            LoadListCategory();
        }
        
        void AddAcount(string username, string displayname, int type)
        {
            if (AccountDAO.Instance.InsertAccount(username, displayname, type))
            {
                MessageBox.Show("Tạo tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            LoadAccount();
        }
        void EditAcount(string username, string displayname, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(username, displayname, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }
            LoadAccount();
        }
        void DeleteAcount(string username)
        {
            if (loginAccount.Username.Equals(username))
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
            LoadAccount();
        }
        void ResetPass(string username)
        {
            if (AccountDAO.Instance.ResetPassword(username))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            LoadAccount();
        }
        void AddTable(string name)
        {
            if (TableListDAO.TableDAO.Instance.InsertTable(name))
            {
                MessageBox.Show("Tạo bàn thành công");
            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại");
            }
            LoadListTable();
        }
        #endregion
        #region Events
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIDTable.Text);
            if (TableListDAO.TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công");
                LoadListTable();
                //if (deleteFood != null)
                //    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Không thể xóa bàn");
            }
        }
        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIDTable.Text);
            string name = txbNumberTable.Text;



            if (TableListDAO.TableDAO.Instance.UpdateTable(id, name))
            {
                MessageBox.Show("Sửa bàn thành công");
                LoadListTable();
                //if (updateCategory != null)
                //    updateCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Kiểm tra thông tin");
            }
        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string nametable = txbNumberTable.Text;
            AddTable(nametable);
        }
        private void btnViewTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }
        private void btnDeleteCategory_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIDCategory.Text);
            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListCategory();
                //if (deleteFood != null)
                //    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Kiểm tra thông tin");
            }
        }
       
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIDCategory.Text);
            string name = txbCategory.Text;
           
                      
            
            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListCategory();
                if (updateCategory != null)
                    updateCategory(this, new EventArgs());
            } 
            else
            {
                MessageBox.Show("Kiểm tra thông tin");
            }
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategory.Text;
            AddCategory(name);
        }

        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;

            ResetPass(username);
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string displayname = txbDisplay.Text;
            int type =(int)mnTypeAccount.Value;
            AddAcount(username,displayname,type);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string displayname = txbDisplay.Text;
            int type = (int)mnTypeAccount.Value;
            EditAcount(username, displayname, type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            
            DeleteAcount(username);
        }
        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadlistFood();
        }
        private void btnviewBill_Click(object sender, System.EventArgs e)
        {
           LoadListBillByDate(dtpkStart.Value, dtpkEnd.Value);
        }
        private void txbIDFood_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["idCategory"].Value;

                    Category category = CategoryDAO.Instance.GetCategoryById(id);

                    cbFoodCategory.SelectedItem = category;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbFoodCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i; break;
                        }
                        i++;
                    }
                    cbFoodCategory.SelectedIndex = index;
                }
            }
            catch { }
            

        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int category = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)mnFoodPrice.Value;
            if (FoodDAO.Instance.InsertFood(name, category, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadlistFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Kiểm tra thông tin");
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int category = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)mnFoodPrice.Value;
            int id = Convert.ToInt32(txbIDFood.Text);
            if (FoodDAO.Instance.UpdateFood(id, name, category, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadlistFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Kiểm tra thông tin");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIDFood.Text);
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadlistFood();
                if (deleteFood != null)
                    deleteFood(this,new EventArgs());
            }
            else
            {
                MessageBox.Show("Kiểm tra thông tin");
            }
        }
        private event EventHandler insertFood;
        public event EventHandler Insertfoods 
        { 
            add { insertFood += value; }
            remove { insertFood -= value; }
        }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFoods
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }
        private event EventHandler updateFood;
        public event EventHandler UpdateFoods
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
           foodlist.DataSource = SearchFoodByName(txbSearchFood.Text);
        }












        #endregion

        
    }
}
