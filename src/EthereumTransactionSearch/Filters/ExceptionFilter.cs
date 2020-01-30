using EthereumTransactionSearch.Exceptions;
using EthereumTransactionSearch.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EthereumTransactionSearch.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case InvalidRequestException ex:
                    _logger.LogWarning(ex, ex.ErrorMessage);

                    context.Result = new ObjectResult(new ApiErrorResponse { Message = ex.ErrorMessage })
                    {
                        StatusCode = (int)HttpStatusCode.UnprocessableEntity
                    };
                    break;

                default:
                    _logger.LogError(context.Exception, "An unexpected error was encountered");

                    context.Result = new ObjectResult(new ApiErrorResponse { Message = "An unexpected error was encountered" })
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };
                    break;
            }
        }
    }
}