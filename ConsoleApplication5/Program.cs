using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication5.BillingInterface;
using ConsoleApplication5.Exceptions;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BillingManager> managers = new List<BillingManager>();
            BillingManager manager = null;
            string input = string.Empty;

            do{
                PrintLoginMenu(out input);
                
                try
                {
                    manager = BillingFactory.GetInstance(input);
                }
                catch(UserNotFoundException ex){
                    Console.WriteLine(ex.Message);
                }
            } while(manager == null);
            managers.Add(manager);

            do
            {
                PrintMenu(out input);

                if(input.Equals(10)){
                    do
                    {
                        PrintLoginMenu(out input);

                        try
                        {
                            manager = BillingFactory.GetInstance(input);
                        }
                        catch (UserNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    } while (manager == null);
                    managers.Add(manager);
                }

                DoMenu(manager, input, managers);

            } while (!input.Equals("11"));
            
        }

        private static void PrintLoginMenu(out string input){
            Console.WriteLine("로그인할 아이디를 입력해주세요");
            input = Console.ReadLine();

            Console.Clear();
        }

        private static void PrintMenu(out string input)
        {
            Console.WriteLine("1. 잔액조회");
            Console.WriteLine("2. 캐시충전");
            Console.WriteLine("3. 캐시 환불");
            Console.WriteLine("4. 아이템 구매");
            Console.WriteLine("5. 아이템 취소");
            Console.WriteLine("6. 나의캐시 내역보기");
            Console.WriteLine("7. 나의보유 아이템 내역 보기");
            Console.WriteLine("8. 캐시변경 내역 보기");
            Console.WriteLine("9. 구매변경 내역 보기");
            Console.WriteLine("10. 로그인변경");
            Console.WriteLine("11. 종료");
            input = Console.ReadLine();
        }

        private static void DoMenu(BillingManager manager, string input, List<BillingManager> managers)
        {
            int pl_RetVal = 0;
            switch (input)
            {
                case "1":
                    pl_RetVal = manager.GetBalance();
                    break;
                case "2":
                    Console.Write("충전할 캐시금액입력");
                    int amt = Convert.ToInt32(Console.ReadLine());
                    pl_RetVal = manager.InsertCash(amt);
                    break;
                case "3":
                    Console.Write("환불할 캐시번호 입력");
                    int cashno = Convert.ToInt32(Console.ReadLine());
                    pl_RetVal = manager.InsertCash(cashno);
                    break;
                case "4":
                    Console.Write("구매 할 아이템 번호 입력");
                    int itemNo = Convert.ToInt32(Console.ReadLine());
                    pl_RetVal = manager.PurchaseItem(itemNo);
                    break;
                case "5":
                    Console.Write("취소 할 구매 번호 입력");
                    int purchaseNo = Convert.ToInt32(Console.ReadLine());
                    pl_RetVal = manager.PurchaseCancelItem(purchaseNo);
                    break;
                case "6":
                    pl_RetVal = manager.PrintCashList();
                    break;
                case "7":
                    pl_RetVal = manager.PrintItemList();
                    break;
                case "8":
                    pl_RetVal = manager.PrintCashHistory(managers);
                    break;
                case "9":
                    pl_RetVal = manager.PrintItemPurchaseHistory(managers);
                    break;
            }
            Console.Clear();
            if (pl_RetVal.Equals(0))
            {
                Console.WriteLine("성공");
            }
            else
            {
                Console.WriteLine("실패");
            }
        }
    }

}
