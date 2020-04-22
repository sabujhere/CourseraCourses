using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMathOperations
{
    public class KaratsubaStringMultiplicationImpl : IStringMultiplicator
    {
        public IStringAddition StringAddition => new StringAdditionImpl();
        public IStringSubtractor StringSubtractor =>new StringSubtractorImpl();

        public string Multiply(string term1, string term2)
        {
            if (term1.Length == 1 && term2.Length == 1)
                return $"{int.Parse(term1) * int.Parse(term2)}";

            if (term1.Length < term2.Length)
                term1 = term1.PadLeft(term2.Length, '0');
            if (term2.Length < term1.Length)
                term2 = term2.PadLeft(term1.Length, '0');

            var cutPosition = GetCutPosition(term1, term2);
            
            var a = term1.Remove(term1.Length - cutPosition);
            var b = term1.Substring(term1.Length - cutPosition);
            var c = term2.Remove(term2.Length - cutPosition);
            var d = term2.Substring(term2.Length - cutPosition);

            var ac = Multiply(a, c);
            var bd = Multiply(b, d);
            var a_b_c_d = Multiply(StringAddition.Add(a, b), StringAddition.Add(c, d));
            return CalculateResult(ac, bd, a_b_c_d, b.Length + d.Length);
        }
        private string CalculateResult(string ac, string bd, string ab_cd, int padding)
        {
            string term0 = StringSubtractor.Subtract(StringSubtractor.Subtract(ab_cd, ac), bd);
            string term1 = term0.PadRight(term0.Length + padding / 2, '0');
            string term2 = ac.PadRight(ac.Length + padding, '0');
            return StringAddition.Add(StringAddition.Add(term1, term2), bd);
        }

        private static int GetCutPosition(string a, string b)
        {
            var minLength = Math.Min(a.Length, b.Length);
            if (minLength == 1)
                return 1;
            if (minLength % 2 == 0)
                return minLength / 2;
            return minLength / 2 + 1;
        }
    }
}
