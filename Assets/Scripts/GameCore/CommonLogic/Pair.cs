namespace GameCore.CommonLogic
{
    /// <summary>
    /// A simple class that has a pair of int values
    /// </summary>
    public sealed class Pair
    {
        public int FirstValue;
        public int SecondValue;

        public Pair(int firstValue, int secondValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
        }
    }
}