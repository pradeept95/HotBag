using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBag.Tanents
{
    public class Tenant 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hostnames { get; set; }
        public string Theme { get; set; }
        public string ConnectionString { get; set; }
    }

    public class TanentConfiguration
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Tanents")]
        public int TanentIdId { get; set; }
        public virtual Tenant Tanents { get; set; }

        public bool IsEmailConfirmationRequired { get; set; } = false; //
        public bool IsUsernameLoginIsEnabled { get; set; }
        public bool IsUseDifferentDatabase { get; set; }

        public bool IsHardPasswordIsRequired { get; set; } = true;
    }
}
