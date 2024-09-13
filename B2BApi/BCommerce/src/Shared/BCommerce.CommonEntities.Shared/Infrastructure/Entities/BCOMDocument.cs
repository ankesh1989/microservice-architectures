
using System.ComponentModel.DataAnnotations;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMDocument : CommonTable
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Page { get; set; }
        public string Mandatory { get; set; }
        public string FileType {  get; set; }
        public string FileWidth { get; set; }
        public string FileHeight { get; set; }


    }
}
