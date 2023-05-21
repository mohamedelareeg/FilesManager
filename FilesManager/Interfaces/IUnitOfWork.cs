
using FilesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Batches> Batches { get; }
        int Complete();
    }
}