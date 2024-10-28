public class BaseResponse<T>
{
    public string Message { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
    public string Code { get; set; }
    public T Data { get; set; }
}
