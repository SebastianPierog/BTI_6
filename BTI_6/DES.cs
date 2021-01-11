using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BTI_6
{
    class DES
    {
        static int[] IP = new int[] { 58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4, 62, 54, 46, 38, 30, 22, 14, 6, 64, 56, 48, 40, 32,
            24, 16, 8, 57, 49, 41, 33, 25, 17, 9, 1, 59, 51, 43, 35, 27, 19, 11, 3, 61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7 };
        static Random rnd = new Random();
        static int[] IP_1 = new int[] { 40, 8, 48, 16, 56, 24, 64, 32, 39, 7, 47, 15, 55, 23, 63, 31, 38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53,
            21, 61, 29, 36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27, 34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9, 49, 17, 57, 25 };
        static int[] PC_1 = new int[] { 57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18, 10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36, 63,
            55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22, 14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4 };
        static int[] PC_2 = new int[] { 14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10, 23, 19, 12, 4, 26, 8, 16, 7, 27, 20, 13, 2, 41, 52, 31, 37, 47, 55,
            30, 40, 51, 45, 33, 48, 44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32 };
        static int[] E = new int[] { 32, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9, 8, 9, 10, 11, 12, 13, 12, 13, 14, 15, 16, 17, 16, 17, 18, 19, 20, 21, 20, 21,
            22, 23, 24, 25, 24, 25, 26, 27, 28, 29, 28, 29, 30, 31, 32, 1 };
        static int[] Shifts = new int[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };
        static int[] S1 = new int[] { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7, 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8, 4, 1,
            14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0, 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 };
        static int[] S2 = new int[] { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10, 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5, 0, 14,
            7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15, 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 };
        static int[] S3 = new int[] { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8, 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1, 13, 6,
            4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7, 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 };
        static int[] S4 = new int[] { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15, 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9, 10, 6,
            9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4, 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 };
        static int[] S5 = new int[] { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9, 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6, 4, 2, 1,
            11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14, 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 };
        static int[] S6 = new int[] { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11, 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8, 9, 14,
            15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6, 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 };
        static int[] S7 = new int[] { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1, 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6, 1, 4,
            11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2, 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 };
        static int[] S8 = new int[] { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7, 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2, 7, 11,
            4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8, 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 };
        static int[][] S = new int[8][] { S1, S2, S3, S4, S5, S6, S7, S8 };
        static int[] P = new int[] { 16, 7, 20, 21, 29, 12, 28, 17, 1, 15, 23, 26, 5, 18, 31, 10, 2, 8, 24, 14, 32, 27, 3, 9, 19, 13, 30, 6, 22, 11, 4, 25 };
        IEnumerable<T> Shift<T>(IEnumerable<T> data, int shift) => Enumerable.Range(0, data.Count()).Select(x => data.ElementAt((((x + shift) % data.Count()) + data.Count()) % data.Count()));
        IEnumerable<T>[] Split<T>(IEnumerable<T> data) => new List<T>[] { data.Take(data.Count() / 2).ToList(), data.Skip(data.Count() / 2).ToList() };
        IEnumerable<T> GetE<T>(IEnumerable<T> data) => E.Select(x => data.ElementAt(x - 1));
        IEnumerable<int> XOR(IEnumerable<int> A, IEnumerable<int> B) => A.Zip(B, (a, b) => a ^ b);
        IEnumerable<int> GetS(string input, int index)
        {
            var i = Convert.ToInt32(string.Join("", new char[] { input.First(), input.Last() }), 2);
            var j = Convert.ToInt32(string.Join("", input.Skip(1).Take(4)), 2);
            return Convert.ToString(S[index].ElementAt(i * 16 + j), 2).PadLeft(4, '0').Select(x => (int)char.GetNumericValue(x));
        }
        IEnumerable<int> f(IEnumerable<int> R, IEnumerable<int> K)
        {
            var boxes = Regex.Matches(string.Join("", XOR(GetE(R), K)), "......").Cast<Match>().Select(x => x.Value).ToList();
            var afterS = string.Join("", Enumerable.Range(0, 8).Select(x => GetS(boxes[x], x).ToArray()).Select(x => string.Join("", x)))
                .Select(x => (int)char.GetNumericValue(x)).ToList(); ;
            return P.Select(x => afterS.ElementAt(x - 1));
        }
        IEnumerable<int> To64Bit(IEnumerable<int> input) => Enumerable.Repeat(0, Math.Max(0, 64 - input.Count())).Concat(input).Take(64);
        IEnumerable<int> DESAlgorithm(IEnumerable<int> data, IEnumerable<int> key, bool decryption = false)
        {
            data = data.To64BitK();
            key = key.To64BitK();
            var cd = new List<IEnumerable<int>[]>() { Split(PC_1.Select(x => key.ElementAt(x - 1))) };
            Enumerable.Range(0, 16).ToList().ForEach(x => cd.Add(cd[x].Select(y => Shift(y, Shifts[x]).ToList()).ToArray()));
            var K = cd.Skip(1).Select(x => x.ToList()).Select(x => x[0].Concat(x[1]).ToList()).Select(x => PC_2.Select(y => x.ElementAt(y - 1)).ToList()).ToList();

            if (decryption)
                K.Reverse();

            var LR = new List<IEnumerable<int>[]>() { Split(IP.Select(x => data.ElementAt(x - 1))) };
            Enumerable.Range(0, 16).ToList().ForEach(i => LR.Add(new IEnumerable<int>[] { LR[i][1], XOR(LR[i][0], f(LR[i][1], K[i])) }));

            var RL = LR[LR.Count - 1][1].Concat(LR[LR.Count - 1][0]);
            var final = IP_1.Select(x => RL.ElementAt(x - 1));

            return final;
        }
        public IEnumerable<int> Encrypt(IEnumerable<int> data, IEnumerable<int> key) => DESAlgorithm(data, key);
        public IEnumerable<int> Decrypt(IEnumerable<int> data, IEnumerable<int> key) => DESAlgorithm(data, key, true);
        public static IEnumerable<int> GenerateRandomData() => Enumerable.Range(0, 64).Select(x => rnd.Next(0, 2));
    }
}