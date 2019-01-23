using System.Linq;

namespace BibliotekGruppProjekt.Models.Author
{
    public class AuthorIndexModel
    {
        public IQueryable<LibraryData.Models.Author> Authors { get; set; }
    }
}
