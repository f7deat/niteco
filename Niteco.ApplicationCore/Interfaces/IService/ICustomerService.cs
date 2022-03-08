using Niteco.ApplicationCore.Entities;
using Niteco.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niteco.ApplicationCore.Interfaces.IService
{
    public interface ICustomerService
    {
        Task<dynamic> GetAllAsync();
    }
}
