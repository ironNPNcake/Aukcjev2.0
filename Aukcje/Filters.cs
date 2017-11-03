﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public class Filters
    {
        public static List<CategoriesTable>ReturnCategoriesList()
        {
            List<CategoriesTable> list;
            using (var ctx = new bazaEntities())
            {
                list = ctx.CategoriesTables.ToList<CategoriesTable>();
            }
            List<string> tempList = list.Select(p => p.CategoryResourceName).ToList();
            RemoveWhiteSpacesAndReplaceToGlobalResources(ref tempList);
            for (int i=0; i < list.Count; i++)
            {
                list[i].CategoryResourceName = tempList[i];
            }
            return list;
        }
        public static List<FiltersTable> ReturnFiltersList()
        {
            List<FiltersTable> list;
            using (var ctx = new bazaEntities())
            {
                list = ctx.FiltersTables.ToList<FiltersTable>();
            }

            List<string> tempList = list.Select(p => p.FilterResourceName).ToList();
            RemoveWhiteSpacesAndReplaceToGlobalResources(ref tempList);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FilterResourceName = tempList[i];
            }
            return list;
        }
        private static void RemoveWhiteSpacesAndReplaceToGlobalResources(ref List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].Replace(" ", "");
                object res = HttpContext.GetGlobalResourceObject("Resource", list[i]);
                if(res!=null)
                {
                    list[i] = Convert.ToString(res);
                }
            }
        }
        public static string TryFindCategoryResource(string CategoryName)
        {
            Models.Categories catEnum;
            Enum.TryParse(CategoryName, out catEnum);
            return TryFindCategoryResource((int)catEnum);
        }
        public static string TryFindCategoryResource(int CategoryInt)
        {
            string CategoryRes;
            using (var ctx = new bazaEntities())
            {
                CategoryRes = ctx.CategoriesTables.Where(p => p.ID == CategoryInt).Select(p => p.CategoryResourceName).SingleOrDefault();
            }
            object tempCategoryRes = HttpContext.GetGlobalResourceObject("Resource", ((Models.Categories)CategoryInt).ToString());
            if (tempCategoryRes != null)
            {
                CategoryRes = tempCategoryRes.ToString();
            }
            return CategoryRes;

        }

    }
}