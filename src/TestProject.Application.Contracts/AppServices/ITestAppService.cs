using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TestProject.AppServices
{
    public interface ITestAppService : ICrudAppService<UserDto, Guid>
    {
    }
}
