namespace Stock.Core.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string Error { get; set; }

        public static Response<T> Success(int statusCode, T data)
        {
            return new Response<T> { Data = data, StatusCode = statusCode };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { StatusCode = statusCode };
        }
        public static Response<T> Fail(int statusCode, string error)
        {
            return new Response<T> { StatusCode = statusCode, Error = error };
        }
    }
}
