using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BTI_6
{
    class Program
    {
        static void Main(string[] args)
        {
            ECB ecb = new ECB();
            CBC cbc = new CBC();
            List<string> lString = new List<string>();
            string line;
            var textPath = @"C:\Users\Sebastian\Desktop\text2.txt";
            var keyPath = @"C:\Users\Sebastian\Desktop\key1.txt";
            var vectorPath = @"C:\Users\Sebastian\Desktop\vector.txt";
            StreamReader textFromStream = new StreamReader(textPath);
            StreamReader keyFromStream = new StreamReader(keyPath);
            StreamReader vectorFromStream = new StreamReader(vectorPath);

            while ((line = textFromStream.ReadLine()) != null)
                lString.Add(line);

            List<IEnumerable<int>> textList = lString.ToIntList().ToList();
            List<int> key = keyFromStream.ReadToEnd().ToIntList().ToList();
            List<int> vector = vectorFromStream.ReadToEnd().ToIntList().ToList();

            Console.WriteLine("----------------------ECB----------------------");
            Console.WriteLine($"Key (64-bit): {key.ListToString()}");
            Console.WriteLine($"Input text (64-bit): ");
            foreach (var item in textList)
                Console.WriteLine(item.ListToString());
            Console.WriteLine();
            var encryptedECB = ecb.Encrypt(textList, key);
            Console.WriteLine($"Coded: ");
            foreach (var item in encryptedECB)
                Console.WriteLine(item.ListToString());
            Console.WriteLine();
            var decryptedECB = ecb.Decrypt(encryptedECB, key);
            Console.WriteLine($"Encoded: ");
            foreach (var item in decryptedECB)
                Console.WriteLine(item.ListToString());

            Console.WriteLine();

            Console.WriteLine("----------------------CBC----------------------");
            Console.WriteLine($"Key (64-bit): {key.ListToString()}");
            Console.WriteLine($"Vector (64-bit): {vector.ListToString()}");
            Console.WriteLine($"Input text (64-bit): ");
            foreach (var item in textList)
                Console.WriteLine(item.ListToString());
            Console.WriteLine();
            var encryptedCBC = cbc.Encrypt(textList, key, vector);
            Console.WriteLine($"Coded: ");
            foreach (var item in encryptedCBC)
                Console.WriteLine(item.ListToString());
            Console.WriteLine();
            var decryptedCBC = cbc.Decrypt(encryptedCBC, key, vector);
            Console.WriteLine($"Encoded: ");
            foreach (var item in decryptedCBC)
                Console.WriteLine(item.ListToString());

            Console.ReadLine();
        }
    }
}