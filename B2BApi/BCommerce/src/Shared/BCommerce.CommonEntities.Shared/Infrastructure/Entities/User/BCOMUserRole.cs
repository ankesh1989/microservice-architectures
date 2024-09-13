using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMUserRole:CommonTable
    {
        [ForeignKey("BCOMRole")]
        public int RoleId { get; set; }
        public virtual BCOMRole BCOMRole { get; set; }
        [ForeignKey("BCOMUser")]
        public int UserId {  get; set; }
        public virtual BCOMUser BCOMUser { get; set; }
    }
}
