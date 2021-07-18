using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class CompanyForCreationDto : CompanyForModificationDto
    {
        public IEnumerable<EmployeeForCreationDto> Employees {get; set;}
    }
}
