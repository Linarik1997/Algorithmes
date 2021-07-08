using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less4.Task1
{
    class ArrayTest
    {
        private char[] Alhabet { get; set; }
        public string[] Array { get; set; }

        public ArrayTest(char[] alphabet, int arrayLength)
        {
            this.Alhabet = alphabet;
            Array = new string[arrayLength];
        }
        private string GenerateLine(int lineLength)
        {
            string line = string.Empty;
            var max = Alhabet.Length;
            Random rnd = new Random();
            for (int i = 0; i < lineLength; i++)
            {
                char letter = Alhabet[rnd.Next(0, max)];
                line += letter;
            }
            return line;
        }
        public void FillArray(int lineLength)
        {
            for(int i = 0; i < Array.Length; i++)
            {
                Array[i] = GenerateLine(lineLength);
            }
        }       
    }
}
