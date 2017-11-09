using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroGame
{
    class MyException: Exception
    { 
        // задание 5 создание собственного исключения
        public MyException()
        {
            Console.WriteLine("My Exception");
        }
    }
}
