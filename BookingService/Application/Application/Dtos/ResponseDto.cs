namespace Application.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public ResponseDto()
        {
            Success= true;
        }

        public ResponseDto<T> WithMessage(string mensagem)
        {
            Message = mensagem;
            return this;
        }

        public ResponseDto<T> SendData(T data)
        {
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
