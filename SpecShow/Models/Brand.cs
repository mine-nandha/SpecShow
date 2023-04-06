using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace SpecShow.Models
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        public string Name { get; set; }
        public List<Mobile> Mobiles { get; set; }
        [DataType(DataType.Url)]
        public string LogoURL { get; set; }
    }
}
