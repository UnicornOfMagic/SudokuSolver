using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ToolBox;

namespace SudokuSolver
{
    internal class Program
    {

        //So these Enums don't really do too much
            //(In fact they add a lot of weight)
        //but I really wanted to use Enums 
        //....so here are my Enums

        private enum MainMenuChoices
        {
            Sudoku,
            ToolBox,
            Exit,
            Error
        };

        private enum ToolBoxMenuChoices
        {
            AddNumbers,
            WriteToFile,
            ReadFromFile,
            CombineStrings,
            Exit,
            Error
        };

        //Look I didn't use a SudokuMenuChoices enum!

        private static void Main(string[] args)
        {
            var tb = new Tools();
            var exit = false;
            var firstRun = true;
            while (!exit)
            {
                if (firstRun)
                {
                    Console.WriteLine("\nWelcome to my program!\n");
                    firstRun = false;
                }
                else
                {
                    Console.WriteLine("\nAnything else I can do for you?\n");
                }
                tb.MainMenu(false);
                var userInput = Console.ReadKey().KeyChar.ToString();
                int intUserInput;
                int.TryParse(userInput, out intUserInput);
                MainMenuChoices choice;
                switch (intUserInput)
                {
                    case 1:
                    {
                        choice = MainMenuChoices.Sudoku;
                        break;
                    }
                    case 2:
                    {
                        choice = MainMenuChoices.ToolBox;
                        break;
                    }
                    case 3:
                    {
                        choice = MainMenuChoices.Exit;
                        break;
                    }
                    default:
                    {
                        choice = MainMenuChoices.Error;
                        break;
                    }
                } //end switch(intUserInput)

                switch (choice)
                {
                    case MainMenuChoices.Error:
                        Console.WriteLine("\nInvalid Choice!\n");
                        break;
                    case MainMenuChoices.Sudoku:
                        DoSudoku();
                        break;
                    case MainMenuChoices.ToolBox:
                        DoToolBox(tb);
                        Console.WriteLine("\n------------------\n**Toolbox Closed**\n------------------\n");
                        break;
                    case MainMenuChoices.Exit:
                        Console.Write("\nAre you sure you want to exit (y/n, default = n)? : ");
                        userInput = Console.ReadKey().KeyChar.ToString();
                        if (!userInput.ToUpper().StartsWith("Y"))
                        {
                            Console.WriteLine("\nYay!!!\n");
                        }
                        else
                        {
                            Console.Write("\nLOADING EXIT PROGRAM..");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(300);
                            Console.Write(".");
                            Thread.Sleep(250);
                            Console.Write(".");
                            Thread.Sleep(400);
                            Console.Write(".");
                            Thread.Sleep(100);
                            Console.Write(".");
                            Thread.Sleep(50);
                            Console.Write(".");
                            Thread.Sleep(200);
                            Console.WriteLine(".");
                            Console.WriteLine("LOADING COMPLETE");
                            Console.Write("EXECUTING");
                            Thread.Sleep(100);
                            Console.Write(".");
                            Thread.Sleep(200);
                            Console.Write(".");
                            Thread.Sleep(300);
                            Console.WriteLine(".");
                            Console.WriteLine("EXITING");
                            Console.WriteLine("\n-------------\n***KTHXBAI***\n-------------\n");
                            exit = true;
                        }
                        break;
                } //end switch(choice) -- YES I KNOW THIS IS POINTLESS
            } //end while(!exit)

        }

