using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IAuthor
    {
        IEnumerable<SelectListItem> GetSelectListItems();
    }
}
