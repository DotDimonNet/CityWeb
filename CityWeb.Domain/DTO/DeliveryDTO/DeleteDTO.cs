using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeb.Domain.DTO
{
    public class DeleteProductDTO
    {
        public Guid ProductId { get; set; }
    }

    public class DeleteCompanyDTO
    {
        public Guid CompanyId { get; set; }
    }
}
