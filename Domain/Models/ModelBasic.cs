using Domain.Enum;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public abstract class ModelBasic : IModel
    {
        public int Id { get; set; }
        public Guid EntityId { get; set; }
        public UserEnum UserType { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [NotMapped]
        public bool IsVirtualDeleted { get; set; }
    }
}
