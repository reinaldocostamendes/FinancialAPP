using Infrastructure.Context.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Controller
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IServiceContext _serviceContext;

        public ApiControllerBase(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        /// <summary>
        /// Response default
        /// </summary>
        /// <param name="result"></param>
        protected IActionResult ServiceResponse(object result = null)
        {
            return _serviceContext.HasNotification()
                ? BadRequest(new ApiResult<string>(_serviceContext.Notifications))
                : Ok(new ApiResult<object>(result));
        }

        /// <summary>
        /// Response default
        /// </summary>
        /// <param name="result"></param>
        protected IActionResult ServiceResponse<T>(T result = default)
        {
            return _serviceContext.HasNotification()
                ? BadRequest(new ApiResult<string>(_serviceContext.Notifications))
                : Ok(new ApiResult<T>(result));
        }
    }
}