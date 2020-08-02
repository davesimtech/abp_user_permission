using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace TestProject.Dtos
{
    public class UserDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
