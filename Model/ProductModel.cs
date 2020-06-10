using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset ExpiredDate { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public int ToxicDegree { get; set; }
        public int StorageId { get; set; }
    }
}
