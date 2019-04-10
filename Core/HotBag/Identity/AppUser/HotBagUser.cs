using HotBag.EntityBase;
using HotBag.Tanents;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBag.AppUser
{
    public class HotBagUser  : IEFEntityBase<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is Required")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        public string HashedPassword { get; set; }
        public string Phone { get; set; }
        public UserStatus Status { get; set; }

        [ForeignKey("Tanents")]
        public int? TanentIdId { get; set; }
        public virtual Tenant Tanents { get; set; }
    }

    public class HotBagUserStatusLog : IEFEntityBase<long>
    {
        public long Id { get; set; }

        [ForeignKey("HotBagUser")]
        public Guid UserId { get; set; }
        public virtual HotBagUser HotBagUser { get; set; }

        [Required]
        public UserStatus Status { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class HotBagPasswordHistoryLog : IEFEntityBase<long>
    {
        public long Id { get; set; }

        [ForeignKey("HotBagUser")]
        public Guid UserId { get; set; }
        public virtual HotBagUser HotBagUser { get; set; }

        [Required]
        public string HashedPassword { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class HotBagRole : IEFEntityBase<long>
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }  
    }

    public class HotBagUserRoles : IEFEntityBase<long>
    {
        public long Id { get; set; }

        [ForeignKey("HotBagUser")]
        public Guid UserId { get; set; }
        public virtual HotBagUser HotBagUser { get; set; }

        [ForeignKey("HotBagRole")]
        public long RoleIdId { get; set; }
        public virtual HotBagRole HotBagRole { get; set; }
    }

    public class HotBagApplicationModule : IEFEntityBase<long>
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Application Module Name is Required")]
        public string ModuleName { get; set; }
        public DateTime CreatedAt { get; set; }

    }

    public class HotBagApplicationModulePermissionLevel : IEFEntityBase<long>
    {
        public long Id { get; set; }

        [ForeignKey("HotBagApplicationModule")]
        public long HotBagApplicationModuleId { get; set; }
        public virtual HotBagApplicationModule HotBagApplicationModule { get; set; }

        public ApplicationModulePermissionLevel PermissionLevel { get; set; }
        public DateTime CreatedAt { get; set; } 
    }

    public class HotBagRoleApplicationModule : IEFEntityBase<long>
    {
        public long Id { get; set; }

        [ForeignKey("HotBagRole")]
        public long RoleId { get; set; }
        public virtual HotBagRole HotBagRole { get; set; }

        [ForeignKey("HotBagApplicationModule")]
        public long ApplicationModuleId { get; set; }
        public virtual HotBagApplicationModule HotBagApplicationModule { get; set; }

        [ForeignKey("HotBagApplicationModulePermissionLevel")]
        public long? ApplicationModulePermissionLevelId { get; set; } 
        public virtual HotBagApplicationModulePermissionLevel HotBagApplicationModulePermissionLevel { get; set; }
    }

    public enum UserStatus
    {
        Active = 1,
        InActive =2, 
        EmailNotConfirmed =3,
        Suspended =4,
        PasswordExpired =5
    }

    public enum ApplicationModulePermissionLevel
    {
        Read =1,
        Write =2,
        Modify =3,
        Delete =4,
        Print =5
    }
}
