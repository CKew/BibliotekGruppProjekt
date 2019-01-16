﻿using LibraryData;
using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryService
{
    public class LibraryMemberService : IMember
    {
        private LibraryContext _context;

        public LibraryMemberService(LibraryContext context){
            _context = context;
        }

        // Gets a specific member
        public Member GetMember(int id){
            return _context.Members.FirstOrDefault(m => m.ID == id);
        }

        // Gets all the members
        public IEnumerable<Member> GetAll(){
            return _context.Members;
                //.Include(member => member.PersonNr)
                //.Include(member => member.ID);
        }

        // Adds a new member
        public void Add(Member newMember){
            _context.Add(newMember);
            _context.SaveChanges();
        }
    }
}
