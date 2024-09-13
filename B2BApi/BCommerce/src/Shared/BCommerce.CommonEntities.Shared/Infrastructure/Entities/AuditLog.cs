using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    [Table("CommonAuditLogs", Schema = "dbo")]
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("userid")]
        public string UserId { get; set; } = string.Empty;
        [Column("audittype")]
        public string AuditType { get; set; } = string.Empty;
        [Column("tablename")]
        public string TableName { get; set; } = string.Empty;
        [Column("time_stamp")]
        public DateTime Time_Stamp { get; set; }
        [Column("oldvalues")]
        public string OldValues { get; set; } = string.Empty;
        [Column("newvalues")]
        public string NewValues { get; set; } = string.Empty;
        [Column("affectedcolumns")]
        public string AffectedColumns { get; set; } = string.Empty;
        [Column("primarykey")]
        public string PrimaryKey { get; set; } = string.Empty;
    }
}
