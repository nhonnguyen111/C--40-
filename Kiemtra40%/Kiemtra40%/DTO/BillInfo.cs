using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiemtra40_.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int Billid, int Foodid, int count)
        {
            this.iD = id;
            this.BillID1 = Billid;
            this.foodID = Foodid;
            this.count = count;
        }
        public BillInfo(DataRow row) 
        {
            this.iD = (int)row["ID"];
            this.BillID1 = (int)row["idBill"];
            this.foodID = (int)row["idFood"];
            this.count= (int)row["Count"];
        }
        private int count;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public int BillID1 { get => BillID; set => BillID = value; }
        public int FoodID { get => foodID; set => foodID = value; }
        public int Count { get => count; set => count = value; }

        private int BillID;
        private int foodID;
    }
}
