using System;
using System.Collections.Generic;

namespace MentorMateTask
{
    /// <summary>
    /// Validation of input data
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// validate dimnesions of the first layer
        /// </summary>
        /// <param name="width"></param>
        /// <param name="lenght"></param>
        public static void ValidateDimensions(int width, int lenght)
        {
            // check dimensions have correct values
            if (width >= 100 || width % 2 != 0 || lenght >= 100 || lenght % 2 != 0) 
            {
                throw new Exception("-1");
            }
            if (width == 0 || lenght == 0)
            {
                throw new Exception("-1");
            }
        }

        /// <summary>
        /// // method for validating each layer of bricks
        /// </summary>
        /// <param name="currentLenghtRow"></param>
        /// <param name="lengthFirstLayer"></param>
        public static void ValidateLayer(int currentLenghtRow,int lengthFirstLayer)
        {
            //check if current row of the inputData is corect lenght
            if (currentLenghtRow != lengthFirstLayer)
            {
                throw new Exception("-1");
            }
        }

        /// <summary>
        /// // method for validating bricks
        /// </summary>
        /// <param name="firstLayerBricks"></param>
        public static void ValidateBricks(int [,] firstLayerBricks)
        {
            // create dictionary to keep each unique brick and its count
            Dictionary<int, int> countEachbricks = new Dictionary<int, int>(); 

            for (int row = 0; row < firstLayerBricks.GetLength(0); row++)
            {

                for (int col = 0; col < firstLayerBricks.GetLength(1); col++)
                {
                    int currValue = firstLayerBricks[row, col];
                    if (!countEachbricks.ContainsKey(currValue))
                    {
                        countEachbricks[currValue] = 0;
                    }
                    countEachbricks[currValue]++;
                }
            }
            // check if any brick is spannig in more than 2 row or columns
            foreach (var (key, value) in countEachbricks) 
            {
                if (value > 2)
                {
                    throw new Exception("-1");
                }
            }
        }
    }
}