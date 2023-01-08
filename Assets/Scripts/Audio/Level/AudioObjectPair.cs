namespace Audio.Level
{
    /// <summary>
    /// A simple class that has a pair of values ​​(<see cref="AudioObjectTypeID"/> 
    /// and an array of <see cref="UnityEngine.AudioClip"/>)
    /// </summary>
    [System.Serializable]
    public sealed class AudioObjectPair
    {
        public AudioObjectTypeID _audioType;
        public UnityEngine.AudioClip[] _clips;
    }
}