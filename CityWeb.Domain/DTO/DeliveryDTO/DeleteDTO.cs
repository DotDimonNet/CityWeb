using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class DeleteProductDTO
    {
        public string Title { get; set; }
        public string ProductName { get; set; }
    }

    public class DeleteCompanyDTO
    {
        public string Title { get; set; }
    }
}