        private static void DoToolBox(Tools tb)
        {
            var firstRun = true;
            var exit = false;
            var theString = "";
            while (!exit)
            {
                if (firstRun)
                {
                    Console.WriteLine("\nWelcome to the Tool Box!\n");
                    firstRun = false;
                }
                else
                {
                    Console.WriteLine("\nAnything else I can do for you?\n");
                }
                tb.MainMenu(true);
                ToolBoxMenuChoices choice;
                var userInput = Console.ReadKey().KeyChar.ToString();
                int intUserInput;
                int.TryParse(userInput, out intUserInput);
                switch (intUserInput)
                {
                    case 1:
                    {
                        choice = ToolBoxMenuChoices.AddNumbers;
                        break;
                    }
                    case 2:
                    {
                        choice = ToolBoxMenuChoices.WriteToFile;
                        break;
                    }
                    case 3:
                    {
                        choice = ToolBoxMenuChoices.ReadFromFile;
                        break;
                    }
                    case 4:
                    {
                        choice = ToolBoxMenuChoices.CombineStrings;
                        break;
                    }
                    case 5:
                    {
                        choice = ToolBoxMenuChoices.Exit;
                        break;
                    }
                    default:
                    {
                        choice = ToolBoxMenuChoices.Error;
                        break;
                    }
                } //End switch(intUserInput)

                switch (choice)
                {
                    case ToolBoxMenuChoices.AddNumbers:
                        DoAddNumbers();
                        break;
                    case ToolBoxMenuChoices.ReadFromFile:
                        DoReadFromFile();
                        Console.WriteLine("You chose read from file!");
                        break;
                    case ToolBoxMenuChoices.WriteToFile:
                        DoWriteToFile(theString);
                        Console.WriteLine("You chose write to file!");
                        break;
                    case ToolBoxMenuChoices.CombineStrings:
                        theString = DoCombineStrings();
                        Console.WriteLine("Program returned: " + theString);
                        break;
                    case ToolBoxMenuChoices.Exit:
                        Console.WriteLine("\n-------------------\n**Toolbox Closing**\n-------------------\n");
                        exit = true;
                        break;
                    case ToolBoxMenuChoices.Error:
                        Console.WriteLine("Invalid choice!");
                        break;
                } //end switch(choice) -- YES I KNOW THIS IS POINTLESS
            } //End while(!exit)
        }

        private static string DoCombineStrings()
        {
            Console.WriteLine();
            var result = "";
            var exit = false;
            var done = false;
            while (!done)
            {
                var i = 1;
                var finished = new string[i];
                string userInput;
                while (!exit)
                {
                    Console.Write("Input string to combine (just press Enter to stop): ");
                    userInput = Console.ReadLine();
                    if (!userInput.Equals(""))
                    {
                        finished[i - 1] = userInput;

                        var temp = new string[i];
                        for (var index = 0; index < finished.Length; index++)
                        {
                            var s = finished[index];
                            temp[index] = s;
                        }

                        finished = new string[i + 1];

                        for (var index = 0; index < temp.Length; index++)
                        {
                            var s = temp[index];
                            finished[index] = s;
                        }
                    }
                    else
                    {
                        exit = true;
                    }
                    i++;
                }

                result = Tools.CombineStrings(finished);

                Console.WriteLine("Your completed string:\n----------------------");
                Console.WriteLine(result);
                Console.Write("\n\nIs this the string you want (y/n, default = y)? : ");
                userInput = Console.ReadLine();
                if (!userInput.ToUpper().StartsWith("Y"))
                {
                    Console.WriteLine("\n-------------\n**Resetting**\n-------------\n");
                    result = "";
                    exit = false;
                }
                else
                {
                    done = true;
                }
            }
            return result;
        }

        private static void DoWriteToFile(string theString)
        {
            if (theString.Equals(""))
            {
                Console.WriteLine("\nYou haven't made a string yet!\n\nRunning stringCombiner...");
                theString = DoCombineStrings();
            }

            var exit = false;
            var path = "";

            do
            {
                Console.WriteLine("\n\n Please type the full path of the file you want to write:");
                path = Console.ReadLine();
                Console.WriteLine("\nIs this the correct path?\n{0}\n(y or n): ", path);
                if (Console.ReadKey().KeyChar.ToString().ToUpper().Equals("Y")) exit = true;
            } while (!exit);

            Tools.WriteToFile(path, theString);
        }

        private static void DoReadFromFile()
        {
            var exit = false;
            var path = "";

            do
            {
                Console.WriteLine("\n\n Please type the full path of the file you want to write:");
                path = Console.ReadLine();
                Console.Write("\nIs this the correct path?\n{0}\n(y or n): ", path);
                if (Console.ReadKey().KeyChar.ToString().ToUpper().Equals("Y")) exit = true;
            } while (!exit);
            Console.Write("\nDo you want to see what I read? (y or n): ");
            Tools.ReadFromFile(path, Console.ReadKey().KeyChar.ToString().ToUpper().Equals("Y"));
        }

