using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IDapperRepository<Entity> where Entity : class
    {
        Entity Query(string query, DynamicParameters parameters);
        IEnumerable<Entity> Get(string query, DynamicParameters parameters);
        int Execute(string query, DynamicParameters parameters);
    }
}
