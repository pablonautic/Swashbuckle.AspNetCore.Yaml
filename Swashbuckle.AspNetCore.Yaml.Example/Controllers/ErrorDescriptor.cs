namespace SwaggerPhun.Controllers
{
    /// <summary>
    /// Error descriptor object returned for non-2xx responses
    /// </summary>
    public class ErrorDescriptor
    {
        /// <summary>
        /// Verbose message that helps a developer understand the problem
        /// </summary>
        public string TechnicalMessage { get; set; }

        /// <summary>
        /// Concise message that is appropriate to display to a user
        /// </summary>
        public string UserMessage { get; set; }

        /// <summary>
        ///  ID of an error message that can be used to lookup more info in an error report
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// URL to documentation about the error
        /// </summary>
        public string MoreInfo { get; set; }
    }
}