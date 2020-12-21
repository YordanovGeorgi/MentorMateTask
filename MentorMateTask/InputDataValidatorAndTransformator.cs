namespace MentorMateTask
{
    /// <summary>
    /// Read input data and validate it
    /// </summary>
    public class InputDataValidatorAndTransformator
    {
        /// <summary>
        /// read data and validate it
        /// </summary>
        /// <returns></returns>
        public static int [,] ReadDataForFirstLayer()
        {
            // read dimensions of the first layer of bricks
            var dimensionsFirstLayer = ReadData.ReadDimensions();

            // width of the first layer
            var width = dimensionsFirstLayer[0];
            // lenght of the first layer
            var length = dimensionsFirstLayer[1];

            // validate input dimensions of the first layer
            Validation.ValidateDimensions(width, length);

            // create matrix with input dimensions
            int[,] firstLayer = ReadData.ReadFirstLayerOfBricks(width, length);
           
            // validate bricks don't spann in 3 rows or columns 
            Validation.ValidateBricks(firstLayer);

            return firstLayer;
        }
    }
}