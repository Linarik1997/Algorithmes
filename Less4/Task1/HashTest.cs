using System;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using System.Collections.Generic;

namespace Less4
{
    class HashTest
    {
        public HashTest(char[] alphabet)
        {
            hashSet = new HashSet<string>();
            Alhabet = alphabet;
        }
        private char[] Alhabet { get; set; }
        public HashSet<string> hashSet { get; set; }

        private string GenerateLine(int lineLength)
        {
            string line = string.Empty;
            var max = Alhabet.Length;
            Random rnd = new Random();
            for(int i = 0; i < lineLength; i++)
            {
                char letter = Alhabet[rnd.Next(0, max)];
                line += letter;
            }
            return line;
        }

        public void FillHashSet(int lineLength,int count)
        {
            for(int i = 0; i < count; i++)
            {
                var line = GenerateLine(lineLength);
                if (!hashSet.Contains(line))
                {
                    hashSet.Add(line);
                }
            }
        }
        public override string ToString()
        {
            string s = string.Empty;
            foreach (var el in hashSet)
            {
                s+=$"data: {el} ; hash: {el.GetHashCode()}\n\r";
            }
            return s;
        }
    }
}
