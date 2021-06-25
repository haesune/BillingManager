using System.Collections.Generic;

namespace ConsoleApplication5.BillingInterface
{
    class ItemList
    {

        List<Item> itemList;

        //생성자의 역할 : 멤버변수 초기화 
        //멤버변수를 바로 초기화 하면 안되는 이유 : 변수는 언제든지 초기화 시킬 수 있어야함 
        //만약 멤버변수에 초기화를 시키면,
        //step1. 클래스 초기화
        //step2. 멤버변수 초기화 
        //setp1,step2가 같이 이뤄져야하는데 , 멤버변수를 선언과 동시에 초기화 하면 setp1,2를 거쳐야함 
        //따라서 아래의 생성자를 쓰임으로서, 클래스 초기화 시 멤버변수 itemList 초기화 하겠다고 한방에 빠악! 
        public ItemList()
        {
            itemList = new List<Item>();

            //hardcoding
            itemList.Add(new Item(1000,"test1",1000));
            itemList.Add(new Item(1001, "test2", 100));
            itemList.Add(new Item(1002, "test3", 500));

        }
    }
}


