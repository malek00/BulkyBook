using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext _db):base(_db)
        {
            this._db = _db;
        }

        public void Update(Category item)
        {
            var obj = _db.Categories.FirstOrDefault(e => e.Id == item.Id);
            if(obj!=null)
            {
                obj.Name = item.Name;

                _db.SaveChanges();
            }
          
        }
    }
}
