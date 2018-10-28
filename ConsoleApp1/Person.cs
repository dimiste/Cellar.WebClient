using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        private int b;
        public int A { get; set; }

        public int B { get { return this.B; } set { this.B = this.A + 5; } }
    }
}
