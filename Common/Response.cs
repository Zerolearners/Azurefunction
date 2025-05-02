namespace ai_finder_be_schedulers_donetcore.Common;

public class Response
{
    public ResponseDTO GetCommonSuccessResponse(string message)
    {
        return new ResponseDTO
        {
            Success = true,
            Message = message
        };
    }

    public ResponseDTO GetCommonFailureResponse(string message)
    {
        return new ResponseDTO
        {
            Success = false,
            Message = message
        };
    }
}
