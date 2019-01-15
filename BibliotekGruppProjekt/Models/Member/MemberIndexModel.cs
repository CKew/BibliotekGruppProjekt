using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Models.Member
{
    public class MemberIndexModel
    {
        public IEnumerable<LibraryData.Models.Member> Members { get; set; }
    }
}
