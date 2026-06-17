using System;
using System.Collections.Generic;

namespace lab5
{
 
    public static class StrategyPattern
    {
       
        public static List<int> Sort(List<int> list, Comparison<int> strategy)
        {
            var sortedList = new List<int>(list);
            sortedList.Sort(strategy);
            return sortedList;
        }
    }
}