        private static void DoAddNumbers()
        {
            var exit = false;

            Console.WriteLine("\n-----------------\n***Add Numbers***\n-----------------\n");
            Console.WriteLine("Add numbers by insterting into the blanks!");
            Console.WriteLine("Type 0 into both blanks to exit!");
            while (!exit)
            {
                Console.Write("Equation: ");
                var userInput = Console.ReadKey().KeyChar.ToString();
                int x;
                if (!int.TryParse(userInput, out x))
                {
                    Console.WriteLine("\n**Invalid Entry**\n");
                    continue;
                }
                Console.Write(" + ");
                userInput = Console.ReadKey().KeyChar.ToString();
                int y;
                if (!int.TryParse(userInput, out y))
                {
                    Console.WriteLine("\n**Invalid Entry**\n");
                    continue;
                }
                if (x == 0 && y == 0) exit = true;
                else
                {
                    var z = Tools.AddNumbers(x, y);
                    Console.WriteLine(" = " + z);
                }
            }
        }

        private static void DoSudoku()
        {
            var chill = new[,]

            {
                {0, 0, 0, 3, 9, 0, 0, 1, 0},
                {5, 0, 1, 0, 0, 0, 0, 4, 0},
                {9, 0, 0, 7, 0, 0, 5, 0, 0},
                {6, 0, 2, 5, 3, 0, 0, 7, 0},
                {0, 0, 0, 0, 7, 0, 0, 0, 8},
                {7, 0, 0, 8, 0, 0, 9, 0, 3},
                {8, 0, 3, 0, 1, 0, 0, 9, 0},
                {0, 9, 0, 2, 0, 6, 0, 0, 7},
                {4, 0, 0, 0, 0, 3, 0, 6, 1}
                /*{0, 2, 3, 4, 5, 6, 7, 8, 9},
                {9, 1, 2, 3, 4, 5, 6, 7, 8},
                {8, 9, 1, 2, 3, 4, 5, 6, 7},
                {7, 8, 9, 1, 2, 3, 4, 5, 6},
                {6, 7, 8, 9, 1, 2, 3, 4, 5},
                {5, 6, 7, 8, 9, 1, 2, 3, 4},
                {4, 5, 6, 7, 8, 9, 1, 2, 3},
                {3, 4, 5, 6, 7, 8, 9, 1, 2},
                {2, 3, 4, 5, 6, 7, 8, 9, 1}*/
            };
            var sudoku = new Sudoku(chill);
            var exit = false;
            //sudoku.PrintBoard();

            while (!exit)
            {
                Console.WriteLine("\n--------------------\nSUDOKU CONTROL PANEL\n--------------------\n");
                Console.WriteLine("1 Solve it!");
                Console.WriteLine("2 Try placing a number");
                Console.WriteLine("3 View current board");
                Console.WriteLine("4 Enter a new board");
                Console.WriteLine("5 Exit");

                Console.Write("Enter your menu choice: ");
                var userInput = Console.ReadKey().KeyChar.ToString();

                switch (userInput)
                {
                    case "1":
                        DoSolveIt(sudoku);
                        break;
                    case "2":
                        DoNumberPlacer(sudoku);
                        break;
                    case "3":
                        Console.WriteLine("\nYou have selected View current board");
                        break;
                    case "4":
                        Console.WriteLine("\nYou have selected Enter a new board");
                        break;
                    case "5":
                        Console.WriteLine("\n**EXITING SUDOKU**");
                        Thread.Sleep(500);
                        Console.WriteLine("Cleaning Board");
                        Thread.Sleep(250);
                        Console.WriteLine("Replacing Board");
                        Thread.Sleep(500);
                        Console.WriteLine("Wasting Time...");
                        Thread.Sleep(100);
                        Console.WriteLine("\n**EXITING**\n");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\n***INVALID ENTRY***");
                        break;
                }
            }
        }

        private static void DoSolveIt(Sudoku sudoku)
        {
            Console.Write("\nShould I solve it the fast way?: ");
            var heuristic = Console.ReadKey().KeyChar.ToString().ToUpper().Equals("Y");
            Console.WriteLine("\n**SOLVING**");
            Thread.Sleep(1000);
            sudoku.BruteForce(heuristic);
            Console.WriteLine("**SOLVED**");
            sudoku.PrintBoard();
        }

