using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.BillingInterface
{
    class Cash
    {
        //readonly로 쓰면 생성자에서만 바꿀수 있음
        //안해도되는데 하는 이유는 ? 혼자 짜는 코드가 아니기 떄문에 실수를 방지하기위함 
        public readonly int cashNo;
        public int useState;

        public string userId;

        public double chargeAmt;
        public double remainAmt;

        public DateTime regDate;
        public DateTime cnlDate;

        public static int cashCount;
        

        //기본생성자고 c샵이나 자바에서는 안쓰면 알아서 내부적으로 만드는것
        //public Cash() { }
        //생성자는 매개변수 다르게 할 경우 여러개 만들수있음
        public Cash()
        {
           cashNo = ++ cashCount;
            
        }
        public Cash(string userId) : this()
        {
            this.userId = userId;

        }


        public override string ToString()
        {
            return "cashNo:"+cashNo+ ",userId:" + userId + ",chargeAmt:" + chargeAmt + ",remainAmt:" + remainAmt + ",useState:" + useState + ",regDate:" + regDate+",cnlDate:" + cnlDate;
        }
        
    }
}


