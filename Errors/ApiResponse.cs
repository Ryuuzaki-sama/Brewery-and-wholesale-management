namespace Brewery_and_wholesale_management.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "you have made a bad request",
                401 => "you are not Authorized",
                404 => "Resource not found",
                500 => "The information you are requesting does not exist",
                _ => null
            };
        }
    }
    }
}
