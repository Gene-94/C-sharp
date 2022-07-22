using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex_3_1_a;

namespace Ex_3_1_b
{
    public class Person : Ex_3_1_a.Person
    {
        new public int Age{set; get;}
    }
}