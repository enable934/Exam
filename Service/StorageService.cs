using AutoMapper;
using Exam.Entity;
using Exam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Exam.Service
{
    public class StorageService
    {
        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StorageService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<StorageModel> GetStorages()
        {
            return _mapper.Map<Storage[], IEnumerable<StorageModel>>(_unitOfWork.StorageRepository.Get().ToArray());

        }
        public StorageModel GetStorage(int storageId)
        {
            return _mapper.Map<StorageModel>(_unitOfWork.StorageRepository.Get(filter: m => m.Id == storageId).FirstOrDefault());
        }
        public void CreateStorage(StorageModel storage)
        {
            Storage storageEntity = _mapper.Map<Storage>(storage);
            _unitOfWork.StorageRepository.Insert(storageEntity);
            _unitOfWork.Save();
        }
    }
}
