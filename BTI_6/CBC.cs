using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTI_6
{
    class CBC
    {
        DES des = new DES();
        private IEnumerable<IEnumerable<int>> CBCAlgorithm(IEnumerable<IEnumerable<int>> data, IEnumerable<int> key, IEnumerable<int> vector, bool decryption = false)
        {
            var list = new List<List<int>>();
            List<int> transitional;
            if (!decryption)
            {
                foreach (var item in data)
                {
                    transitional = ModuloSum(item, vector);
                    vector = des.Encrypt(transitional, key);
                    list.Add(vector.ToList());
                }
            }
            else
            {
                foreach (var item in data)
                {
                    transitional = des.Decrypt(item, key).ToList();
                    list.Add(ModuloSum(transitional, vector));
                    vector = item;
                }
            }

            return list;
        }

        private List<int> ModuloSum(IEnumerable<int> item, IEnumerable<int> vector)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < item.Count(); i++)
                result.Add((item.ElementAt(i) + vector.ElementAt(i)) % 2);

            return result;
        }

        public IEnumerable<IEnumerable<int>> Encrypt(IEnumerable<IEnumerable<int>> data, IEnumerable<int> key, IEnumerable<int> vector) => CBCAlgorithm(data, key, vector);
        public IEnumerable<IEnumerable<int>> Decrypt(IEnumerable<IEnumerable<int>> data, IEnumerable<int> key, IEnumerable<int> vector) => CBCAlgorithm(data, key, vector, true);
    }
}