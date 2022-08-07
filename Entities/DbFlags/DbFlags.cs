using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities.Common;

namespace WebApi.Entities.DbFlags
{
    public class DbFlags : AuditableBaseEntity
    {
        public string Name { get; set; }
        public bool Value { get; set; }
    }
}