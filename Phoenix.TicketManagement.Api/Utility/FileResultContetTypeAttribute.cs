namespace Phoenix.TicketManagement.Api.Utility
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FileResultContetTypeAttribute : Attribute
    {
        public FileResultContetTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }

        public string ContentType { get; set; }
    }
}
