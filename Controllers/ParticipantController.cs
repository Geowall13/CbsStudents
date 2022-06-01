#nullable disable
using Microsoft.AspNetCore.Mvc;
using CbsStudents.Data;
using CbsStudents.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CbsStudents.Controllers;

[Authorize]
public class ParticipantController : Controller
{
    private CbsStudentsContext _context;

    public ParticipantController(CbsStudentsContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Create(int id)
    {
        var Participant = new Participant{
            EventId = id,
            Event = await _context.Event
                        .Include(x => x.Participants)
                        .FirstAsync(x => x.EventId == id)
        };
        
        return View(Participant);
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("ParticipantId", "Name", "EventId")] Participant participant)
    {
        await _context.Participant.AddAsync(participant);
        await _context.SaveChangesAsync();
        return RedirectToAction("Create");
    }

    public async Task<IActionResult> Delete(int id) {
        var participant = await _context.Participant.FindAsync(id);
        _context.Participant.Remove(participant);
        await _context.SaveChangesAsync();
        return RedirectToAction("Create", new {id = participant.EventId});
    }
}
