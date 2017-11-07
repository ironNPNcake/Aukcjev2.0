using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public class CategoryRepository
    {
        public IEnumerable<CategoriesTable> GetCategoriesNames()
        {
            List<CategoriesTable> list;
            using (var ctx = new bazaEntities())
            {
                list = ctx.CategoriesTables.ToList();
            }
            return list;
        }
        public string GetCategoryNameById(int CategoryInt)
        {
            string CategoryRes;
            using (var ctx = new bazaEntities())
            {
                CategoryRes = ctx.CategoriesTables.Where(p => p.ID == CategoryInt).Select(p => p.CategoryResourceName).SingleOrDefault();
            }
            return CategoryRes;
        }
    }
}