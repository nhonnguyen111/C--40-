using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiemtra40_.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status, int discount = 0) 
        {
            this.iD = id;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.status = status;
            this.discount = discount;
        }
        public Bill(DataRow row) 
        {
            this.iD = (int)row["ID"];
            this.dateCheckIn = (DateTime?)row["dateCheckIn"];
            var dateCheckTemp = row["dateCheckOut"];
            if(dateCheckTemp.ToString() != "" )
            {
                this.dateCheckOut = (DateTime?)dateCheckTemp;
            }
            
            this.status = (int)row["status"];
            if(row["discount"].ToString() != "")
                this.discount = (int)row["discount"];
        }
        private int discount;
        private int status;
        public int Status { get => status; set => status = value; }
        private DateTime? dateCheckOut;
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        private DateTime? dateCheckIn;
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
