using System.Net;

namespace Escola.Domain.Dtos
{
    public class ResultadoDto<T> where T : class
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        public ResultadoDto(HttpStatusCode statusCode, string message, T data = null)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public static ResultadoDto<TResult> Create<TResult>(HttpStatusCode statusCode, string message, TResult data) where TResult : class
        {
            return new ResultadoDto<TResult>(statusCode, message, data);
        }
    }

    public class ResultadoDto : ResultadoDto<object>
    {
        public ResultadoDto(HttpStatusCode statusCode, string message) : base(statusCode, message, null)
        {
        }

        public static ResultadoDto Create(HttpStatusCode statusCode, string message)
        {
            return new ResultadoDto(statusCode, message);
        }
    }
}
