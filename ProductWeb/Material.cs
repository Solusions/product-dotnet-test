using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Data.Entities
{
    public class Material
    {
        [Key]
        public Int32 MaterialId { get; set; }

        public String Name { get; set; }

        public Decimal Cost { get; set; }

        public virtual IEnumerable<Material> ExecutivesList { get; set; }


        [InverseProperty("Material")]
        public ICollection<ProductMaterial> ProductMaterials { get; set; }
    }
}