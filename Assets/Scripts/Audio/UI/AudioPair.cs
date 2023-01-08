namespace Audio.UI
{
    /// <summary>
    /// A simple class that has a pair of values ​​(<see cref="AudioUITypeID"/> 
    /// and an array of <see cref="UnityEngine.AudioClip"/>)
    /// </summary>
    [System.Serializable]
    public sealed class AudioPair
    {
        public AudioUITypeID _audioType;
        public UnityEngine.AudioClip[] _clips;
    }
}