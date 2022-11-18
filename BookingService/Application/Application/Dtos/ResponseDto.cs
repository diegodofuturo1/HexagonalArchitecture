namespace Application.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public ResponseDto(string mensagem)
        {
            Success = true;
            Message = mensagem;
        }

        public ResponseDto<T> SendData(T data)
        {
            Success = true;
            Data = data;
            return this;
        }

        public ResponseDto<T> WithErrors(string error)
        {
            Success = false;
            Errors = new List<string> { error };
            return this;
        }

        public ResponseDto<T> WithErrors(IReadOnlyCollection<string> errors)
        {
            Success = false;
            Errors = errors.ToList();
            return this;
        }
    }
}
