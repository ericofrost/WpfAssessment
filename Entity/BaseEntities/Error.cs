namespace Entity.BaseEntities
{
    /// <summary>
    /// Error entity to show error details during the application runtime
    /// </summary>
    public class Error
    {
        /// <summary>
        /// The error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The error code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The stack trace in case an exception occours
        /// </summary>
        public string Stacktrace { get; set; }
    }
}
