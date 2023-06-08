using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class MyGenericClass<T> : MyGenericInterface<T>
    {
        public void GenericMethod(T parameter)
        {
            Console.WriteLine("GenericMethod called with parameter: " + parameter);
        }
    }
}
