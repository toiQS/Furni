using Azure.Core;
using furni.Domain.Entities;
using furni.Infrastructure.IServices;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace furni.Application.Managements
{
    public class CategoryManageServices
    {
        private readonly IUserServices _userServices;
        private readonly IBrandServices _brandServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IProductService _productService;
        private Dictionary<string, object> _finalResult;
        private List<Dictionary<string, object>> _finalResultList;
        public CategoryManageServices(IUserServices userServices, IBrandServices brandServices, ICategoryServices categoryServices, IProductService productService)
        {
            _userServices = userServices;
            _brandServices = brandServices;
            _categoryServices = categoryServices;
            _productService = productService;
            _finalResult = new Dictionary<string, object>();
            _finalResultList = new List<Dictionary<string, object>>();
        }
        public async Task<List<Dictionary<string, object>>> GetAllBrandAndProductByCategoryId(int Id)
        {
            if(Id==null)
            {
                _finalResultList.Add(new Dictionary<string, object>()
                {
                    {"Message","Value input is invalid" }
                });
                return _finalResultList;
            }

            var getCategory = await _categoryServices.GetByIdAsync(Id);
            if(getCategory == null)
            {
                _finalResultList.Add(new Dictionary<string, object>()
                {
                    {"Message","Can't find category by Id" }
                });
                return _finalResultList;
            }
            var getAllBrand = await _brandServices.GetAsync();
            if (!getAllBrand.Any())
            {
                _finalResultList.Add(new Dictionary<string, object>()
                 {
                     {"Message","Can't find data of brand" }
                 });
                return _finalResultList;
            }
            foreach (var brand in getAllBrand)
            {
                var getProductList = await _productService.GetProductByBrandIdAndCategoryId(getCategory.Id, brand.Id);
                if (getProductList == null)
                {
                    _finalResultList.Add(new Dictionary<string, object>()
                     {
                        {"Message","Can't find product" }
                     });
                    return _finalResultList;
                }
                _finalResultList.Add(new Dictionary<string, object>
                {
                    {"BrandName",brand.Name},
                    {"Products",
                        getProductList.Select(x => new Dictionary<string,object>()
                        {
                            {"ProductName",x.Name },
                            {"Price",x.Price },
                            {"Message", "" }
                        })
                    }
                });
            }
            return _finalResultList;
        }
        public async Task<IEnumerable<Dictionary<string, object>>> GetAllCategory()
        {
            var getCategory = await _brandServices.GetAsync();
            if (!getCategory.Any())
            {
                _finalResultList.Add(new Dictionary<string, object>
                {
                    {"Message","Can't find categories" }
                });
                return _finalResultList;
            }
            foreach (var item in getCategory)
            {
                _finalResultList.Add(new Dictionary<string, object>
                {
                    {"Id",item.Id },
                    {"Name",item.Name},
                    {"Message", "" }
                });
            }
            return _finalResultList ;
        }
        public async Task<Dictionary<string, object>> GetCategoryById(int categoryId)
        {
            /// kiểm tra dữ liệu đầu vào có hợp lệ hay không
            /// kiểm tra truy xuất dữ liệu
            /// tinh gọn dữ liệu
            /// 
            if(categoryId == null)
            {
                _finalResult.Add("Message", "Value input is invalid");
                return _finalResult;
            }
            var getCategory = await _categoryServices.GetByIdAsync(categoryId);
            if (getCategory == null)
            {
                _finalResult.Add("Message", "Can't not find category");
                return _finalResult;
            }
            var result = new Dictionary<string, object>
            {
                {"Id",getCategory.Id },
                {"Name",getCategory.Name },
                //{"Description",getCategory.CategoryDescription },
                {"IsActive",getCategory.IsDeleted },
                {"Message", "" }
            };
            return _finalResult = result ;
        }
        public async Task<IEnumerable<Dictionary<string, object>>> GetCategoryByName(string name)
        {
            /// kiểm tra dữ liệu đầu vào có hợp lệ hay không
            /// kiểm tra truy xuất dữ liệu
            /// tinh gọn dữ liệu
            /// 
            if (name == null)
            {
                _finalResultList.Add(new Dictionary<string,object>
                {
                    {"Message", "Value input is invalid" }
                });
                return _finalResultList;
            }
            var getCategory = await _categoryServices.GetCategoriesByName(name);
            if (getCategory == null)
            {
                _finalResultList.Add(new Dictionary<string,object>()
                {
                    {"Message", "Can't not find category" }
                });
                return _finalResultList;
            }
            foreach (var item in getCategory)
            {
                _finalResultList.Add(new Dictionary<string, object>
                {
                    {"Id",item.Id },
                    {"Name",item.Name },
                    {"IsActive",item.IsDeleted },
                    {"Message", "" }
                });
                return _finalResultList ;
            }
            return _finalResultList;
        }
        public async Task<Dictionary<string, object>> Add(string userId, string name)
        {
            if (userId == null || name == null)
            {
                _finalResult.Add("Message", "Values input is invalid");
                return _finalResult;
            }
            var timeCurrent = DateTime.Now;
            var random = new Random().Next(1, 100000);
            var category = new Category
            {
                //Id = $"1002{timeCurrent}{random}",
                Name = name,
                IsDeleted = true,
            };
            if (await _categoryServices.CreateAsync(category))
            {
                _finalResult.Add("Message", "Action add is success");
                return _finalResult;
            }
            _finalResult.Add("Message", "There are some issue when trying create new data");
            return _finalResult;
        }
        public async Task<Dictionary<string, object>> UpdateInfo(string userId, int categoryId , string name)
        {
            if(string.IsNullOrWhiteSpace(userId)||string.IsNullOrEmpty(name) || categoryId==null)
            {
                _finalResult.Add("Message", "Values input is invalid");
                return _finalResult;
            }
            var getCategory = await _categoryServices.GetByIdAsync(categoryId);
            if(getCategory== null)
            {
                _finalResult.Add("Message", "Can't found category");
                return _finalResult;
            }
            getCategory.Name = name;
            if (await _categoryServices.UpdateAsync(categoryId,getCategory))
            {
                _finalResult.Add("Message", "Action update is success");
                return _finalResult;
            }
            _finalResult.Add("Message", "There are some issue when trying update a data");
            return _finalResult;
        }
        public async Task<Dictionary<string, object>> UpdateStatus(string userId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(userId) || categoryId==null)
            {
                _finalResult.Add("Message", "Values input is invalid");
                return _finalResult;
            }
            var getCategory = await _categoryServices.GetByIdAsync(categoryId);
            if (getCategory == null)
            {
                _finalResult.Add("Message", "Can't found category");
                return _finalResult;
            }
            getCategory.IsDeleted = !getCategory.IsDeleted;
            if (await _categoryServices.UpdateAsync(categoryId, getCategory))
            {
                _finalResult.Add("Message", "Action update is success");
                return _finalResult;
            }
            _finalResult.Add("Message", "There are some issue when trying update a data");
            return _finalResult;
        }
        public async Task<Dictionary<string, object>> Delete(string userId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(userId) || categoryId==null)
            {
                _finalResult.Add("Message", "Values input is invalid");
                return _finalResult;
            }
            var getCategory = await _categoryServices.GetByIdAsync(categoryId);
            if (getCategory == null)
            {
                _finalResult.Add("Message", "Can't found category");
                return _finalResult;
            }
            if (await _categoryServices.DeleteAsync(categoryId))
            {
                _finalResult.Add("Message", "Action delete is success");
                return _finalResult;
            }
            _finalResult.Add("Message", "There are some issue when trying delete a data");
            return _finalResult;
        }
    }
}
