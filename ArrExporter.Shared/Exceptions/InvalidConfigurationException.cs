namespace ArrExporter.Shared.Exceptions
{
    /// <summary>
    /// Special kind of exception, which is known and no need to report call stack on it's failure.
    /// </summary>
    public class InvalidConfigurationException : Exception
    {
        public InvalidConfigurationException(string variableName)
            : base($"{variableName} is either missing or misconfigured.")
        { }
    }
}