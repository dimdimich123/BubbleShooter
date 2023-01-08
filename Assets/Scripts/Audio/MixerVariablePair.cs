namespace Audio
{
    /// <summary>
    /// A simple class that has a pair of values ​​(<see cref="MixerVariables"/> and an array of strings)
    /// </summary>
    [System.Serializable]
    public sealed class MixerVariablePair
    {
        public MixerVariables Variable;
        public string Value;
    }
}