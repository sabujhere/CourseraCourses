using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMathOperations
{
    public class StringSubtractorImpl : IStringSubtractor
    {
        public string Subtruction(string term1, string term2)
        {
            
            if (term1.Length < term2.Length)
            {
                Swap(ref term1,ref term2);
            }
        }
    }
}
