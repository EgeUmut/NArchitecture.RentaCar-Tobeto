using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class BusinessProblemDetails:ProblemDetails
{
    public BusinessProblemDetails(string detail)
    {
        Title = "Business Rule Error";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = "http://tobeto.com/probs/business";
    }
}
