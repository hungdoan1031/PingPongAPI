using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PingPongAPI.Entities
{
    public class ShirtSize
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        [JsonIgnore]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
