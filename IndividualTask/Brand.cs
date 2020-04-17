using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualTask
{
   public class Brand
   {
        public string AutoBrand { get; set; }
        public Brand(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Brand can not be null or empty.");
            }
           AutoBrand = name;
        }
        public override string ToString()
        {
            return AutoBrand;
        }
    }
}
