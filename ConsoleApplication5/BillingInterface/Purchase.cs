using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.BillingInterface
{
    class Purchase
    {
        public readonly int purchaseNo;
        public int useState;
        public int itemId;

        public string userId;
        public string itemName;

        public double price;

        public DateTime regDate;
        public DateTime cnlDate;
        public static int purcahseCount;

        public Purchase(string userId){
            purchaseNo = ++ purcahseCount;
            this.userId = userId;
        }

        public override string ToString()
        {
            return "purchaseNo:" + purchaseNo + ",userId:" + userId + ",itemId:" + itemId + ",itemName:" + itemName + ",price:" + price + ",useState:" + useState + ",regDate:" + regDate + ",cnlDate:" + cnlDate;
        }
    }
}
