namespace Application.Exceptions
{
    public class ManagerException : Exception
    {
        public IReadOnlyCollection<string> Errors { get; set; }

        public ManagerException(string error) : base(error)
        {
            Errors = new List<string>() { error };
        }
        public ManagerException(IReadOnlyCollection<string> errors) : base(String.Join(" - ", errors))
        {
            Errors = errors;
        }
    }
}
