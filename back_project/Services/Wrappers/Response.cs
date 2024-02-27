namespace back_project.Services.Wrappers
{  
    public class Response<T>
    {
        public bool Succeeded { get; set; }

        public int StatusCode { get; set; }

        public string? Message { get; set; }

        public List<string>? Errors { get; set; }

        public T? Data { get; set; }

        public Response() { }

        public Response(List<string> errors, int statusCode)
        {
            Succeeded = false;
            Message = "An internal error has occurred on the server."; 
            Errors = errors;
            StatusCode = statusCode;
        }

        public Response(T data, int statusCode ,string message = "Succefully")
        {
            Succeeded = true;
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }

    }
}


