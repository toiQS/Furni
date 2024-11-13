using furni.Domain.Entities;
using furni.Application.Dtos;

namespace furni.Application.Interfaces.Management;

public interface ICartManagement
{
    Task<BaseResponse<CartDto>> GetByIdAsync(string id);
}
