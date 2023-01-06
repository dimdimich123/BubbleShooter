namespace Infrastructure.SavingData
{
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