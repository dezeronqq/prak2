using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class CaesarCipher
    {
        private string plainText;
        private int shift;

        public CaesarCipher(string plainText, int shift)
        {
            this.plainText = plainText;
            this.shift = shift;
        }

        public string Encrypt()
        {
            char[] shiftedAlphabet =
                Enumerable.Range(0, 26)
                .Select(i => (char)('A' + i))
                .Concat(Enumerable.Range(0, 26).Select(i => (char)('a' + i)))
                .ToArray();

            return string.Concat(plainText.Select(c =>
            {
            int index = shiftedAlphabet.ToList().IndexOf(c);
            if (index < 0)
                return c;
            else
                return shiftedAlphabet[(index + shift) % 26];
            }));
        }

        public string Decrypt()
        {
            return Encrypt()
                .Replace((char)('Z'), (char)('z'))
                .Replace(" ", String.Empty);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                Console.WriteLine("Введите текст для шифрования или дешифрования:");
                input = Console.ReadLine().ToUpper();
                CaesarCipher cipher = new CaesarCipher(input, 3);
                string encrypted = cipher.Encrypt();
                string decrypted = cipher.Decrypt();
                Console.WriteLine($"Зашифрованный текст: {encrypted}");
                Console.WriteLine($"Расшифрованный текст: {decrypted}");
          
            }
        }
    }
}