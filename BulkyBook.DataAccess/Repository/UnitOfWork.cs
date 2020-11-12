using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork: IUnitOfWork
    {

        private readonly ApplicationDbContext _db;

        
        public UnitOfWork(ApplicationDbContext _db) 
        {
            this._db = _db;
            Category = new CategoryRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public ICategoryRepository Category { get; private set; }

        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            this._db.Dispose();
        }

        public void Save()
        {
            this._db.SaveChanges();
        }
    }
}
