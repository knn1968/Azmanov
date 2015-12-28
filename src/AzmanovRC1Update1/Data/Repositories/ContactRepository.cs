using Azmanov.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azmanov.Entities;
using System.Linq.Expressions;

namespace Azmanov.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private AzmanovContext _context;

        public ContactRepository(AzmanovContext context)
        {
            _context = context;
        }
        public void Add(ContactEntry newEntity)
        {
            _context.ContactEntries.Add(newEntity);
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IQueryable<ContactEntry> Find(Expression<Func<ContactEntry, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            return _context.ContactEntries.Count();
        }

        public void Remove(ContactEntry entity)
        {
            throw new NotImplementedException();
        }
    }
}
