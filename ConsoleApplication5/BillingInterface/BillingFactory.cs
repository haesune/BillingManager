using ConsoleApplication5.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.BillingInterface
{
    public class BillingFactory
    {
        public static BillingManager GetInstance(string userID)
        {
            //C# 은 == 이 텍스트를 비교하는게 맞지만, 자바에서는 주소값이 일치하는지 보는것이라 
            //java에서는 .equals("admin")으로 해야한다.

            //페레 특 : 그냥 equls로 통일하자
            if (userID.Equals("admin"))
            {
                
                return new AdminManager(userID);
            }
            else if (userID.Equals("user1")|| userID.Equals("user2"))
            {
                return new UserManager();
            }
            else {
                throw new UserNotFoundException();
            }

        }
    }
    
}
