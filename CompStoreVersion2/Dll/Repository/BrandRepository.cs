using Dll.Context;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Repository
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly CompStoreVersion2Context context;
        public BrandRepository(CompStoreVersion2Context _context)
        { 
        context= _context;
        }
        public void Create(Brand entity)
        {
            context.Brands.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = context.Brands.First(b => b.Id == id);
            context.Brands.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Brand> GetFromCondition(Expression<Func<Brand, bool>> condition)=>context.Brands.Where(condition).Include(x=>x.Products).ToList();
 
        public Brand GetValue(int id) => context.Brands.First(x => x.Id == id);

        public void Update(int id, Brand entity)
        {
            var oldEntity = context.Brands.First(b => b.Id == id);
            oldEntity.Name = entity.Name;
            oldEntity.Logo = entity.Logo;
            context.Entry(oldEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
