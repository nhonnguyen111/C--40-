using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiemtra40_.DTO
{
    public class Foods
    {
        public Foods(int id, string name, string idcategory, float price) 
        {
            this.iD = id;
            this.name = name;
            this.IDCategory = idcategory;
            this.Price = price;
            
        }
        public Foods(DataRow row)
        {
            this.iD = (int)row["ID"];
            this.name = row["Name"].ToString();         
            this.IDCategory = row["name"].ToString();
            this.Price = (float)Convert.ToDouble(row["Price"].ToString());
        }
       
        private int iD;
        private string name;
        private string iDCategory;
        private float price;

        [DisplayName("STT")]
        public int ID { get => iD; set => iD = value; }
        [DisplayName("Tên món")]
        public string Name { get => name; set => name = value; }
        [DisplayName("Danh Mục")]
        public string IDCategory { get => iDCategory; set => iDCategory = value; }
        [DisplayName("Giá")]
        public float Price { get => price; set => price = value; }
    }
}
