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
        //caseUseDtl 리스트로 선언함
        List<CashUseDtl> cashUseDtlList = new List<CashUseDtl>();

        //const : 선언시 그 값을 할당해야하며, 한 번 할당된 후 변경 불가능하다 . 즉 변수 정의와 함께 초기화 되어야 하는 상수임
        //readonly: 선언시 값을 할당하지 않아도 가능하며, 생성자에서 한번 더 값 변경 가능 
        public const int itemId = 1000;
        public const double itemPrice = 1000;
        public const String itemName = "testItem";


        public int GetBalance()
        {
            try
            {
                Console.Write("현재잔액 : " + currBalance);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return 0;

        }

        public int InsertCash(int cashAmount)
        {
            Cash cash = new Cash();

            try
            {
                cash.cashNo = cashList.Count + 1;

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

                Console.WriteLine("=====cash 리스트===== ");
                //Q&A)cashList 출력 방법
                for (int i = 0; i < cashList.Count; i++)
                {

                    Console.WriteLine(cashList[i].ToString());
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
            return 0;
        }

        public int RefundCash(int intCashNo)
        {
            try
            {
                for (int i = 0; i < cashList.Count; i++)
                {
                    //구매취소

                    //캐시 취소
                    if (cashList[i].cashNo.Equals(intCashNo))
                    {
                        cashList[i].useState = 2;
                        cashList[i].cnlDate = DateTime.Now;

                        break;
                    }
                }

            }
            catch
            {
                throw new NotImplementedException();
            }
            return 0;
        }

        public int PurchaseItem(int itemNo)
        {

            Cash cash = new Cash();
            Purchase purchase = new Purchase();
            CashUseDtl cashUseDtl = new CashUseDtl();

            int pl_purchaseNo = purchaseList.Count + 1;

            try
            {
                //어떤캐시로 구매할 것인지 확인(구매 가능여부 체크) 
                for (int i = 0; i < cashList.Count; i++)
                {
                    cash = cashList[i].getCashInfo();
                    if (cash.remainAmt > 0)
                    {
                        //해당 캐시 잔액 차감 처리 

                    }
                }

                //cashUseDtl 데이터 입력
                cashUseDtl.cashNo = 123;
                cashUseDtl.groupId = cashUseDtlList.Count + 1;
                cashUseDtl.purchaseNo = pl_purchaseNo;

                //구매 데이터 입력
                purchase.purchaseNo = pl_purchaseNo;

                //Q&A)USER ID 는 어디서 가져와야하는지
                purchase.userId = "admin";
                purchase.itemId = itemNo;
                purchase.itemName = itemName;
                purchase.price = itemPrice;
                purchase.useState = 1;
                purchase.regDate = DateTime.Now;

                purchaseList.Add(purchase);

                Console.WriteLine("구매 개수:" + purchaseList.Count);

                currBalance = currBalance - purchase.price;

                Console.WriteLine("구매 후 잔액 : " + currBalance);


                Console.WriteLine("=====purchaseList 리스트===== ");
                for (int i = 0; i < purchaseList.Count; i++)
                {
                    Console.WriteLine(purchaseList[i].ToString());
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
