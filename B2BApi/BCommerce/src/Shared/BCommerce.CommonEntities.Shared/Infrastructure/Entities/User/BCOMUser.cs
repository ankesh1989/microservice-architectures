
using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMUser:CommonTable
    {
        public string Title {  get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool Login { get; set; }
        public string Password { get; set; }
        public int AccessFieldId { get; set; }
        [ForeignKey("BCOMAgentProfile")]
        public int AgentId { get; set; }
        public virtual BCOMAgentProfile BCOMAgentProfile { get; set; }

        [ForeignKey("BCOMSubAgentProfile")]
        public int SubAgentId { get; set; }
        public virtual BCOMAgentProfile BCOMSubAgentProfile { get; set; }
        [ForeignKey("BCOMLocation")]
        public int locationId { get; set; }
        public virtual BCOMLocation BCOMLocation { get; set; }

        public int ChannelId { get; set; }
        public string IntegrationCode { get; set; }
        public int AccessLocationId { get; set; }
        public string Type { get; set; }

        public bool TwoFactorAuthenticationstatus { get; set; }
        public string TwoFactorAuthenticationcomm { get; set; }

        public DateTime LastLogin { get; set; }











        

    }
}
