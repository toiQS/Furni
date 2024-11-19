using System.Diagnostics;
using furni.Application.Interfaces.Management;
using furni.Domain.Entities;
using furni.Infrastructure.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace furni.Application.Management
{
    public class BrandManageServices :IBrandManageServices
    {
        private readonly IUserServices _userServices;
        private readonly IBrandServices _brandServices;
        public BrandManageServices(IUserServices userServices, IBrandServices brandServices)
        {
            _userServices = userServices;
            _brandServices = brandServices;
        }
        
        public async Task<IEnumerable<Dictionary<string,object>>> GetAllBrand()
        {
            ///lấy toàn bộ dữ liệu từ bảng thương hiệu
            ///kiểu tra dữ liệu đã lấy được hay chưa
            ///cấu hình trả về danh sách dữ liệu chỉ chứa id và tên thương hiệu
            ///

            //declare a value return
            var finalResult = new List<Dictionary<string, object>>();
            //get brand data and check can it get data?
            var getBrand = await _brandServices.GetAsync();
            if (getBrand == null)
            {
                finalResult.Add(new Dictionary<string, object>()
                {
                    {"Message","Can't get data from brand table"}
                });
            }
            else
            {
                foreach (var brand in getBrand)
                {
                    finalResult.Add( new Dictionary<string, object>
                    {
                        {"Brand Id :", brand.Id},
                        {"Brand Name:",brand.BrandName},
                    });
                }
            }
            return finalResult;
        }
        public async Task<IEnumerable<Dictionary<string,object>>> GetAllBrandByName(string name)
        {
            ///kiểm tra tên thương hiệu có bị trống hay không
            ///kiểm tra có tên thương hiệu nào trùng với các từ khóa liên quan hay không
            ///kiểm tra dánh sách có tồn tại dữ liệu hay không
            ///trả dữ liệu về dưới dạng danh sách bao gồm mã số thương hiệu và tên thương hiệu
            ///

            //declare valuse return
            var finalResult = new List<Dictionary<string ,object>>();
            //check name (brand name) is null?
            if(string.IsNullOrEmpty(name))
            {
                finalResult.Add(new Dictionary<string, object>
                {
                    {"Message","Brand name is null"}
                });
                return finalResult;
            } 
            var getBrandsByName = await _brandServices.GetBrandsByName(name);
            if (getBrandsByName == null)
            {
                finalResult.Add(new Dictionary<string, object>
                {
                    {"Message","Can't get list brand by name or data wasn't existed"}
                });
                return finalResult;
            }
            else
            {
                foreach (var brand in getBrandsByName)
                {
                    finalResult.Add( new Dictionary<string, object>
                    {
                        {"Brand Id :", brand.Id},
                        {"Brand Name:",brand.BrandName},
                    });
                }
            }
            return finalResult;
        }
        public async Task<Dictionary<string,string>> AddNewBrand(string userId, string name, string description, string email, string phone)
        {
            ///kiểm tra dữ liệu đầu vào đã được cung cấp hay chưa
            ///kiểm tra mã người dùng có tồn tại hay không
            ///kiểm tra lại quyền của người dùng trong hệ thống
            ///kiểm tra tên thương hiệu mới đã tồn tại hay chưa
            ///thực hiện việc thêm dữ liệu vào hệ thống và kiểm tra kết quả
            ///

            //declare value return
            var finalResult = new Dictionary<string,string>();
            // check data input (user id and brand ) are null?
            if(string.IsNullOrEmpty(userId) || name == null || description == null|| email == null || phone == null)
            {
                finalResult.Add("Message","Data input is invalid");
                return finalResult;
            }
            // find user in database
            var findUser = await _userServices.GetUserByIdAsync(userId);
            if (findUser == null)
            {
                finalResult.Add("Message","Can't find user");
                return finalResult;
            }
            // // get role name of user
            // var getRole = await _userServices.GetRoleByUserId(userId);
            // if(getRole == null)
            // {
            //     finalResult.Add("Message","Can't get role of user");
            //     return finalResult;
            // }
            // if(getRole.Name != "Admin")
            // {
            //     finalResult.Add("Message","Insufficient authority");
            //     return finalResult;
            // }

            // check brand name is existed
            var getBrandsByName = await _brandServices.GetBrandsByName(name);
            if (getBrandsByName.Any())
            {
                finalResult.Add("Message","Brand name was existed");
                return finalResult;
            }
            var timeCurrent = DateTime.Now;
            var random = new Random().Next(1,100000);
            var brand = new Brand
            {
                Id =$"1001-{timeCurrent}-{random}",
                BrandName = name,
                //BrandDescription = description,
                //BrandEmail = email,
                //BrandPhone = phone,
                IsDeleted = true
            };
            // todo add new brand 
            var addBrand = await _brandServices.CreateAsync(brand);
            if (addBrand == false)
            {
                finalResult.Add("Message","There are some issue when creating a new brand");
                return finalResult;
            }
            else
            {
                finalResult.Add("Message","Add a new brand is success");
                return finalResult;
            }
            
        }
        public async Task<Dictionary<string,string>> UpdateBrandInfo(string userId,string brandId, string name, string description, string email, string phone)
        {
            //kiểm tra dữ liệu đầu vào đã được cung cấp hay chưa
            ///kiểm tra mã người dùng có tồn tại hay không
            ///kiểm tra lại quyền của người dùng trong hệ thống
            ///kiểm tra dữ liệu cần thay đổi có tồn tại hay không
            ///thực hiện việc thêm dữ liệu vào hệ thống và kiểm tra kết quả
            ///

            //declare value return
            var finalResult = new Dictionary<string,string>();
            // check data input (user id and brand ) are null?
            if(string.IsNullOrEmpty(userId) || name == null || description == null|| email == null || phone == null)
            {
                finalResult.Add("Message","Data input is invalid");
                return finalResult;
            }
            // find user in database
            var findUser = await _userServices.GetUserByIdAsync(userId);
            if (findUser == null)
            {
                finalResult.Add("","Can't find user");
                return finalResult;
            }
            // // get role name of user
            // var getRole = await _userServices.GetRoleByUserId(userId);
            // if(getRole == null)
            // {
            //     finalResult.Add("Message","Can't get role of user");
            //     return finalResult;
            // }
            // if(getRole.Name != "Admin")
            // {
            //     finalResult.Add("Message","Insufficient authority");
            //     return finalResult;
            // }

            // get brand by brand id
            var oldBrand = await _brandServices.GetByIdAsync(brandId);
            if (oldBrand == null)
            {
                finalResult.Add("Message","Brand wasn't existed");
                return finalResult;
            }
            //todo update brand
            oldBrand.BrandName = name;
            //oldBrand.BrandDescription = description;
            //oldBrand.BrandPhone = phone;
            //oldBrand.BrandEmail = email;
            
            var updateBrand = await _brandServices.UpdateAsync(brandId, oldBrand);
            if(updateBrand == true)
            {
                finalResult.Add("Message","Update brand is success");
                return finalResult;
            }
            else
            {
                finalResult.Add("Message", "There are some issue when update brand.");
                return finalResult;
            }
            
        }
        public async Task<Dictionary<string,string>> UpdateBrandStastus(string userId, string brandId)
        {
             //declare value return
            var finalResult = new Dictionary<string,string>();
            // check data input (user id and brand ) are null?
            if(string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(brandId))
            {
                finalResult.Add("Message","Data input is invalid");
                return finalResult;
            }
            // find user in database
            var findUser = await _userServices.GetUserByIdAsync(userId);
            if (findUser == null)
            {
                finalResult.Add("Message","Can't find user");
                return finalResult;
            }
            // // get role name of user
            // var getRole = await _userServices.GetRoleByUserId(userId);
            // if(getRole == null)
            // {
            //     finalResult.Add("Message","Can't get role of user");
            //     return finalResult;
            // }
            // if(getRole.Name != "Admin")
            // {
            //     finalResult.Add("Message","Insufficient authority");
            //     return finalResult;
            // }

            var oldBrand = await _brandServices.GetByIdAsync(brandId);
            if (oldBrand == null)
            {
                finalResult.Add("Message","Brand wasn't existed");
                return finalResult;
            }
            oldBrand.IsDeleted = !oldBrand.IsDeleted;
            if(await _brandServices.UpdateAsync(brandId, oldBrand))
            {
                finalResult.Add("Message","Update brand is success");
                return finalResult;
            }
            else
            {
                finalResult.Add("Message", "There are some issue when update brand.");
                return finalResult;
            }
        }
        public async Task<Dictionary<string ,string>> DeleteBrand(string userId,string brandId)
        {
            //kiểm tra dữ liệu đầu vào đã được cung cấp hay chưa
            ///kiểm tra mã người dùng có tồn tại hay không
            ///kiểm tra lại quyền của người dùng trong hệ thống
            ///kiểm tra tên thương hiệu mới đã tồn tại hay chưa
            ///thực hiện việc thêm dữ liệu vào hệ thống và kiểm tra kết quả
            ///

            //declare value return
            var finalResult = new Dictionary<string,string>();
            // check data input (user id and brand ) are null?
            if(string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(brandId))
            {
                finalResult.Add("Message","Data input is invalid");
                return finalResult;
            }
            // find user in database
            var findUser = await _userServices.GetUserByIdAsync(userId);
            if (findUser == null)
            {
                finalResult.Add("Message","Can't find user");
                return finalResult;
            }
            // // get role name of user
            // var getRole = await _userServices.GetRoleByUserId(userId);
            // if(getRole == null)
            // {
            //     finalResult.Add("Message","Can't get role of user");
            //     return finalResult;
            // }
            // if(getRole.Name != "Admin")
            // {
            //     finalResult.Add("Message","Insufficient authority");
            //     return finalResult;
            // }
            //todo delete brand
            var deleteBrand = await _brandServices.DeleteAsync(brandId);
            if (deleteBrand == false)
            {
                finalResult.Add("Message","There are have some issue when trying delete brand data.");
                return finalResult;
            }
            else
            {
                finalResult.Add("Message","Delete brand is success");
                return finalResult;
            }
        }
    }
}
