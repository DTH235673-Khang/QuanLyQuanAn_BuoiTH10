using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLyQuanAn.Data
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string UserId { get; set; } 
        public string TableName { get; set; } 
        public string Action { get; set; } 
        public string OldValues { get; set; } 
        public string NewValues { get; set; } 
        public DateTime AffectedAt { get; set; } = DateTime.Now;
    }
    public class AuditEntry
    {
        public string UserId { get; set; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public Dictionary<string, object> OldValues { get; } = new();
        public Dictionary<string, object> NewValues { get; } = new();

        public AuditLog ToAuditLog()
        {
            return new AuditLog
            {
                UserId = UserId,
                TableName = TableName,
                Action = Action,
                OldValues = OldValues.Count == 0 ? "": JsonSerializer.Serialize(OldValues),
                NewValues = NewValues.Count == 0 ? "" : JsonSerializer.Serialize(NewValues),
                AffectedAt = DateTime.Now
            };
        }
    }
}
