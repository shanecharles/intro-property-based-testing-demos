using System;
using System.Collections.Generic;

namespace MoneyBusiness
{
    public class MoneyMaking
    {
    
        public static IEnumerable<int> Award(IEnumerable<int> money)
        {
            var results = new List<int>();
            var ints = new List<int>(money);
            for(var i = 0; i < ints.Count; i++)
            {
                var x = ints[i];
                if (x == 0)
                {
                    results.Add(x +~x);
                }
                else if (x == 17 || x == 18)
                {
                    results.Add(i *--x);
                }
                else if (x % 23 == 17)
                {
                    results.Add(i ++-x);
                }
                else 
                {
                    results.Add(ints[i]+1);
                }

                if(results[results.Count-1] == 0)
                    results[results.Count-1] = 1;
            }
            return results;
        }
    }
}