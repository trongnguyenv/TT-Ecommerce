namespace TTEcommerce.Core.Infrastructure.WebApi;

public class CustomControllerBase : ControllerBase
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;

    public CustomControllerBase()
    {
    }

    public CustomControllerBase(ICommandBus commandBus, IQueryBus queryBus)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
    }

    protected new async Task<IActionResult> Response<TResult>(IQuery<TResult> query,
        CancellationToken cancellationToken)
    {
        TResult result;

        try
        {
            result = await _queryBus.SendAsync(query, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            return StatusCode(500, "Operation was canceled.");
        }
        catch (Exception e)
        {
            return BadRequestActionResult(e.Message);
        }

        return Ok(new ApiResponse<TResult>
        {
            Data = result,
            Success = true
        });
    }

    protected new async Task<IActionResult> Response(ICommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            await _commandBus.SendAsync(command, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            // Handle cancellation
            return StatusCode(500, "Operation was canceled.");
        }
        catch (Exception e)
        {
            return BadRequestActionResult(e.Message);
        }

        return Ok(new ApiResponse<IActionResult>
        {
            Success = true
        });
    }

    protected IActionResult BadRequestActionResult(string resultErrors)
    {
        return BadRequest(new ApiResponse<IActionResult>
        {
            Success = false,
            Message = resultErrors
        });
    }
}
