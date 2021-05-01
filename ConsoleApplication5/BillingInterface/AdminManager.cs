using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.BillingInterface
{
    public class AdminManager : BillingManager
    {
        int currBalance = 0;
        public int GetBalance()
        {
            try {
                Console.WriteLine("현재잔액 : " + currBalance);
            }            
            catch{ 
            
            }
            return 0;

        }

        public int InsertCash(int cashAmount)
        {
            throw new NotImplementedException();
        }

        public int RefundCash(int cashNo)
        {
            throw new NotImplementedException();
        }

        public int PurchaseItem(int itemNo)
        {
            throw new NotImplementedException();
        }

        public int PurchaseCancelItem(int purchaseNo)
        {
            throw new NotImplementedException();
        }

        public int PrintItemList()
        {
            throw new NotImplementedException();
        }

        public int PrintCashList()
        {
            throw new NotImplementedException();
        }

        public int PrintItemPurchaseHistory(List<BillingManager> objList)
        {
            throw new NotImplementedException();
        }

        public int PrintCashHistory(List<BillingManager> objList)
        {
            throw new NotImplementedException();
        }
    }
}
