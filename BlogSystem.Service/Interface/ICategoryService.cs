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
    }
}
