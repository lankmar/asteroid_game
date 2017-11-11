using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroGame
{

    public delegate void LogMessage(object o);
    
    
    class Log
    {
        LogMessage myDelegate;

        public void PrintMessage(LogMessage f)
        {
            myDelegate += f;
        }

        public void Start()
        {
            if (myDelegate != null) myDelegate(this);
        }
    }
}
