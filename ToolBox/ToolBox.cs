using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ToolBox
{
    public class Tools
    {
        public static int AddNumbers(int x, int y)
        {
            return x + y;
        }

        public static string CombineStrings(params string[] strings)
        {
            if (strings == null) throw new ArgumentNullException("strings");
            return strings.Aggregate("", (current, target) => current + target);
        }

        public static void WriteToFile(string path, string contentToWrite)
        {
            if (path == null) throw new ArgumentNullException("path");
            if (contentToWrite == null) throw new ArgumentNullException("contentToWrite");
            var sb = new StringBuilder();
            sb.AppendLine(contentToWrite);
            sb.AppendLine("Thank you for using the WriteToFile!");
            try
            {
                using (var sw = new StreamWriter(path))
                {
                    sw.Write(sb.ToString());
                    sw.Close();
                }
            }
            catch (AccessViolationException)
            {
                Console.WriteLine("Not sufficiently elevated for that file!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("I couldn't find that file!");
                Console.Write("Would you like me to make the file for you (y/n, default = y)? : ");
                var userInput = Console.ReadLine() ?? "y";
                if (userInput.ToUpper().StartsWith("Y"))
                {
                    Console.WriteLine("** Creating File **");
                    File.Create(path);
                    Console.WriteLine("** File Created **");
                    Console.Write("Want me to try writing again (y/n, default = y)? : ");
                    userInput = Console.ReadLine() ?? "y";
                    if (userInput.ToUpper().StartsWith("Y"))
                    {
                        using (var sw = new StreamWriter(path))
                        {
                            sw.WriteLine(sb.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error trying to write to the file.\nStackTrace:" + e.StackTrace + "\nDump:" + e);
            }

        }

        public static string ReadFromFile(string path, bool printToScreen)
        {
            if (path == null) throw new ArgumentNullException("path");
            var sb = new StringBuilder();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        sb.AppendLine(sr.ReadLine());
                    }
                }

                if (printToScreen)
                {
                    Console.WriteLine(sb.ToString());
                }
                return sb.ToString();
            }
            catch (AccessViolationException)
            {
                Console.WriteLine("\n**Not sufficiently elevated for that file!**");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\n**I couldn't find that file!");
                Console.Write("Would you like me to make the file for you (y/n, default = y)? : ");
                var userInput = Console.ReadLine() ?? "y";
                if (!userInput.ToUpper().StartsWith("Y")) return sb.ToString();
                Console.WriteLine("** Creating File **");
                File.Create(path);
                Console.WriteLine("** File Created **");
                Console.Write("Want me to try reading again (y/n, default = y)? : ");
                userInput = Console.ReadLine() ?? "y";
                if (!userInput.ToUpper().StartsWith("Y")) return sb.ToString();
                using (var sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        sb.AppendLine(sr.ReadLine());
                    }
                }
                        
                if (printToScreen)
                {
                    Console.WriteLine("\n" + sb);
                }
                return sb.ToString();
            }
            catch (IOException)
            {
                Console.WriteLine("\n**There was an error trying to read the file**");
            }

            Console.WriteLine("\n***********\nIF YOU SEE THIS SOMETHING WENT WRONG\n************\n");
            return "You should never see this.";
        }

        public void MainMenu(bool tbMenu)
        {
            Thread.Sleep(500);
            if (tbMenu)
            {
                Console.WriteLine("\n--------------------\n******Tool Box******\n--------------------\n");
                Console.WriteLine("1. Add two numbers ");
                Console.WriteLine("2. Write to file");
                Console.WriteLine("3. Read from file");
                Console.WriteLine("4. Combine Strings");
                Console.WriteLine("5. Exit to Main Menu");
                Console.Write("\nPlease choose an option: ");
            }
            else
            {
                Console.WriteLine("\n---------------------\n******Main Menu******\n---------------------\n");
                Console.WriteLine("1. Sudoku (WIP)");
                Console.WriteLine("2. ToolBox Testing");
                Console.WriteLine("3. Hot Dog");
                Console.WriteLine("4. Exit");
                Console.Write("\nPlease choose an option! : ");
            }
        }
    }
}
