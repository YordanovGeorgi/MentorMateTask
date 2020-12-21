using System;

namespace MentorMateTask
{
    /// <summary>
    /// Print second layer of bricks
    /// </summary>
    public class Print
    {
        /// <summary>
        /// Print the matrix that contains second layer of bricks
        /// </summary>
        /// <param name="widht"></param>
        /// <param name="length"></param>
        /// <param name="secondLayer"></param>
        public static void PrintSecondLayerBricks(int widht, int length, int[,] secondLayer)
        {
            Console.WriteLine();
            // print first line of '*' with certain lenght
            Console.WriteLine(new string('*', length * 4 + 1)); 

            for (int row = 0; row < widht; row++)
            {
                Console.Write('*');
                for (int col = 0; col < length; col++)
                {
                    if (col < length - 1)
                    {
                        // method to print current row of second layer without last half brick
                        PrintBrickLayerCurrentRow(row, col, secondLayer);   
                    }
                    // print last half brick of the current row
                    else
                    {
                        var brickLenght = secondLayer[row, col].ToString().Length;

                        //check if the number inside the brick is single digit
                        if (brickLenght == 1)                               
                        {
                            Console.Write(" ");
                        }
                        Console.Write(secondLayer[row, col] + " ");
                    }
                }

                Console.WriteLine('*');
                if (row < widht - 1)
                {
                    //method to print line of '*' with certain lenght between brick rows
                    PrintBetweenRows(secondLayer, row, length); 
                }
            }
            // print last line of '*' with certain lenght
            Console.WriteLine(new string('*', length * 4 + 1)); 
        }

        /// <summary>
        /// method to print line of '*' with certain lenght between brick rows
        /// </summary>
        /// <param name="secondLayer"></param>
        /// <param name="inputRow"></param>
        /// <param name="lenght"></param>
        private static void PrintBetweenRows(int[,] secondLayer, int inputRow, int lenght) 
        {
            //print line of '*' if row is odd
            if (inputRow % 2 == 1)                  
            {
                Console.WriteLine(new string('*', lenght * 4 + 1)); 
                return;
            }

            // print brick if row is even
            for (int row = inputRow; row <= inputRow; row++)
            {
                Console.Write('*');
                for (int col = 0; col < secondLayer.GetLength(1) - 1; col++)
                {
                    var firstHalfBrick = secondLayer[row, col];
                    var secondHalfBrick = secondLayer[row, col + 1];

                    if (firstHalfBrick == secondHalfBrick)
                    {
                        Console.Write(new string('*', 7));
                        Console.Write('*');

                        //increment column because horizontal brick takes two columns
                        col++;                              
                    }
                    else
                    {
                        Console.Write(new string(' ', 3));
                        Console.Write('*');
                    }
                }

                if (secondLayer.GetLength(1) <= 4)
                {
                    Console.Write(new string(' ', 3));
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// method to print current row of second layer without last half brick
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="secondLayer"></param>
        private static void PrintBrickLayerCurrentRow(int row, int col, int[,] secondLayer)  
        {
            var brickLenght = secondLayer[row, col].ToString().Length;

            //check if the number inside the brick is single digit
            if (brickLenght == 1) 
            {
                Console.Write(" ");
            }

            Console.Write(secondLayer[row, col] + " ");

            var firstHalfBrick = secondLayer[row, col];
            var secondHalfBrick = secondLayer[row, col + 1];

            if (firstHalfBrick == secondHalfBrick)
            {
                Console.Write(" ");
            }
            else
            {
                Console.Write("*");
            }
        }
    }
}