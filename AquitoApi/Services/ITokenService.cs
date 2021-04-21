using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AquitoApi.Entities;

namespace AquitoApi.Services
{
    public interface ITokenService
    {
        public Task<(string, IEnumerable<string>)> GenerateJwtToken(Useraquito user);

    }
}