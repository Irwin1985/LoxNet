using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxNet
{
    public class LoxNet
    {
        private static bool hadError;

        public static bool HadError { get => hadError; set => hadError = value; }

        public static void Main2(string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("Usage: jlox [script]");
                Environment.Exit(1);
            } else if (args.Length == 1)
            {
                RunFile(args[0]);
            } else
            {
                RunPrompt();
            }
        }
        private static void RunFile(String path)
        {
            string text = File.ReadAllText(path);
            Run(text);
            if (HadError)
            {
                Environment.Exit(1);
            }
        }
        private static void RunPrompt()
        {
            while (true) {
                string line = Console.ReadLine();
                if (line != null)
                {
                    Run(line);
                    HadError = false;
                } else
                {
                    break;
                }
            }
        }
        private static void Run(string source)
        {
            Scanner scanner = new Scanner(source);
            List<Token> tokens = scanner.ScanTokens();

            // por ahora solo imprime los tokens.
            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }
        }
        public static void Error(int line, string message)
        {
            Report(line, "", message);
        }
        private static void Report(int line, string where, string message)
        {
            Console.WriteLine(String.Format("[line {0}] Error {1}: {2}", line, where, message));
            HadError = true;
        }
    }
}
