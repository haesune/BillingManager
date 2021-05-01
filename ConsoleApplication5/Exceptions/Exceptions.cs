using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Exceptions
{
    class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base("사용자를 찾을수 없습니다.")
        {

        }
    }

    class UnAuthorizationException : Exception
    {
        public UnAuthorizationException(string userName)
            : base(userName + "님은 권한이 없습니다.")
        {
        }
    }
}
