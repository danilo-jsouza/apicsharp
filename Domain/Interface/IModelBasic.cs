using Domain.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Interface
{
    public interface IModelBasic
    {
        [JsonConverter(typeof(StringEnumConverter))]
        UserEnum UserType { get; set; }
        bool Active { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        [EmailAddress]
        [Required]
        string Email { get; set; }
        bool IsVirtualDeleted { get; set; }
    }

    public interface IModel : IModelBasic
    {
        int Id { get; set; }
        Guid EntityId { get; set; }
    }
}
