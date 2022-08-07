using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Events
{
    public class JoinRequest
    {
        public int UserId { get; set; }

        public int EventId { get; set; }
    }
}