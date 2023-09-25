using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Dtos.PostDtos
{
    public class PostSpecialtyDto
    {
        [Required]
        public string Name { get; set; }
    }
}
