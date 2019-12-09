using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
    public class TeamMembersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TeamMembersController(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all team members
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembers()
        {
            return await _context.TeamMembers
                //.Include(tm => tm.Team)
                .Include(tm => tm.ShirtSize)
                .ToListAsync();
        }

        /// <summary>
        /// Get a team member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMember>> GetTeamMember(string id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);

            if (teamMember == null)
            {
                return NotFound();
            }

            return teamMember;
        }

        /// <summary>
        /// Update a team member
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teamMember"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMember(string id, TeamMember teamMember)
        {
            if (id != teamMember.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Create a team member
        /// </summary>
        /// <param name="teamMember"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TeamMember>> PostTeamMember(TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeamMemberExists(teamMember.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeamMember", new { id = teamMember.Id }, teamMember);
        }

        /// <summary>
        /// Delete a team member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeamMember>> DeleteTeamMember(string id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();

            return teamMember;
        }

        private bool TeamMemberExists(string id)
        {
            return _context.TeamMembers.Any(e => e.Id == id);
        }
    }
}
