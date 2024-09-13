
using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMRoleDetails:CommonTable
    {
        [ForeignKey("BCOMRole")]
        public int RoleId {  get; set; }
        public virtual BCOMRole BCOMRole { get; set; }
        [ForeignKey("BCOMFunction")]
        public int FunctionId { get; set; }
        public virtual BCOMFunction BCOMFunction { get; set; }
        public bool ViewAccess { get; set; }
        public bool UpdateAccess  { get; set; }
        public bool SaveAccess { get; set; }
        public bool DeleteAccess { get; set; }
      
    }
}
