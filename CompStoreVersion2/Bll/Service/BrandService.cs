using Dll.Repository;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Service
{
    public class BrandService
    {
        private readonly BrandRepository brandRepository;
        public BrandService(BrandRepository _brandRepository)
        { 
            brandRepository = _brandRepository;
        }
        public void Create(Brand brand)=>brandRepository.Create(brand);
        public void Update(int id, Brand brand)=>brandRepository.Update(id, brand);
        public void Delete(int id)=>brandRepository.Delete(id);
        public Brand GetValue(int id)=>brandRepository.GetValue(id);
        public List<Brand> GetFromCondition(Expression<Func<Brand, bool>> conditionExpression)=>brandRepository.GetFromCondition(conditionExpression).ToList();  

    }
}
