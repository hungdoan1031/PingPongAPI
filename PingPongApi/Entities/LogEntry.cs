using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PingPongAPI.Entities
{
    public class LogEntry
    {
        [Key]
        public string Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string Message { get; set; }
        public LogLevel LogLevel { get; set; }
    }

    public enum LogLevel
    {
        Info = 0,
        Warn = 1,
        Error = 2,
    }
}
