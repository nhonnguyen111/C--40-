﻿using System;
using System.Collections.Generic;
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
            this.name = row["Tên món"].ToString();         
            this.IDCategory = row["Danh mục"].ToString();
            this.Price = (float)Convert.ToDouble(row["Giá"].ToString());
        }
       
        private int iD;
        private string name;
        private string iDCategory;
        private float Price;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string IDCategory { get => iDCategory; set => iDCategory = value; }
        public float Price1 { get => Price; set => Price = value; }
        
    }
}
