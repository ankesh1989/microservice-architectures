

using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMUserprivilege:CommonTable
    {
        [ForeignKey("BCOMAppConfig")]
        public int ConfigId { get; set; }
        public virtual BCOMAppConfig BCOMAppConfig { get; set; }
        [ForeignKey("BCOMUser")]
        public int UserId { get; set; }
        public virtual BCOMUser BCOMUser { get; set; }
        [ForeignKey("BCOMPrivilege")]
        public int privillageId { get; set; }
        public virtual BCOMPrivilege BCOMPrivilege { get; set; }
    }
}
