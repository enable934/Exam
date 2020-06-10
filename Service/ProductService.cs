using AutoMapper;
using Exam.Entity;
using Exam.Model;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Service
{
    public class ProductService
    {
        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<ProductModel> GetProducts()
        {
            return _mapper.Map<Product[], IEnumerable<ProductModel>>(_unitOfWork.ProductRepository.Get().ToArray());
        }
        public ProductModel GetProduct(int productId)
        {
            return _mapper.Map<ProductModel>(_unitOfWork.ProductRepository.Get(filter: m => m.Id == productId).FirstOrDefault());
        }
        public void CreateProduct(ProductModel product)
        {
            Product productEntity = _mapper.Map<Product>(product);
            _unitOfWork.ProductRepository.Insert(productEntity);
            _unitOfWork.Save();
        }
    }
}
