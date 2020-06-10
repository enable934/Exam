using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Entity
{
    public class Storage
    {
        public int Id { get; set; }
        public float MaxVolume { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public void AddProduct(Product product)
        {
            if (WithSameToxic(product.ToxicDegree))
            {
                Products.Add(product);
                product.Storage = this;
            }
            throw new NotSupportedException("Product has differ toxic degree and not compatible with this storage");
        }

        private bool WithSameToxic(int ToxicDegree)
        {
            if (Products.Count == 0) return true;
            return Products.LastOrDefault().ToxicDegree == ToxicDegree;
        }
    }
}
