namespace Infrastructure.Service.Interface
{
    public class ErrorMessage<T> where T : class
    {
        public string Code { get; private set; }
        public string Message { get; private set; }
        public T Contract { get; private set; }

        public ErrorMessage(string code, string message, T contract)
        {
            Code = code;
            Message = message;
            Contract = contract;
        }
    }
}