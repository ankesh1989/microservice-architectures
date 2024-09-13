

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMFunction:CommonTable
    {
        public string Name {  get; set; }
        public string PageName { get; set; }
        public string PageLink { get; set; }
        public string ParentId { get; set; }
        public string Order {  get; set; }
    }
}
