using Azmanov.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azmanov.Data.Interfaces
{
    public interface IContactRepository : IRepository<ContactEntry>
    {
    }
}
