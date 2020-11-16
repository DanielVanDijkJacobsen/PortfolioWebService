
namespace WebService.Wrappers
{
    public class ResponseWrapper<T>
    {
        public ResponseWrapper()
        {
        }
        public ResponseWrapper(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
