using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Common
    {
        static public long S2l(String s)
        {
            long i = 0;

            try
            {
                i = long.Parse(s.Trim());
            }
            catch (FormatException e)
            {
                Console.WriteLine("NumberFormatException: " + e.Message);
            }

            return i;
        }

        static public int S2i(String s)
        {
            int i = 0;

            try
            {
                i = int.Parse(s.Trim());
            }
            catch (FormatException e)
            {
                Console.WriteLine("NumberFormatException: " + e.Message);
            }

            return i;
        }

        static public byte S2b(String s)
        {
            int i = 0;
            byte b = 0;

            try
            {
                i = int.Parse(s.Trim());
            }
            catch (FormatException e)
            {
                Console.WriteLine("NumberFormatException: " + e.Message);
            }
            b = (byte)i;
            return b;
        }

        public static long RandomLong(long MAX)
        {
            long i = -1;

            Random generator = new Random(Guid.NewGuid().GetHashCode());
            while (i > MAX || i < 0)
            {
                int intOne = generator.Next();
                int intTwo = generator.Next();
                i = (long)intOne + intTwo;
            }
            return i;
        }
    }
}
