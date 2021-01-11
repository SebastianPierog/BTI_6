using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTI_6
{
    public static class Method
    {
        public static IEnumerable<int> ToIntList(this string data) => data.Replace(" ", string.Empty).Select(x => (int)char.GetNumericValue(x)).ToList();
        public static IEnumerable<IEnumerable<int>> ToIntList(this IEnumerable<string> data)
        {
            List<List<int>> list = new List<List<int>>();

            foreach (var item in data)
            {
                var behindList = new List<int>();
                behindList = item.ToIntList().ToList();
                list.Add(behindList);
            }

            return list;
        }
        public static string ListToString(this IEnumerable<int> data) => string.Join("", data);
        public static IEnumerable<int> To64BitK(this IEnumerable<int> input) => Enumerable.Repeat(0, Math.Max(0, 64 - input.Count())).Concat(input);
    }
}
