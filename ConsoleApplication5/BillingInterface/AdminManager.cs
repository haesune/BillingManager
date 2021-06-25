using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.BillingInterface
{
    public class AdminManager : BillingManager
    {
        readonly string userId = string.Empty;
        double currBalance=0;
        public AdminManager(string userId) {
            this.userId = userId;
        }

        //캐시 등록 리스트로 선언함
        List<Cash> cashList = new List<Cash>();
        //구매 리스트로 선언함
        List<Purchase> purchaseList = new List<Purchase>();
        //caseUseDtl 리스트로 선언함
        List<CashUseDtl> cashUseDtlList = new List<CashUseDtl>();

        //const : 선언시 그 값을 할당해야하며, 한 번 할당된 후 변경 불가능하다 . 즉 변수 정의와 함께 초기화 되어야 하는 상수임
        //readonly: 선언시 값을 할당하지 않아도 가능하며, 생성자에서 한번 더 값 변경 가능 
        //TO DO :클래스로 빼기
        public const int itemId = 1000;
        public const double itemPrice = 1000;
        public const String itemName = "testItem";

        public int GetBalance()
        {
            try
            {
                double totalCurrBalance = 0;

                for (int i = 0; i < cashList.Count; i++) {
                    if (cashList[i].useState.Equals(1)) {
                        totalCurrBalance = totalCurrBalance + cashList[i].remainAmt;
                    }
                }
                currBalance = totalCurrBalance;
                Console.Write("현재잔액 : " + totalCurrBalance);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return 0;
        }

        public int InsertCash(int cashAmount)
        {
            Cash cash = new Cash(userId);

            try
            {
                //++ a a를 플러스 시킨것을 담음 
                //a++ a를 먼저 담고 , 플러스시킴
                //아래 코드는 Cash 클래스의 생성자로 빼냈음. 이제 필요 없 ㅇ! 음 ! 
                //cash.cashNo = ++ Cash.cashCount;
            
                cash.chargeAmt = cashAmount;
                cash.remainAmt = cashAmount;
                cash.useState = 1;
                cash.regDate = DateTime.Now;

                cashList.Add(cash);

                Console.WriteLine("=====cash 리스트===== ");
                //Q&A)cashList 출력 방법
                for (int i = 0; i < cashList.Count; i++)
                {
                    Console.WriteLine(cashList[i]);
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
            //TODO: 환불은 잔액이 충전금액과 다르면 환불 못하게 하기!
            try
            {
                for (int i = 0; i < cashList.Count; i++)
                {
                    //캐시 취소
                    if (cashList[i].cashNo.Equals(intCashNo))
                    {
                        if (cashList[i].chargeAmt != cashList[i].remainAmt)
                        {
                            Console.WriteLine("환불 금액 부족 (구매부터 취소하세요)");
                            return 1;
                        }
                        else {
                            cashList[i].useState = 2;
                            cashList[i].cnlDate = DateTime.Now;
                        }
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
            Purchase purchase = new Purchase(userId);

            try
            {
                //잔액체크
                GetBalance();
                if (currBalance < itemPrice) {
                    //튕겨
                    Console.WriteLine("잔액 부족");
                    return 1;
                }
                double remainItemPrice = itemPrice;
                //어떤캐시로 구매할 것인지 확인(구매 가능여부 체크) 
                for (int i = 0; i < cashList.Count; i++)
                {
                    cash = cashList[i];

                    CashUseDtl cashUseDtl = new CashUseDtl();
                    cashUseDtl.purchaseNo = purchase.purchaseNo;

                    if (cash.remainAmt > 0)
                    {
                        cashUseDtl.cashNo = cash.cashNo;
                        //캐시 잔액 >아이템잔액
                        if (cash.remainAmt >= remainItemPrice)
                        {
                            cashUseDtl.purchasePrice = remainItemPrice;

                            //이걸로 캐시 차감하고 끝
                            cash.remainAmt = cash.remainAmt - remainItemPrice;
                            
                            Console.WriteLine("구매 성공> <");

                            cashUseDtlList.Add(cashUseDtl);
                            //튕김
                            break;
                        } // 캐시 잔액 < 아이템잔액 
                        else
                        {
                            cashUseDtl.purchasePrice = cash.remainAmt;
                            remainItemPrice = remainItemPrice - cash.remainAmt;

                            //한번 포문 더 돌아야함
                            cash.remainAmt = 0;
                            cashUseDtlList.Add(cashUseDtl);

                            continue;
                        }
                    }
                }
                
                purchase.itemId   = itemNo;
                purchase.itemName = itemName;
                purchase.price    = itemPrice;
                purchase.useState = 1;
                purchase.regDate  = DateTime.Now;

                purchaseList.Add(purchase);

                Console.WriteLine("===== purchaseList 리스트 ===== ");
                for (int i = 0; i < purchaseList.Count; i++)
                {
                    Console.WriteLine(purchaseList[i]);
                }

                Console.WriteLine("===== cashUseDtl 리스트 ===== ");
                for (int i = 0; i < cashUseDtlList.Count; i++)
                {
                    Console.WriteLine(cashUseDtlList[i]);
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
            //TODO: 구매취소하고 캐시 돌려주기 -> 환불가능
            //구매한거 먼저 찾아서 취소 , 
            //dtl 테이블에서 해당 구매번호에 사용된 캐시 넘버와 금액 가져오기
            //
            try
            {
                for (int i = 0; i < purchaseList.Count; i++)
                {
                    //구매 취소
                    if (purchaseList[i].purchaseNo.Equals(purchaseNo))
                    {
                        purchaseList[i].useState = 2;
                        purchaseList[i].cnlDate = DateTime.Now;

                        for (int j = 0; j < cashUseDtlList.Count; j++)
                        {
                            if (cashUseDtlList[j].purchaseNo.Equals(purchaseNo))
                            {
                                for (int k= 0; k < cashList.Count; k++)
                                {
                                    if (cashList[k].cashNo.Equals(cashUseDtlList[j].cashNo))
                                    {
                                        cashList[k].remainAmt = cashList[k].remainAmt + cashUseDtlList[j].purchasePrice;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch
            {
                throw new NotImplementedException();
            }
            return 0;
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
            try
            {

                if (purchaseList.Count.Equals(0))
                {

                    Console.WriteLine("===== 구매 목록이 없습니다 ===== ");
                }
                else
                {
                    Console.WriteLine("===== purchaseList 리스트 ===== ");
                    for (int i = 0; i < purchaseList.Count; i++)
                    {
                        Console.WriteLine(purchaseList[i]);
                    }
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
            return 0;

        }

        public int PrintCashHistory(List<BillingManager> objList)
        {
            try
            {
                if (cashList.Count.Equals(0))
                {

                    Console.WriteLine("===== cash 목록이 없습니다 ===== ");
                }
                else
                {
                    Console.WriteLine("=====cash 리스트===== ");

                    for (int i = 0; i < cashList.Count; i++)
                    {
                        Console.WriteLine(cashList[i]);
                    }
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
            return 0;

        }
    }
}
