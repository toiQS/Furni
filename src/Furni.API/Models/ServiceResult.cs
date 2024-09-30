using System.IO.Pipes;

namespace Furni.API.Models
{
    public class ServiceResult<T>
    {
        public string Messenger {  get; set; } = string.Empty;
        public T Value { get; set; }
        public bool Status { get; set; }
        public ServiceResult() { }
        public ServiceResult(T value)
        {
            Value = value;
            Messenger = "This action is success";
            Status = true;
        }
        public static ServiceResult<T> SuccessResult(T value)
        {
            return new ServiceResult<T>(value);
        }
        public ServiceResult(string message)
        {
            Messenger = message;
            Status = false;
            
        }
        public static ServiceResult<T> FailureResult(string message)
        {
            return new ServiceResult<T>(message);
        }
    }
}
