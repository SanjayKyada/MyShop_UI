using Core.Model;
using System.Collections.Generic;

namespace Core.ViewModel
{
    public class ProductCategoryModel
    {
        public Product ProductObj { get; set; }
        public List<Category> CategoryListObj { get; set; }
    }
}
