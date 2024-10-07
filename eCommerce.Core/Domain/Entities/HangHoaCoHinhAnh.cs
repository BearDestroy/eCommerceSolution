using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Domain.Entities
{
    public class HangHoaCoHinhAnh
    {
        public HangHoa HangHoa { get; set; } = new HangHoa();

        public List<string> ImagePath { get; set; } = new List<string>();
    }
}
