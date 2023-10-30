using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiemtra40_.DTO
{
    public class Menu
    {
        public Menu(string foodName, int count, float price, float totalprice = 0) 
        {
            this.FoodName = foodName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalprice;
        }
        public Menu(DataRow row)
        {
            this.FoodName = row["name"].ToString();
            this.Count =(int)row["count"] ;
            this.Price = (float)Convert.ToDouble(row["price"].ToString()) ;
            this.TotalPrice = (float)Convert.ToDouble(row["totalprice"].ToString());
        }
        private float totalPrice;
        private float price;
        private int count;
        private string FoodName;

        public string FoodName1 { get => FoodName; set => FoodName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
