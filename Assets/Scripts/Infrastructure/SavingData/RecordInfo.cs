namespace Infrastructure.SavingData
{
    /// <summary>
    /// Stores the record value for level
    /// </summary>
    /// <remarks>
    /// A simple class that has a pair of values ​​(<see cref="LevelNumberId"/> and <see cref="int"/>)
    /// </remarks>
    [System.Serializable]
    public sealed class RecordInfo
    {
        public LevelNumberId LevelId;
        public int Score;

        public RecordInfo(LevelNumberId levelId, int score)
        {
            LevelId = levelId;
            Score = score;
        }
    }
}