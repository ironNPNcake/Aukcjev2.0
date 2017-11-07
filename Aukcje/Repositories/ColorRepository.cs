using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public class ColorRepository
    {
        public void AddColor(FiltersTable newColor)
        {
            using (var ctx = new bazaEntities())
            {
                ctx.FiltersTables.Add(newColor);
                ctx.SaveChanges();
            }
        }
        public IEnumerable<FiltersTable> GetColors()
        {
            List<FiltersTable> list;
            using (var ctx = new bazaEntities())
            {
                list = ctx.FiltersTables.ToList<FiltersTable>();
            }
            return list;
        }
    }
}