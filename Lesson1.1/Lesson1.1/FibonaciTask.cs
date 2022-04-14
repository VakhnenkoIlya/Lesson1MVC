using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson1._1
{
    class FibonaciTask<T>
    {
        private readonly Func<T> _Fibonaci;
        private Thread _thread;
        private T _Result;
        public T Result
        {
            get
            {
                if(_thread == null)
                {
                    Start();
                }
                _thread.Join();
                return _Result;
            }
        }

        public FibonaciTask(Func<T> Fibonaci) => _Fibonaci = Fibonaci;

        public void Start()
        {
            if (_thread != null) return;
            _thread = new Thread(Fibonaci);
            _thread.IsBackground = true;
            _thread.Start();
        }
        private void Fibonaci()
        {
           _Result = _Fibonaci();
        }
    }
}
