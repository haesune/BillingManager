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
        //메인 응용프로그램
        static void Main(string[] args)
        {
            //유저 여러개라 리스트로 선언함
            List<BillingManager> managers = new List<BillingManager>();
            //인터페이스 선언 (usermanager, adminmanager에서 상속받아서 사용할거)
            BillingManager manager = null;
            //입력받는값선언
            string input = string.Empty;

            do{
                PrintLoginMenu(out input);
                
                try
                {
                    //입력받은 아이디를 통해 인터페이스(BillingManager)를 받는거긴 한데 인터페이스는 객체 생성을 할 수 없음
                    //따라서 BillingManager를 상속받고 있는 UserManger or AdminManager 선언을 한다
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
                //10 : 로그인 변경 입력시에만 실행
                if(input.Equals(10)){
                    //새로운 아이디로 유저/어드민 객체 생성
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
                //입력받은 메뉴실행
                //managers는 그동안 모든 회원들의 정보가 담겨있음
                //manager 는 현재 로그인된 계정
                DoMenu(manager, input, managers);

            } while (!input.Equals("11"));
            
        }
        //private 선언으로 다른 클래스에서 호출할수 없음
        //static 함수나 변수는 heap 올라가고, 나머지는 stack에 쌓이고 
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
                    Console.Write("충전할 캐시금액입력:");
                    int amt = Convert.ToInt32(Console.ReadLine());
                    pl_RetVal = manager.InsertCash(amt);
                    break;
                case "3":
                    Console.Write("환불할 캐시번호 입력:");
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
         //   Console.Clear();
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
