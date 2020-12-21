using System;
using System.Collections.Generic;
using System.Linq;

namespace MentorMateTask
{
    /// <summary>
    /// Read input data
    /// </summary>
    public class ReadData
    {
        /// <summary>
        /// read data and validate it
        /// </summary>
        /// <returns></returns>
        public static List<int> ReadDimensions()
        {
            var listDimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            
            return listDimensions;
        }

        /// <summary>
        /// Read input data for first layer of bricks
        /// </summary>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <returns>first layer of brick</returns>
        public static int[,] ReadFirstLayerOfBricks(int width, int length)
        {
            var firstLayerBricks = new int[width, length];

            // fill the matrix with inputData for firstLayer of bricks
            for (int row = 0; row < width; row++) 
            {
                int[] currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Validation.ValidateLayer(currRow.Length, length);

                for (int col = 0; col < length; col++)
                {
                    //filling current row of the layer with input data
                    firstLayerBricks[row, col] = currRow[col]; 
                }
            }
            return firstLayerBricks;
        }
    }
}