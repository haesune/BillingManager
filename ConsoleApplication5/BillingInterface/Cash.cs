using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.BillingInterface
{
    class Cash
    {
        public int cashNo;
        public int useState;

        public String userId;

        public double chargeAmt;
        public double remainAmt;

        public DateTime regDate;
        public DateTime cnlDate;

        public override string ToString()
        {
            return "cashNo:"+cashNo+ ",userId:" + userId + ",chargeAmt:" + chargeAmt + ",remainAmt:" + remainAmt + ",useState:" + useState + ",regDate:" + regDate+",cnlDate:" + cnlDate;
        }
        public Cash getCashInfo() {
            Cash cash = new Cash();

            cash.cashNo = cashNo;
            cash.chargeAmt = chargeAmt;
            cash.remainAmt = remainAmt;

            return cash;
        }
    }
}

}
