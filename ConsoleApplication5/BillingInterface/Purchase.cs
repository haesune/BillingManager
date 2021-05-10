using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.BillingInterface
{
    class Purchase
    {
        public int purchaseNo;
        public int useState;
        public int itemId;

        public String userId;
        public String itemName;

        public double price;

        public DateTime regDate;
        public DateTime cnlDate;

        public override string ToString()
        {
            return "purchaseNo:" + purchaseNo + ",userId:" + userId + ",itemId:" + itemId + ",itemName:" + itemName + ",price:" + price + ",useState:" + useState + ",regDate:" + regDate + ",cnlDate:" + cnlDate;
        }
    }
}
