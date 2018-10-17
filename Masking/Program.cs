using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masking
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = 1234567890;
            string mask = "(xxx) xxx-xxxx";
            char replace = 'x';
            Console.WriteLine(ApplyMask(number, mask, replace));
            Console.ReadLine();
        }
        static string ApplyMask(decimal num, string mask, char replace)
        {
            string output = "";
            Stack<char> inputs = new Stack<char>();
            Stack<char> maskChars = new Stack<char>();
            string numString = num.ToString();
            for(int i = numString.Length -1; i >= 0; i--)
            {
                inputs.Push(numString[i]);
            }
            for (int i = mask.Length - 1; i >= 0; i--)
            {
                maskChars.Push(mask[i]);
            }
            while(inputs.Count != 0 && maskChars.Count != 0)
            {
                char thisChar = maskChars.Pop();
                if(thisChar == replace)
                {
                    output += inputs.Pop();
                }
                else
                {
                    output += thisChar;
                }
            }
            return output;
        }
    }
}