        private static void DoNumberPlacer(Sudoku sudoku)
        {
            Console.WriteLine("\n*********************\n*********************");
            var done = false;
            while (!done)
            {
                sudoku.PrintBoard();
                Console.Write("\nPlease insert number to try (1-9): ");
                var userInput = Console.ReadKey().KeyChar.ToString();
                int num;
                if (!int.TryParse(userInput, out num) || num == 0)
                {
                    Console.WriteLine("\n***INVALID ENTRY***");
                    continue;
                }
                Console.Write("\nPlease insert x location to place (1-9): ");
                userInput = Console.ReadKey().KeyChar.ToString();
                int x;
                if (int.TryParse(userInput, out x) && x != 0)
                {
                    Console.Write("\nPlease insert y location to place (1-9): ");
                    userInput = Console.ReadKey().KeyChar.ToString();
                    int y;
                    if (int.TryParse(userInput, out y) && y != 0)
                    {
                        Console.WriteLine("\n{0} can be placed at ({1}, {2}): {3}", num, x, y,
                            sudoku.NumberAt(x - 1, y - 1, num));
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("\n***INVALID ENTRY***");
                    }
                }
                else
                {
                    Console.WriteLine("\n***INVALID ENTRY***");
                }
            }
        }

        public class Sudoku
        {
            private int[,] _board;

            public Sudoku(int[,] board)
            {
                _board = board;
            }

            public Sudoku()
            {
                _board = new int[9, 9];
            }

            public bool NumberAt(int x, int y, int num)
            {
                //check rows and columns for number
                for (var i = 0; i < 9; i++)
                    if (_board[x, i] == num) return false;
                    else if (_board[i, y] == num) return false;

                //find out which cell we are in
                var xCell = x/3;
                var yCell = y/3;
                xCell *= 3;
                yCell *= 3;
                for (var i = 0; i < 3; i++)
                    for (var j = 0; j < 3; j++)
                        if (_board[i + xCell, j + yCell] == num) return false;

                //if all test passed, then true
                return true;
            }

            /*----------------- Copies grid --------------*/

            public int[,] CopyBoard()
            {
                var board = new int[9, 9];
                for (var i = 0; i < 9; i++)
                    for (var j = 0; j < 9; j++)
                        board[i, j] = _board[i, j];

                return board;
            }

            /*----------------- Prints Grid --------------------------*/

            public void PrintBoard()
            {
                Console.WriteLine("****Current Board****\n");
                for (var i = 0; i < 9; i++)
                {
                    for (var j = 0; j < 9; j++)
                        Console.Write(_board[i, j] + " ");
                    Console.WriteLine();
                }
            }

            /*-----------------------Brute Force Algorithm-------------------*/
            /*
             * This method solves a Sudoku puzzle by finding the first empty cell
             * and putting the first number it finds can be inserted. It then puts
             * the new grid into a stack and moves on. It continues until it finds 
             * a solution or until the stack is empty. 
             * 
             * If true was passed into the method then it will solve with Heuristics.
             * The Heuristics will find numbers that will only go in one cell and then
             * add them in. After this can't find a number that only goes in one place
             * it will move on to the brute force method.
             */

            public int[,] BruteForce(bool heuristics)
            {
                var pushCounter = 1; //Counts how many times the grid gets pushed
                var stack = new Stack<int[,]>();
                stack.Push(_board);
                var solved = false;
                var found = false; //no empty cell, or dead end
                while (!stack.Equals(new Stack<int[,]>()) && !solved)
                    //loops until solution is fount or the stack is empty
                {
                    _board = stack.Pop(); //pops off the stack for next loop
                    if (heuristics) Heuristics2(_board); //does heuristics if boolean is true
                    for (var x = 0; x < 9 && !found; x++) //increments x value
                    {
                        for (var y = 0; y < 9 && !found; y++) //increments y value 
                        {
                            if (_board[x, y] == 0) //if it's an empty cell then call numberAt method
                            {
                                found = true;
                                for (var num = 1; num < 10; num++) //loops through numbers 1-9 for numberAt method call
                                    if (NumberAt(x, y, num)) //if a number can go in the cell grid, copy grid, 
                                    {
                                        //put in potential answer, and push copy into stack
                                        var gridB = CopyBoard();
                                        gridB[x, y] = num;
                                        stack.Push(gridB);
                                        pushCounter += 1;
                                    }
                            }
                        }
                    }
                    if (found) found = false;
                    else solved = true;
                }
                Console.WriteLine("\nSteps Taken : " + pushCounter);
                return _board;
            }

