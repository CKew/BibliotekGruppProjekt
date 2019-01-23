using System.Linq;

namespace BibliotekGruppProjekt.Models.Member
{
    public class MemberIndexModel
    {
        public IQueryable<LibraryData.Models.Member> Members { get; set; }
    }
}
