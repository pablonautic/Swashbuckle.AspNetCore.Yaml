namespace SwaggerPhun.Controllers
{
    public class FileCommentCollectionDto
    {
        public string SelfLink { get; set; }

        public string Kind { get; set; }

        public FileCommentDto[] Contents { get; set; }
    }
}