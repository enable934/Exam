using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset ExpiredDate { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public int ToxicDegree { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
