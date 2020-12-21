using System.Collections.Generic;

namespace MentorMateTask
{
    /// <summary>
    /// Build second layer of bricks
    /// </summary>
    public class SecondLayerBuilder
    {
        /// <summary>
        /// Build second layer of bricks based on the first layer
        /// </summary>
        /// <param name="firstLayer"></param>
        /// <param name="bricks"></param>
        /// <returns>matrix that contains second layer of bricks</returns>
        public static int[,] BuildSecondLayer(int[,] firstLayer, Queue<int> bricks)
        {
            // taking the width from the firstLayer 
            var width = firstLayer.GetLength(0);
            // taking the lenght from the firstLayer
            var length = firstLayer.GetLength(1);
            // create instance of matrix for second layer of bricks
            int[,] secondLayer = new int[width, length];                    

            for (int row = 0; row < width; row += 2)                    
            {
                for (int col = 0; col < length; col += 2)
                {
                    //value of the first index in the matrix  
                    var firstHalfBrick = firstLayer[row, col];
                    //value of the second index in the matrix 
                    var secondHalfBrick = firstLayer[row, col + 1];

                    // bulding two rows of second layer if firstHalfBrick and secondHalfBrick are equal
                    if (firstHalfBrick == secondHalfBrick)                  
                    {
                        if (col != 0 && secondLayer[row, col - 1] == 0 && col - 1 % 2 != 0)
                        {
                            //method for bulding two rows at second layer if previus brick is vertical
                            BuildingIfPreviusBrickVertical(row, col, secondLayer, bricks); 
                        }
                        else
                        {
                            //bulding two rows at second layer if previus brick is horizontal
                            var currValue = bricks.Dequeue();           
                            secondLayer[row, col] = currValue;
                            secondLayer[row + 1, col] = currValue;

                            //bulding two rows at second layer if first layer lenght is 2
                            if (length == 2)                            
                            {
                                currValue = bricks.Dequeue();
                                secondLayer[row, col + 1] = currValue;
                                secondLayer[row + 1, col + 1] = currValue;
                            }
                        }
                    }
                    else   // bulding two rows of second layer if firstHalfBrick and secondHalfBrick are not equal
                    {
                        if (col != 0 && secondLayer[row, col - 1] == 0 && col - 1 % 2 != 0)
                        {
                            //method for bulding two rows at second layer if previus brick is vertical
                            BuildingIfPreviusBrickVertical(row, col, secondLayer, bricks);  
                        }
                        else
                        {
                            //bulding two rows at second layer if previus brick is horizontal
                            var currValue = bricks.Dequeue();                              
                            secondLayer[row, col] = currValue;
                            secondLayer[row, col + 1] = currValue;

                            currValue = bricks.Dequeue();
                            secondLayer[row + 1, col] = currValue;
                            secondLayer[row + 1, col + 1] = currValue;
                        }
                    }
                }
            }
            return secondLayer;
        }

        /// <summary>
        ///method for bulding two rows at second layer if previus brick is vertical
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="secondLayer"></param>
        /// <param name="bricks"></param>
        private static void BuildingIfPreviusBrickVertical(int row, int col, int[,] secondLayer, Queue<int> bricks) 
        {
            var currValue = bricks.Dequeue();
            secondLayer[row, col - 1] = currValue;
            secondLayer[row, col] = currValue;
            currValue = bricks.Dequeue();
            secondLayer[row + 1, col - 1] = currValue;
            secondLayer[row + 1, col] = currValue;
            currValue = bricks.Dequeue();

            secondLayer[row, col + 1] = currValue;
            secondLayer[row + 1, col + 1] = currValue;
        }
    }
}