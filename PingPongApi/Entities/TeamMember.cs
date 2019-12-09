using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PingPongAPI.Entities
{
    public class TeamMember
    {
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        public string TeamId { get; set; }

        [JsonIgnore]
        public virtual Team Team { get; set; }

        public string ShirtSizeId { get; set; }

        public ShirtSize ShirtSize { get; set; }
    }
}
