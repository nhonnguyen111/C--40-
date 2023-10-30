using Kiemtra40_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kiemtra40_.DAO.TableListDAO;

namespace Kiemtra40_.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance {
            get { if (instance == null) instance = new MenuDAO(); return instance; }
            private set { instance = value; }
        }
        private MenuDAO() { }
        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> list = new List<Menu>();
            string query = "SELECT f.name, bi.count, f.price, f.price*bi.count as totalPrice FROM dbo.BillInfo as bi, dbo.Bill as b, dbo.Food as f\r\nWHERE bi.idBill = b.id and bi.idFood = f.id and b.status = 0 and b.idTable =" + id;
            DataTable data = DataProvider.Instance.ExecuQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                list.Add(menu);
            }
            return list;
        }
    }
}
