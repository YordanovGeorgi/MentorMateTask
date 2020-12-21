using System.Collections.Generic;

namespace MentorMateTask
{
    /// <summary>
    /// collection of uniqe bricks
    /// </summary>
    public class Bricks
    {
        /// <summary>
        /// Collect all uniqe bricks from first layer and store them into queue to be used for building second layer
        /// </summary>
        public static Queue<int> CollectNeededBricksForSecondLayer(int[,] firstLayer)
        {
            var width = firstLayer.GetLength(0);
            var length = firstLayer.GetLength(1);
           
            // create queue to keep all uniqe bricks
            var bricks = new Queue<int>();

            // iterating through the matrix to collect all uniqe bricks
            for (int row = 0; row < width; row++)   
            {
                for (int col = 0; col < length; col++)
                {
                    // current brick
                    var currentNumBrick = firstLayer[row, col];
                    
                    //check the brick is already in the queue
                    if (!bricks.Contains(currentNumBrick)) 
                    {
                        bricks.Enqueue(currentNumBrick);
                    }
                }
            }
            return bricks;
        }
    }
}