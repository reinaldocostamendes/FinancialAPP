using System.Collections.Generic;

namespace Infrastructure.Controller
{
    public class ApiResult<T>
    {
        public IReadOnlyCollection<string> ErrorMessage { get; set; }
        public T Contract { get; set; }

        public ApiResult(T contract)
        {
            Contract = contract;
        }

        public ApiResult(IReadOnlyCollection<string> errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}