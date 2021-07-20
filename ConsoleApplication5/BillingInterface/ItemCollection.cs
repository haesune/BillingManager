using System.Collections.Generic;

namespace ConsoleApplication5.BillingInterface
{
    class ItemCollection
    {
        //1. 멤버변수선언
        //List<Item> itemCollection;
        //
        //2. 프로퍼티 선언
        // List<Item> itemCollection { get; set; }
        //     
        //1번은 클래스 내부에 멤버변수를 직접 접근하면 은닉성 조건에 위배되는거에용
        //그래서 getter와 setter를 사용해야합니다(자바 C# 공통)
        //하지만 프로퍼티는 getter 와 setter를 자동으로 생성해주기 때문에 사용하는거에용
        //멤버변수는 private 로 은닉성을 유지해야합니다

        //접근하려면 getter 와 setter를 public으로 선언해서 접근하면됩니다
        //위에 말한 2번자체가 이런과정들이 생략되어서 {get; set;} 된거라는걸 설명한거에용
        // public class Test
        //    {
        //        public int a;
        //    }
        
        //    이런식으로 클래스 작성하면 근본이 없는 코더에요
        //   
        //    public class Test
        //    {
        //        public int a { get; set};
        //    }
        //    이런식으로 작성해야 제대로 배운 개발자입니다
        
        //    public class Test
        //    {
        //        private int a;
        //        public int getA()
        //        {
        //            return a;
        //        }
        //        public int setA(int a)
        //        {
        //            this.a = a;
        //        }
        //    }
        //    이것도 동일한 의미로 생략해서 { get; set; }
        //    이 된거입니당
        //
        public List<Item> itemList
        {
            get; set; 
        }

        //생성자의 역할 : 멤버변수 초기화 
        //멤버변수를 바로 초기화 하면 안되는 이유 : 변수는 언제든지 초기화 시킬 수 있어야함 
        //만약 멤버변수에 초기화를 시키면,
        //step1. 클래스 초기화
        //step2. 멤버변수 초기화 
        //setp1,step2가 같이 이뤄져야하는데 , 멤버변수를 선언과 동시에 초기화 하면 setp1,2를 거쳐야함 
        //따라서 아래의 생성자를 쓰임으로서, 클래스 초기화 시 멤버변수 itemList 초기화 하겠다고 한방에 빠악! 
        public ItemCollection()
        {
            itemList = new List<Item>();

            //hardcoding
            itemList.Add(new Item(1000, "test1", 1000));
            itemList.Add(new Item(1001, "test2", 100));
            itemList.Add(new Item(1002, "test3", 500));

        }

        public Item findByItemID(int itemId) {
            for (int i = 0; i < itemList.Count; i++) {
                if (itemList[i].itemId.Equals(itemId)) {
                    return itemList[i];
                }
            }
            return null;
        }
    }
}