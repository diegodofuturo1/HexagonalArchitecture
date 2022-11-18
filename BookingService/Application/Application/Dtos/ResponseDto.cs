namespace Application.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public ResponseDto(T data)
        {
            Data = data;
        }

        public ResponseDto(T data, bool success, string message, List<string> errors)
        {
            Data = data;
            Success = success;
            Message = message;
            Errors = errors;
        }
    }
}