            /*---------------------- Heuristic Method -------------------------------*/
            /*
             * This method solves a Sudoku grid by first trying to find a number that
             * has the least amount of possibilities to go into a cell. It then 
             * puts that number in the cell and moves on. If it gets stuck it falls back
             * to a brute force method. 
             */

            public int[,] LeastDigitChoice(bool heuristic)
            {
                var pushCounter = 1; //Counts how many times the grid gets pushed
                var stack = new Stack<int[,]>();
                stack.Push(_board);
                var solved = false;
                var found = false; //no empty cell, or dead end
                while (!stack.Equals(new Stack<int[,]>()) && !solved)
                    //loops until solution is found or the stack is empty
                {
                    _board = stack.Pop(); //pops off the stack for next loop
                    if (heuristic) Heuristics2(_board); //does heuristics if boolean is true
                    var rowBestCell = 0;
                    var colBestCell = 0;
                    var minChoices = 9;
                    for (var i = 0; i < 9; i++) //increments x value
                    {
                        for (var j = 0; j < 9; j++) //increments y value 
                        {
                            if (_board[i, j] == 0) //if it's an empty cell then call numberAt method
                            {
                                found = true;
                                var choices = 0;
                                for (var number = 1; number < 10; number++)
                                    if (NumberAt(i, j, number))
                                    {
                                        choices++;
                                    }
                                if (choices < minChoices)
                                {
                                    minChoices = choices;
                                    rowBestCell = i;
                                    colBestCell = j;
                                }
                            }
                        }
                    }
                    for (var num = 1; num < 10; num++) //loops through numbers 1-9 for numberAt method call
                        if (NumberAt(rowBestCell, colBestCell, num)) //if a number can go in the cell grid, copy grid, 
                        {
                            //put in potential answer, and push copy into stack
                            var gridB = CopyBoard();
                            gridB[rowBestCell, colBestCell] = num;
                            stack.Push(gridB);
                            pushCounter += 1;
                        }
                    if (found) found = false;
                    else solved = true;
                }
                Console.WriteLine("Push Counter : " + pushCounter);
                return _board;
            }

            /*----------------------------- Heuristic Least Number of Cell Choice --------------------------*/
            /*
             * 
             */

            public void Heuristics2(int[,] grid)
            {
                bool numberPlaced;


                do
                {
                    numberPlaced = false;
                    //rows
                    for (var num = 1; num <= 9; num++)
                    {
                        for (var x = 0; x <= 8; x++)
                        {
                            var bestY = 0;
                            var possibilities = 0;
                            for (var y = 0; y <= 8; y++)
                            {
                                if ((grid[x, y] == 0) && (NumberAt(x, y, num)))
                                {
                                    possibilities++;
                                    bestY = y;
                                }
                            }

                            if (possibilities == 1)
                            {
                                grid[x, bestY] = num;
                                numberPlaced = true;
                            }
                        }
                    }

                    //columns
                    for (var num = 1; num <= 9; num++)
                    {
                        for (var y = 0; y <= 8; y++)
                        {
                            var bestX = 0;
                            var possibilities = 0;
                            for (var x = 0; x <= 8; x++)
                            {
                                if ((grid[x, y] == 0) && (NumberAt(x, y, num)))
                                {
                                    possibilities++;
                                    bestX = x;
                                }
                            }

                            if (possibilities == 1)
                            {
                                grid[bestX, y] = num;
                                numberPlaced = true;
                            }
                        }
                    }

                    //cells
                    for (var num = 1; num <= 9; num++)
                    {
                        for (var xCell = 0; xCell <= 6; xCell += 3)
                        {
                            for (var yCell = 0; yCell <= 6; yCell += 3)
                            {
                                var possibilities = 0;
                                var bestX = 0;
                                var bestY = 0;
                                for (var x = 0; x <= 2; x++)
                                {
                                    for (var y = 0; y <= 2; y++)
                                    {
                                        if (grid[xCell + x, yCell + y] == 0 && NumberAt(xCell + x, (yCell + y), num))
                                        {
                                            possibilities++;
                                            bestX = xCell + x;
                                            bestY = yCell + y;
                                        }
                                    } //end for y
                                } //end for x
                                if (possibilities == 1)
                                {
                                    grid[bestX, bestY] = num;
                                    numberPlaced = true;
                                }
                            } //end for yCell
                        } //end for xCell
                    } //end for num
                } while (numberPlaced);
            }
        }
    }
}