using System.Security.Cryptography.X509Certificates;
using furni.Application.Interfaces.Management;
using furni.Entities;
using furni.Infrastructure.IServices;

namespace furni.Application.Management
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUserServices _userServices;
        private readonly ICategoryServices _categoryServices;
        public CategoryManager(IUserServices userServices, ICategoryServices categoryServices)
        {
            _userServices = userServices;
            _categoryServices = categoryServices;
        }
        public async Task<IEnumerable<Dictionary<string,object>>> GetAllCategory()
        {
            ///truy cập lấy thong tin từ cơ sở dữ liệu
            ///kiểm tra dữ liệu đã lấy được hay không
            ///kết quả cuối trả về bao gồm mã số và tên của loại
            ///
            
            //declare a value return
            var finalResult = new List<Dictionary<string,object>>();

            //get all category form database
            var getCategory = await _categoryServices.GetAsync();
            if(getCategory == null)
            {
                finalResult.Add(new Dictionary<string,object>()
                {
                    {"Message:","Can't get category data"}
                });
                return finalResult;
            }
            else
            {
                foreach(var category in getCategory)
                {
                    finalResult.Add(new Dictionary<string, object>()
                    {
                        {"Id:",category.Id },
                        {"Name:",category.CategoryName}
                    });
                }
            }
            return finalResult;
        }
        public async Task<IEnumerable<Dictionary<string, object>>> GetAllCategoryByCategoryName(string name)
        {
            ///truy cập lấy thong tin từ cơ sở dữ liệu
            ///kiểm tra dữ liệu đã lấy được hay không
            ///kết quả cuối trả về bao gồm mã số và tên của loại
            ///
            
            
            //declare a value return
            var finalResult = new List<Dictionary<string,object>>();

            //check data input is null
            if(string.IsNullOrEmpty(name))
            {
                finalResult.Add(new Dictionary<string, object>()
                {
                    {"Message:","Data input was null"}
                });
                return finalResult;
            }
            //get all category form database
            var getCategory = await _categoryServices.GetCategoriesByName(name);
            if(getCategory == null)
            {
                finalResult.Add(new Dictionary<string,object>()
                {
                    {"Message:","Can't get category data by category name"}
                });
                return finalResult;
            }
            else
            {
                foreach(var category in getCategory)
                {
                    finalResult.Add(new Dictionary<string, object>()
                    {
                        {"Id:",category.Id },
                        {"Name:",category.CategoryName}
                    });
                }
            }
            return finalResult;
        }
        public async Task<Dictionary<string,string>> AddNewCategory(string userId, Category category)
        {
            ///kiểm tra giá trị đầu vào có bị bỏ trống hay không
            ///kiểm tra người dùng có tồn tại trên hệ thống hay không
            ///kiểm tra có tên thương hiện đã tồn tại hay chưa
            ///trả về kết quá của việc tạo thêm dữ liệu
            ///

            //declare a new value return
            var finalResult = new Dictionary<string,string>();
            //is check input data is invalid
            if(string.IsNullOrEmpty(userId)|| category == null )
            {
                finalResult.Add("Message:","Data input was invalid");
                return finalResult;
            }
            //is check user
            var findUser = await _userServices.GetUserByIdAsync(userId);
            if(findUser == null)
            {
                finalResult.Add("Message:","User is not exist");
                return finalResult;
            }
            //todo add category
            var addCategory = await _categoryServices.CreateAsync(category);
            if(addCategory == false)
            {
                finalResult.Add("Message:","There are some issue when trying create a new category");
                return finalResult;
            }
            else
            {
                finalResult.Add("Message:","Creating new category is success");
                return finalResult;
            }
        }
        public async Task<Dictionary<string,string>> UpdateCategory(string userId, string categoryId, Category category)
        {
            ///kiểm tra giá trị đầu vào có bị bỏ trống hay không
            ///kiểm tra người dùng có tồn tại trên hệ thống hay không
            ///kiểm tra có tên thương hiện đã tồn tại hay chưa
            ///trả về kết quá của việc tạo thêm dữ liệu
            ///

            //declare a new value return
            var finalResult = new Dictionary<string,string>();
            //is check input data is invalid
            if(string.IsNullOrEmpty(userId)|| category == null || categoryId == null )
            {
                finalResult.Add("Message:","Data input was invalid");
                return finalResult;
            }
            //is check user
            var findUser = await _userServices.GetUserByIdAsync(userId);
            if(findUser == null)
            {
                finalResult.Add("Message:","User is not exist");
                return finalResult;
            }
            //todo get old category
            var oldCatetory = await _categoryServices.GetByIdAsync(categoryId);
            if(oldCatetory == null)
            {
                finalResult.Add("Message:","Can't get old category");
                return finalResult;
            }
            oldCatetory.CategoryName = category.CategoryName;
            oldCatetory.CategoryDescription = category.CategoryDescription;
            var updateCategory = await _categoryServices.UpdateAsync(categoryId, oldCatetory);
            if(updateCategory == false)
            {
                finalResult.Add("Message:","There are some issue when trying updating a category");
                return finalResult;
            }
            else
            {
                finalResult.Add("Message:","Updating a category is success");
                return finalResult;
            }
        }
        public async Task<Dictionary<string,string>> DeleteCategory(string userId,string categoryId)
        {
            ///kiểm tra giá trị đầu vào có bị bỏ trống hay không
            ///kiểm tra người dùng có tồn tại trên hệ thống hay không
            ///kiểm tra có tên thương hiện đã tồn tại hay chưa
            ///trả về kết quá của việc tạo thêm dữ liệu
            ///

            //declare a new value return
            var finalResult = new Dictionary<string,string>();
            //is check input data is invalid
            if(string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(categoryId))
            {
                finalResult.Add("Message:","Data input was invalid");
                return finalResult;
            }
            //is check user
            var findUser = await _userServices.GetUserByIdAsync(userId);
            if(findUser == null)
            {
                finalResult.Add("Message:","User is not exist");
                return finalResult;
            }
            //todo get old category
            var oldCatetory = await _categoryServices.GetByIdAsync(categoryId);
            if(oldCatetory == null)
            {
                finalResult.Add("Message:","Can't get old category");
                return finalResult;
            }
            var deleteCategory = await _categoryServices.DeleteAsync(categoryId);
            if(deleteCategory == false)
            {
                finalResult.Add("Message:","There are some issue when trying delete a category");
                return finalResult;
            }
            else
            {
                finalResult.Add("Message:","Deleting a category is success");
                return finalResult;
            }
            
        }
    }
}