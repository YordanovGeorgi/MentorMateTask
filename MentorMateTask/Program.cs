using System;

namespace MentorMateTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //read data for the first layer of bricks
                var firstLayer = InputDataValidatorAndTransformator.ReadDataForFirstLayer();
                //collect all uniqe bricks in first layer of bricks
                var bricks = Bricks.CollectNeededBricksForSecondLayer(firstLayer);
                // create second layer of bricks using first layer and queue with bricks
                int[,] secondLayer = SecondLayerBuilder.BuildSecondLayer(firstLayer, bricks);
                // print second layer of bricks
                Print.PrintSecondLayerBricks(firstLayer.GetLength(0), firstLayer.GetLength(1), secondLayer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}