using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest,TResponse>
    (ILogger<LoggingBehavior<TRequest,TResponse>> logger):IPipelineBehavior<TRequest,TResponse>
where TRequest:notnull, IRequest<TResponse>
where TResponse:notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle request = {Request} - Response={Response} - RequestData={RequestData}", 
            typeof(TRequest),typeof(TResponse).Name,request);

        var timer = new Stopwatch();
        timer.Start();
        
        var response = await next();
        
        timer.Stop();

        var timeTaken = timer.Elapsed;
        if (timeTaken.Seconds>3) // Log warning if the request took more than 3 seconds
        {
            logger.LogWarning("[PERFORMANCE] The request {Request} took {TimeTaken}", 
                typeof(TRequest).Name,timeTaken.Seconds);
        }
        
        logger.LogInformation("[END] Handle request = {Request} with {Response}", 
            typeof(TRequest),typeof(TResponse).Name);

        return response;

    }
}
