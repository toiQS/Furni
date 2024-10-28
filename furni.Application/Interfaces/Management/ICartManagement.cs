using furni.Entities;

namespace furni.Application.Interfaces.Management;

public interface ICartManagement
{
    Task<BaseResponse<Cart>> GetByIdAsync(string id);
}
