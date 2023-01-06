using System;

namespace Infrastructure.SavingData
{
    [Serializable]
    public sealed class LevelRecords
    {
        public static readonly string Path = "/data/Records.dat";

        private RecordInfo[] _records;

        public LevelRecords()
        {
            _records = new RecordInfo[Enum.GetNames(typeof(LevelNumberId)).Length];
            for(int i = 0; i < _records.Length; i++)
            {
                _records[i] = new RecordInfo((LevelNumberId)i, 0);
            }
        }

        public RecordInfo this[LevelNumberId id]
        {
            get
            {
                try
                {
                    return _records[(int)id];
                }
                catch
                {
                    throw new System.Exception("index was outside the array");
                }
            }

            set
            {
                _records[(int)id] = value;
            }
        }
    }
}