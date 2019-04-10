﻿using HotBag.AppUserDto;
using HotBag.AutoMaper.Attributes;
using HotBag.EntityBase;
using HotBag.Tanents;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotBag.AppUser
{
    [AutoMap(typeof(HotBagUserDto))]
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
}
