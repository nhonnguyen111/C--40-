using Kiemtra40_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiemtra40_.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (Instance1 == null) Instance1 = new FoodDAO(); return Instance1; }
            private set { Instance1 = value; }
        }

        public static FoodDAO Instance1 { 
            get => instance; 
            set => instance = value; }

        private FoodDAO() { }
        public List<Foods> GetFoods(int id)
        {
            List<Foods> foods = new List<Foods>();
            string query = "select * from Food where idCategory = "+id+"" ;
            DataTable data = DataProvider.Instance.ExecuQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Foods food = new Foods(row);
                foods.Add(food);
            }
            return foods;
        }
        public List<Foods> GetListFoods()
        {
            List<Foods> list = new List<Foods>();
            string query = "SELECT *  FROM Food ";
            DataTable data = DataProvider.Instance.ExecuQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Foods foods = new Foods(item);
                list.Add(foods);
            }
            return list;
        }

        public bool InsertFood(string name, int id, float price)
        {
            string query =string.Format( "INSERT dbo.Food(name ,idCategory, price)VALUES (N'{0}',{1},{2})", name, id, price);
           int rs =  DataProvider.Instance.ExecuteNonQuery(query);
            return rs > 0;
        }
        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("UPDATE Food SET name = N'{0}', idCategory = {1}, price = {2} where id ={3}", name, id, price,idFood);
            int rs = DataProvider.Instance.ExecuteNonQuery(query);
            return rs > 0;
        }
        public bool DeleteFood(int idFood)
        {
            BillinfoDAO.Instance.DeleteBillInfoFood(idFood);
            string query = string.Format("DELETE Food WHERE id = {0}",  idFood);
            int rs = DataProvider.Instance.ExecuteNonQuery(query);
            return rs > 0;
        }

        public List<Foods> SearchFoodByName(string name)
        {
            List<Foods> foods = new List<Foods>();
            string query =string.Format("SELECT *FROM Food WHERE LOWER(name) COLLATE Latin1_General_CI_AI LIKE '%' + LOWER(N'{0}') + '%'; ", name);
            DataTable data = DataProvider.Instance.ExecuQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Foods food = new Foods(row);
                foods.Add(food);
            }
            return foods;
        }
    }
}
