using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PingPongAPI.Entities;
using PingPongAPI.Utils;

namespace PingPongAPI.Controllers
{
    [AddHeader("Access-Control-Allow-Origin", "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class LogEntriesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public LogEntriesController(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all log entries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogEntry>>> GetLogEntries()
        {
            return await _context.LogEntries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogEntry>> GetLogEntry(string id)
        {
            var logEntry = await _context.LogEntries.FindAsync(id);

            if (logEntry == null)
            {
                return NotFound();
            }

            return logEntry;
        }

        /// <summary>
        /// Get all Log Entries of a date
        /// </summary>
        /// <param name="date">Entry date</param>
        /// <returns></returns>
        [HttpGet("{date}")]        
        public async Task<ActionResult<IEnumerable<LogEntry>>> GetLogEntry(DateTime date)
        {
            var logEntry = await _context.LogEntries.Where(l => l.EntryDate.Date == date.Date).ToArrayAsync();

            if (logEntry == null)
            {
                return NotFound();
            }

            return logEntry;
        }
       
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Add a log entry
        /// </summary>
        /// <param name="logEntry"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LogEntry>> PostLogEntry(LogEntry logEntry)
        {
            _context.LogEntries.Add(logEntry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LogEntryExists(logEntry.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLogEntry", new { id = logEntry.Id }, logEntry);
        }

        /// <summary>
        /// Delete a log entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<LogEntry>> DeleteLogEntry(string id)
        {
            var logEntry = await _context.LogEntries.FindAsync(id);
            if (logEntry == null)
            {
                return NotFound();
            }

            _context.LogEntries.Remove(logEntry);
            await _context.SaveChangesAsync();

            return logEntry;
        }

        private bool LogEntryExists(string id)
        {
            return _context.LogEntries.Any(e => e.Id == id);
        }
    }
}
