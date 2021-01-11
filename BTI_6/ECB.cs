using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTI_6
{
    class ECB
    {
        DES des = new DES();
        public IEnumerable<IEnumerable<int>> Encrypt(IEnumerable<IEnumerable<int>> data, IEnumerable<int> key) => data.Select(x => des.Encrypt(x, key));
        public IEnumerable<IEnumerable<int>> Decrypt(IEnumerable<IEnumerable<int>> data, IEnumerable<int> key) => data.Select(x => des.Decrypt(x, key));
    }
}