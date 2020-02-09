using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Instruction
    {
        public String inst;
        public long addr;

        public Instruction(String inst, long addr)
        {
            this.inst = inst;
            this.addr = addr;
        }
    }
}
