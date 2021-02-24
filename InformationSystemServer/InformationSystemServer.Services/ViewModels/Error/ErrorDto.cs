namespace InformationSystemServer.Services.ViewModels.Error
{
    public class ErrorDto
    {
        public ErrorDto(int statusCode, string message = null, string details = null)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Details = details;
        }

        public int StatusCode { get; set; }

        public string Message { get; }

        public string Details { get; }
    }
}
