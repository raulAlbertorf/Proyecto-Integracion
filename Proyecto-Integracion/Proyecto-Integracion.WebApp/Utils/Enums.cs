using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Integracion.WebApp.Utils
{
    public static class Enums
    {
        public static List<SelectListItem> EnumToSelectList<T>()
        {
            Type enumType = typeof(T);

            // Can't use type constraints on value types, so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");
            Array enumValArray = Enum.GetValues(enumType);
            List<SelectListItem> lstSelect = new List<SelectListItem>();

            foreach (int val in enumValArray)
            {
                lstSelect.Add(new SelectListItem()
                {
                    Text = Enum.Parse(enumType, val.ToString()).ToString(),
                    Value = val.ToString()
                });
            }

            return lstSelect;
        }
    }
}