using System.ComponentModel.DataAnnotations;

namespace SwaggerPhun.Controllers
{
    /// <summary>
    /// DTO object representing the comment
    /// </summary>
    public class FileCommentDto
    {
        /// <summary>
        /// The content text of the comment
        /// </summary>
        [Required] public string Text { get; set; }
    }
}