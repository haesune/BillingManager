using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication5.BillingInterface
{
    class CashUseDtl
    {
        public int cashNo;
        public int purchaseNo;
        public double purchasePrice;
        public override string ToString()
        {
            return "cashNo:" + cashNo + ",purchaseNo:" + purchaseNo + ",purchasePrice:" + purchasePrice;
        }
    }

}

