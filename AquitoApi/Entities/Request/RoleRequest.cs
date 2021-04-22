using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.Entities.Request
{
    public class RoleRequest
    {
        public string ConcurrencyStamp { get; set; }

        [Required(ErrorMessage = "Role es obligatorio.")]
        [MinLength(3, ErrorMessage = " el Role debe tener mas de 3 digitos")]
        public string Role { get; set; }
    }
}
