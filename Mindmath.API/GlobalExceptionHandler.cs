using Microsoft.AspNetCore.Diagnostics;
using Mindmath.Application.IService;
using Mindmath.Domain.ErrorModel;
using Mindmath.Domain.Exceptions;

namespace Mindmath.API
{
	public class GlobalExceptionHandler : IExceptionHandler
	{
		private readonly ILoggerManager loggerManager;

		public GlobalExceptionHandler(ILoggerManager loggerManager)
		{
			this.loggerManager = loggerManager;
		}
		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
		{
			httpContext.Response.ContentType = "application/json";

			var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
			if (contextFeature is not null)
			{
				httpContext.Response.StatusCode = contextFeature.Error switch
				{
					NotFoundException => StatusCodes.Status404NotFound,
					_ => StatusCodes.Status500InternalServerError,
				};

				loggerManager.LogError($"Something went wrong: {exception.Message}");
				await httpContext.Response.WriteAsync(new ErrorDetails()
				{
					StatusCode = httpContext.Response.StatusCode,
					Message = contextFeature.Error.Message
				}.ToString());
			}
			return true;
		}
	}
}
