

using FilesManager.Interfaces;
using FilesManager.Migrations;
using FilesManager.Models;
using FilesManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Batches> Batches { get; private set; }
        public IBaseRepository<Documents> Documents { get; private set; }
        public IBaseRepository<Papers> Papers { get; private set; }
       

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            //UserProfile = new BaseRepository<UserProfile>(_context);
            Batches = new BaseRepository<Batches>(_context);
            Documents = new BaseRepository<Documents>(_context);
            Papers = new BaseRepository<Papers>(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}