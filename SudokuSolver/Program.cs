using System;
using System.Security.Cryptography.X509Certificates;
using ToolBox;

namespace SudokuSolver
{
    internal class Program
    {
        public enum MainMenuChoices
        {
            Sudoku,
            ToolBox,
            Exit,
            Error
        };
        public enum ToolBoxMenuChoices
        {
            AddNumbers,
            WriteToFile,
            ReadFromFile,
            Exit,
            Error
        };
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
                var xCell = x / 3;
                var yCell = y / 3;
                xCell *= 3;
                yCell *= 3;
                for (var i = 0; i < 3; i++)
                    for (var j = 0; j < 3; j++)
                        if (_board[i + xCell, j + yCell] == num) return false;

                //if all test passed, then true
                return true;
            }

            public static bool NumberAt(int[,] grid, int x, int y, int num)
            {
                throw new NotImplementedException("AHHHHHHHHHHHHHHHHHHH I FORGOT ABOUT YODA");
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
        }

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
                tb.MainMenu(tbMenu: false);
                var userInput = Console.ReadLine() ?? "0";
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
                }//end switch(intUserInput)

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
                        userInput = Console.ReadLine() ?? "N";
                        if (!userInput.ToUpper().StartsWith("Y"))
                        {
                            Console.WriteLine("\nYay!!!\n");
                        }
                        else
                        {
                            Console.WriteLine("\n-------------\n***Kthxbai***\n-------------\n");
                            exit = true;
                        }
                        break;
                }//end switch(choice) -- YES I KNOW THIS IS POINTLESS

            }//end while(!exit)

            /*------JAVA SOURCE CODE------*/
            //import java.util.Stack;


            //public class suDoku 
            //{
            //    /*----------- Returns true if a number can go into a cell------*/
            //    public static boolean numberAt(int[][] grid, int x, int y, int num)
            //    {
            //        //check rows and columns for number
            //        for (int i = 0; i < 9; i++)
            //            if (grid[x][i] == num) return false; 
            //            else if (grid[i][y] == num) return false;

            //        //find out which cell we are in
            //        int xCell = x / 3;
            //        int yCell = y / 3;
            //        xCell *= 3;
            //        yCell *= 3;
            //        for (int i = 0; i < 3; i++)
            //            for (int j = 0; j < 3; j++)
            //                if (grid[i + xCell][j + yCell] == num) return false;

            //        //if all test passed, then true
            //        return true;
            //    }

            //    /*----------------- Copies grid --------------*/
            //    public static void copyGrid(int[][] grid, int[][] gridB)
            //    {
            //          for(int i = 0; i < 9; i++)
            //              for(int j = 0; j < 9; j++)
            //                gridB[i][j] = grid[i][j];
            //    }

            //    /*----------------- Prints Grid --------------------------*/
            //    public static void printGrid(int[][] grid)
            //    {
            //        for (int i = 0; i < 9; i++)
            //        {
            //            for (int j = 0; j < 9; j++)
            //                System.out.print(grid[i][j] + " ");
            //            System.out.println();
            //        }
            //    }
            //    /*-----------------------Brute Force Algorithm-------------------*/
            //    /*
            //     * This method solves a Sudoku puzzle by finding the first empty cell
            //     * and putting the first number it finds can be inserted. It then puts
            //     * the new grid into a stack and moves on. It continues until it finds 
            //     * a solution or until the stack is empty. 
            //     * 
            //     * If true was passed into the method then it will solve with Heuristics.
            //     * The Heuristics will find numbers that will only go in one cell and then
            //     * add them in. After this can't find a number that only goes in one place
            //     * it will move on to the brute force method.
            //     */
            //    public static int[][] bruteForce(int[][]grid, boolean heuristics)
            //    {
            //        int pushCounter = 1; //Counts how many times the grid gets pushed
            //        Stack<int[][]> stack = new Stack<int[][]>();
            //        stack.push(grid);
            //        boolean solved = false;
            //        boolean found = false; //no empty cell, or dead end
            //        while (!stack.isEmpty() && !solved) //loops until solution is fount or the stack is empty
            //        {
            //            grid = (int[][]) stack.pop(); //pops off the stack for next loop
            //            if(heuristics) heuristics2(grid); //does heuristics if boolean is true
            //            for (int x = 0; x < 9 && !found; x++) //increments x value
            //            {
            //                for (int y = 0; y < 9 && !found; y++) //increments y value 
            //                {
            //                    if (grid[x][y] == 0) //if it's an empty cell then call numberAt method
            //                    {
            //                        found = true;
            //                        for (int num = 1; num < 10; num++) //loops through numbers 1-9 for numberAt method call
            //                            if(numberAt(grid, x, y, num)) //if a number can go in the cell grid, copy grid, 
            //                            {							  //put in potential answer, and push copy into stack
            //                                int[][] gridB =  new int[9][9];
            //                                copyGrid(grid,gridB);
            //                                gridB[x][y] = num;
            //                                stack.push(gridB);
            //                                pushCounter += 1;
            //                            }
            //                    }
            //                }
            //            }
            //            if (found) found = false;
            //            else solved = true;
            //        }
            //        System.out.println("Push Counter : " + pushCounter);
            //        return grid;
            //    }

            //    /*---------------------- Heuristic Method -------------------------------*/
            //    /*
            //     * This method solves a Sudoku grid by first trying to find a number that
            //     * has the least amount of possibilities to go into a cell. It then 
            //     * puts that number in the cell and moves on. If it gets stuck it falls back
            //     * to a brute force method. 
            //     */
            //    public static int[][] leastDigitChoice(int[][]grid, boolean heuristic)
            //    {
            //        int pushCounter = 1; //Counts how many times the grid gets pushed
            //        Stack<int[][]> stack = new Stack<int[][]>();
            //        stack.push(grid);
            //        boolean solved = false;
            //        boolean found = false; //no empty cell, or dead end
            //        while (!stack.isEmpty() && !solved) //loops until solution is fount or the stack is empty
            //        {
            //            grid = (int[][]) stack.pop(); //pops off the stack for next loop
            //            if(heuristic) heuristics2(grid); //does heuristics if boolean is true
            //            int rowBestCell = 0;
            //            int colBestCell = 0;
            //            int minChoices = 9;
            //            for (int x = 0; x < 9; x++) //increments x value
            //            {
            //                for (int y = 0; y < 9; y++) //increments y value 
            //                {
            //                    if (grid[x][y] == 0) //if it's an empty cell then call numberAt method
            //                    {
            //                        found = true;
            //                        int choices = 0;
            //                        for (int num = 1; num < 10; num++)
            //                            if(numberAt(grid, x, y, num))
            //                            {
            //                                choices++;
            //                            }
            //                        if (choices < minChoices) 
            //                            {
            //                                minChoices = choices;
            //                                rowBestCell = x;
            //                                colBestCell = y;
            //                            }
            //                    }
            //                }
            //            }


            //                        for (int num = 1; num < 10; num++) //loops through numbers 1-9 for numberAt method call
            //                            if(numberAt(grid, rowBestCell, colBestCell, num)) //if a number can go in the cell grid, copy grid, 
            //                            {							  //put in potential answer, and push copy into stack
            //                                int[][] gridB =  new int[9][9];
            //                                copyGrid(grid,gridB);
            //                                gridB[rowBestCell][colBestCell] = num;
            //                                stack.push(gridB);
            //                                pushCounter += 1;
            //                            }
            //            if (found) found = false;
            //            else solved = true;
            //        }
            //        System.out.println("Push Counter : " + pushCounter);
            //        return grid;
            //    }

            //    /*----------------------------- Heuristic Least Number of Cell Choice --------------------------*/
            //    /*
            //     * 
            //     */
            //    public static void heuristics2(int[][]grid)
            //    {
            //        boolean numberPlaced = false;


            //        do
            //        {
            //            numberPlaced = false;
            //            //rows
            //            for (int num = 1; num <= 9; num++)
            //            {
            //                for (int x = 0; x <= 8; x++)
            //                {
            //                    int bestY = 0;
            //                    int possibilities = 0;
            //                    for (int y = 0; y <= 8; y++)
            //                    {
            //                        if((grid[x][y] == 0) && (numberAt(grid, x, y, num)))
            //                            {
            //                                possibilities++;
            //                                bestY = y;
            //                            }
            //                    }

            //                    if(possibilities == 1)
            //                    {
            //                        grid[x][bestY] = num;
            //                        numberPlaced = true;
            //                    }
            //                }
            //            }

            //            //columns
            //            for (int num = 1; num <= 9; num++)
            //            {
            //                for (int y = 0; y <= 8; y++)
            //                {
            //                    int bestX = 0;
            //                    int possibilities = 0;
            //                    for (int x = 0; x <= 8; x++)
            //                    {
            //                        if((grid[x][y] == 0) && (numberAt(grid, x, y, num)))
            //                            {
            //                                possibilities++;
            //                                bestX = x;
            //                            }
            //                    }

            //                    if(possibilities == 1)
            //                    {
            //                        grid[bestX][y] = num;
            //                        numberPlaced = true;
            //                    }
            //                }
            //            }

            //            //cells
            //            for(int num = 1; num <= 9; num++)
            //            {
            //                for(int xCell = 0; xCell <= 6; xCell += 3)
            //                {
            //                    for(int yCell = 0; yCell <= 6; yCell += 3)
            //                    {
            //                        int possibilities = 0;
            //                        int bestX = 0;
            //                        int bestY = 0;
            //                        for(int x = 0; x <= 2; x++)
            //                        {
            //                            for(int y = 0; y <= 2; y++)
            //                            {
            //                                if((grid[xCell + x][yCell + y] == 0) && (numberAt(grid, (xCell + x), (yCell + y), num)))
            //                                {
            //                                    possibilities++;
            //                                    bestX = xCell + x;
            //                                    bestY = yCell + y;
            //                                }
            //                            }//end for y
            //                        }//end for x
            //                        if (possibilities == 1)
            //                        {
            //                            grid[bestX][bestY] = num;
            //                            numberPlaced = true;
            //                        }
            //                    }//end for yCell
            //                }//end for xCell
            //            }//end for num
            //        }while(numberPlaced);
            //    }

            //    public static void main(String[] args) 
            //    {
            //        //test cases
            //        int [][]grid = {{ 4,6,0,0,0,1,0,0,0},
            //                        { 0,0,2,0,9,6,0,0,0},
            //                        { 0,3,0,0,0,0,0,6,8},
            //                        { 0,0,0,0,0,0,0,3,7},
            //                        { 0,0,0,6,0,7,0,0,0},
            //                        { 5,1,0,0,0,0,0,0,0},
            //                        { 8,4,0,0,0,0,0,5,0},
            //                        { 0,0,0,7,1,0,9,0,0},
            //                        { 0,0,0,3,0,0,0,2,4}};

            //        /*int [][]grid = {{ 0,0,6,0,0,8,5,0,0},
            //                        { 0,0,0,0,7,0,6,1,3},
            //                        { 0,0,0,0,0,0,0,0,9},
            //                        { 0,0,0,0,9,0,0,0,1},
            //                        { 0,0,1,0,0,0,8,0,0},
            //                        { 4,0,0,5,3,0,0,0,0},
            //                        { 1,0,7,0,5,3,0,0,0},
            //                        { 0,5,0,0,6,4,0,0,0},
            //                        { 3,0,0,1,0,0,0,6,0}};
            //        int[][] grid = {{3, 0, 0,  0, 0, 0,  1, 0, 0},
            //                        {0, 2, 0,  3, 1, 0,  0, 0, 5},
            //                        {0, 0, 0,  2, 0, 0,  0, 3, 7},

            //                        {0, 0, 1,  0, 5, 0,  0, 0, 6},
            //                        {0, 0, 5,  4, 0, 3,  7, 0, 0},
            //                        {2, 0, 0,  0, 6, 0,  9, 0, 0},

            //                        {4, 7, 0,  0, 0, 8,  0, 0, 0},
            //                        {6, 0, 0,  0, 2, 4,  0, 9, 0},
            //                        {0, 0, 2,  0, 0, 0,  0, 0, 8}};*/
            //		int[][] grid = {{0, 0, 0,  3, 9, 0,  0, 1, 0},
            //                        {5, 0, 1,  0, 0, 0,  0, 4, 0},
            //                        {9, 0, 0,  7, 0, 0,  5, 0, 0},

            //                        {6, 0, 2,  5, 3, 0,  0, 7, 0},
            //                        {0, 0, 0,  0, 7, 0,  0, 0, 8},
            //                        {7, 0, 0,  8, 0, 0,  9, 0, 3},

            //                        {8, 0, 3,  0, 1, 0,  0, 9, 0},
            //                        {0, 9, 0,  2, 0, 6,  0, 0, 7},
            //                        {4, 0, 0,  0, 0, 3,  0, 6, 1}};

            //        /*------------solved grid---------*/
            //         /*{{2, 4, 8,  3, 9, 5,  7, 1, 6},
            //            {5, 7, 1,  6, 2, 8,  3, 4, 9},
            //            {9, 3, 6,  7, 4, 1,  5, 8, 2},

            //            {6, 8, 2,  5, 3, 9,  1, 7, 4},
            //            {3, 5, 9,  1, 7, 4,  6, 2, 8},
            //            {7, 1, 4,  8, 6, 2,  9, 5, 3},

            //            {8, 6, 3,  4, 1, 7,  2, 9, 5},
            //            {1, 9, 5,  2, 8, 6,  4, 3, 7},
            //            {4, 2, 7,  9, 5, 3,  8, 6, 1}};*/
            //		int[][] grid = {{0, 0, 0,  3, 9, 0,  0, 1, 0},
            //                        {5, 0, 1,  6, 2, 8,  3, 4, 9},
            //                        {9, 3, 6,  7, 4, 1,  5, 8, 2},

            //                        {6, 8, 2,  5, 3, 9,  1, 7, 4},
            //                        {3, 5, 9,  1, 7, 4,  6, 2, 8},
            //                        {7, 1, 4,  8, 6, 2,  9, 5, 3},

            //                        {8, 6, 3,  4, 1, 7,  2, 9, 5},
            //                        {1, 9, 5,  2, 8, 6,  4, 3, 7},
            //                        {4, 2, 7,  9, 5, 3,  8, 6, 1}};
            //        /*--------------------- End Test grids----------------------*/
            //        int[][] grid2 = new int[9][9];
            //        int[][] grid3 = new int[9][9];
            //        int[][] grid4 = new int[9][9];
            //        copyGrid(grid, grid2);
            //        copyGrid(grid, grid3);
            //        copyGrid(grid, grid4);

            //        /*-------- Test Brute Force ---------------*/
            //        System.out.println("Brute Force: ");
            //        long startTime = System.currentTimeMillis();
            //        grid = bruteForce(grid, false);
            //        printGrid(grid);
            //        long endTime = System.currentTimeMillis();
            //        System.out.println();
            //        System.out.println("Brute force takes :" + (endTime - startTime) + "ms");

            //        /*-------- Test Heuristic 1 ---------------*/
            //        System.out.println("Heuristic 1: ");
            //        startTime = System.currentTimeMillis();
            //        grid2 = leastDigitChoice(grid2, false);
            //        printGrid(grid2);
            //        endTime = System.currentTimeMillis();
            //        System.out.println();
            //        System.out.println("Heuristic 1 takes :" + (endTime - startTime) + "ms");

            //        /*-------- Test Heuristic 2 ---------------*/
            //        System.out.println("Heuristic 2: ");
            //        startTime = System.currentTimeMillis();
            //        grid3 = bruteForce(grid3, true);
            //        printGrid(grid3);
            //        endTime = System.currentTimeMillis();
            //        System.out.println();
            //        System.out.println("Heuristic 2 (brute force) :" + (endTime - startTime) + "ms");

            //        /*-------- Test Heuristic 2 with Heuristic 1 ---------------*/
            //        System.out.println("Heuristic 2 with Heuristic 1: ");
            //        startTime = System.currentTimeMillis();
            //        grid4 = leastDigitChoice(grid4, true);
            //        printGrid(grid4);
            //        endTime = System.currentTimeMillis();
            //        System.out.println();
            //        System.out.println("Heuristic 2 with Heuristic 1 takes :" + (endTime - startTime) + "ms");
            //    }

            //}
        }

        private static void DoToolBox(Tools tb)
        {
            var firstRun = true;
            var exit = false;
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
                var userInput = Console.ReadLine() ?? "0";
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
                        DoWriteToFile();
                        Console.WriteLine("You chose write to file!");
                        break;
                    case ToolBoxMenuChoices.Exit:
                        Console.WriteLine("\n-------------------\n**Toolbox Closing**\n-------------------\n");
                        exit = true;
                        break;
                    case ToolBoxMenuChoices.Error:
                        Console.WriteLine("Invalid choice!");
                        break;
                }//end switch(choice) -- YES I KNOW THIS IS POINTLESS

            }//End while(!exit)
        }

        private static void DoWriteToFile()
        {
            throw new NotImplementedException();
        }

        private static void DoReadFromFile()
        {
            throw new NotImplementedException();
        }

        private static void DoAddNumbers()
        {
            var exit = false;

            Console.WriteLine("\n-----------------\n***Add Numbers***\n-----------------\n");
            Console.WriteLine("Add numbers by insterting into the blanks!");
            Console.WriteLine("Type 0 into both blanks to exit!");
            while (!exit)
            {
                Console.Write("First Number: ");
                var userInput = Console.ReadLine();
                int x;
                if (!int.TryParse(userInput, out x))
                {
                    Console.WriteLine("\n**Invalid Entry**\n");
                    continue;
                }
                Console.Write("Second Number: ");
                userInput = Console.ReadLine();
                int y;
                if (!int.TryParse(userInput, out y))
                {
                    Console.WriteLine("\n**Invalid Entry**\n");
                    continue;
                }
                if (x == 0 && y == 0) exit = true;
                else
                {
                    var z = x + y;
                    Console.WriteLine(x + " + " + y + " = " + z + "\n");
                }
            }
        }

        private static void DoSudoku()
        {
            var chill = new[,] {{1, 2, 3, 4, 5, 6, 7, 8, 9}, 
                                {9, 1, 2, 3, 4, 5, 6, 7, 8}, 
                                {8, 9, 1, 2, 3, 4, 5, 6, 7}, 
                                {7, 8, 9, 1, 2, 3, 4, 5, 6}, 
                                {6, 7, 8, 9, 1, 2, 3, 4, 5}, 
                                {5, 6, 7, 8, 9, 1, 2, 3, 4}, 
                                {4, 5, 6, 7, 8, 9, 1, 2, 3}, 
                                {3, 4, 5, 6, 7, 8, 9, 1, 2}, 
                                {2, 3, 4, 5, 6, 7, 8, 9, 1}};
            var sudoku = new Sudoku(chill);
            sudoku.PrintBoard();
        }
    }
}