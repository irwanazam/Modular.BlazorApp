﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Audits.Domains
{
    public class AuditEvent
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public string Entity { get; set; }
        public string EntityId { get; set; }
        public string EntityName { get; set; }
        public string EntityValue { get; set; }
        public string EntityPreviousValue { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
    }
}
