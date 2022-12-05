namespace Stock.Core.Models
{
    public enum ResultCodes
    {
        Success = 200,
        Created = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        MethodNotAllowed = 405,
        ServerError = 500
    }
}
