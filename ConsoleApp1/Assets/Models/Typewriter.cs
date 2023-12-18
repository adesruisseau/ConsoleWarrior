using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Assets.Models
{
    public static class Typewriter
    {
        public static void Write(string message, int delay = 10)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(delay);
            }
            Console.WriteLine("");
        }

        public static string Read()
        {
            var input = Console.ReadLine();
            input = input.ToString().Trim().ToLower();

            return input;
        }
    }
}
