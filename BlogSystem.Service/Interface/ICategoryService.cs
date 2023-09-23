using BlogSystem.Model.ResponseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Service.Interface
{
    public interface ICategoryService
    {
        ResponseVM<List<ResponseCategoryVM>> GetCategorys();

        ResponseVM<string> AddCategory(int id, int subId, string name);

        ResponseVM<string> UpdateCategory(int id, int subId, string name);

        ResponseVM<string> DeleteCategory(int id, int subId);
    }
}
