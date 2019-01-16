using LibraryData;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryService
{
    public class LibraryAuthorService : IAuthor
    {
        private LibraryContext _context;

        public LibraryAuthorService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            return _context.Authors
                .ToList()
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Text = $"{x.Name}",
                    Value = x.ID.ToString()
                });
        }
    }
}
