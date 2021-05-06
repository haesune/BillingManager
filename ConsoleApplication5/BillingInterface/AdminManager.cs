using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.BillingInterface
{
    public class AdminManager : BillingManager
    {
        double currBalance = 0;

        //캐시 등록 리스트로 선언함
        List<Cash> cashList = new List<Cash>();
        //구매 리스트로 선언함
        List<Purchase> purchaseList = new List<Purchase>();

        public int GetBalance()
        {
            try {
                Console.Write("현재잔액 : " + currBalance);
            }            
            catch{
                throw new NotImplementedException();
            }
            return 0;

        }

        public int InsertCash(int cashAmount)
        {
            Cash cash = new Cash();

            try
            {
                cash.cashNo = cashList.Count+1;
                //Q&A)USER ID 는 어디서 가져와야하는지
                cash.userId = "admin";
                cash.chargeAmt = cashAmount;
                cash.remainAmt = cashAmount;
                cash.useState = 1;
                cash.regDate = DateTime.Now;


                cashList.Add(cash);

                Console.WriteLine("캐시 개수:" + cashList.Count);

                currBalance = currBalance + cashAmount;

                Console.WriteLine("충전 금액 : " + cashAmount);
                Console.WriteLine("충전 후 잔액 : " + currBalance);

                //Q&A)cashList 출력 방법
                for (int i = 0; i < cashList.Count; i++) {

                    Console.WriteLine( cashList[i]);
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
            return 0;
        }

        public int RefundCash(int cashNo)
        {           
            throw new NotImplementedException();           
        }

        public int PurchaseItem(int itemNo)
        {

            Purchase purchase = new Purchase();

            try
            {
                //어떤캐시로 구매할 것인지 확인(구매 가능여부 체크) 
                for (int i = 0; i < cashList.Count; i++)
                {

                }
                //해당 캐시 잔액 차감 처리 

                //cashUseDtl 데이터 입력

                //구매 데이터 입력
                purchase.purchaseNo = purchaseList.Count + 1;
                //Q&A)USER ID 는 어디서 가져와야하는지
                purchase.userId = "admin";
                purchase.itemId = itemNo;
                purchase.itemName = "item";
                purchase.price = 10 ;
                purchase.useState = 1;
                purchase.regDate = DateTime.Now;
                
                purchaseList.Add(purchase);

                Console.WriteLine("구매 개수:" + purchaseList.Count);

                currBalance = currBalance - purchase.price;

                Console.WriteLine("구매 후 잔액 : " + currBalance);

                //Q&A)purchaseList 출력 방법
                for (int i = 0; i < purchaseList.Count; i++)
                {
                    Console.WriteLine(purchaseList[i]);
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
            return 0;
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
