using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schedule;
using Schedule.Entities;
using SuccessiveDotNetTests.Models;

namespace SuccessiveDotNetTests.Controllers
{
    public class InterviewSchedulesController : Controller
    {
        private readonly DataContext _context;

        public InterviewSchedulesController(DataContext context)
        {
            _context = context;
        }

        // GET: InterviewSchedules
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.InterviewSchedule.Include(i => i.candidates);
            return View(await dataContext.ToListAsync());
        }

        // GET: InterviewSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interviewSchedule = await _context.InterviewSchedule
                .Include(i => i.candidates)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interviewSchedule == null)
            {
                return NotFound();
            }

            return View(interviewSchedule);
        }

        // GET: InterviewSchedules/Create
        public IActionResult Create()
        {
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Id");
            return View();
        }

        // POST: InterviewSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CandidateId,Date,TimeFrom,TimeTo,InterViewerName")] InterviewSchedule interviewSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interviewSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Id", interviewSchedule.CandidateId);
            return View(interviewSchedule);
        }

        // GET: InterviewSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interviewSchedule = await _context.InterviewSchedule.FindAsync(id);
            if (interviewSchedule == null)
            {
                return NotFound();
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Id", interviewSchedule.CandidateId);
            return View(interviewSchedule);
        }

        // POST: InterviewSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CandidateId,Date,TimeFrom,TimeTo,InterViewerName")] InterviewSchedule interviewSchedule)
        {
            if (id != interviewSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interviewSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterviewScheduleExists(interviewSchedule.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Id", interviewSchedule.CandidateId);
            return View(interviewSchedule);
        }

        // GET: InterviewSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interviewSchedule = await _context.InterviewSchedule
                .Include(i => i.candidates)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interviewSchedule == null)
            {
                return NotFound();
            }

            return View(interviewSchedule);
        }

        // POST: InterviewSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interviewSchedule = await _context.InterviewSchedule.FindAsync(id);
            _context.InterviewSchedule.Remove(interviewSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterviewScheduleExists(int id)
        {
            return _context.InterviewSchedule.Any(e => e.Id == id);
        }

        public IActionResult ScheduleInterview()                 //getting data from user
        {

            var firstName = _context.Candidates.Select(i => i.FirstName);

            ViewData["candidateId"] = new SelectList(_context.Candidates, "Id", "Id");
            ViewData["FirstName"] = new SelectList(_context.Candidates, "FirstName", "FirstName");
            ViewData["LastName"] = new SelectList(_context.Candidates, "LastName", "LastName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ScheduleInterview(ScheduleInterviewModel scheduleInterviewModel)   //distributing data to candidates and interviewSchedule objects
        {
            Candidate newEntry = new Candidate();
            InterviewSchedule interviewSchedule = new InterviewSchedule();

            interviewSchedule.Date = scheduleInterviewModel.Date;
            interviewSchedule.TimeFrom = scheduleInterviewModel.TimeFrom;
            interviewSchedule.TimeTo = scheduleInterviewModel.TimeTo;
            interviewSchedule.InterViewerName = scheduleInterviewModel.InterViewerName;
            interviewSchedule.CandidateId = scheduleInterviewModel.CandidateId;
            newEntry.FirstName = scheduleInterviewModel.FirstName;
            newEntry.LastName = scheduleInterviewModel.LastName;
            newEntry.Email = scheduleInterviewModel.Email;
            newEntry.DateOfBirth = scheduleInterviewModel.DateOfBirth;
            newEntry.Mobile = scheduleInterviewModel.Mobile;
            newEntry.Experience = scheduleInterviewModel.Experience;

            if (ModelState.IsValid)                        //saving data 
            {
                _context.Add(interviewSchedule);
                await _context.SaveChangesAsync();
                _context.Add(newEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }


            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Id", interviewSchedule.CandidateId);
            return View(interviewSchedule);
        }

        public IActionResult GetAll()      // function gor getting firstname lastname and email for candidates droupdown 
        {
            var value = _context.Candidates.Select(values => new
            {

                name = values.FirstName,
                last = values.LastName,
                email = values.Email

            });

            return new JsonResult(value);

        }

        [HttpGet]
        public async Task<IActionResult> ScheduledInterviewDetails()   
        {
            var dataContext = _context.InterviewSchedule.Include(interview => interview.candidates).GroupBy(interview=>interview.CandidateId);
            return  View(await dataContext.ToListAsync());
        }

        public IActionResult GetDetail(string name)   //getting email from  string consist of firstname, lastname ,email
        {
            string email = null;
           int length = name.Length;
            for (int stringValue = 0; stringValue < length; stringValue++)
            {
                if (name[stringValue] == '(')
                {
                   
                    int getEmail = stringValue + 1;
                    while(name[getEmail]!=')')
                    {
                        email = email + name[getEmail];
                        getEmail++;
                    }
                }
            }

            var value = _context.Candidates.Where(e=>e.Email==email).Select(values => new
            {

                name = values.FirstName,
                last = values.LastName,
                email = values.Email,
                birth=values.DateOfBirth,
                mobile=values.Mobile,
                experience=values.Experience

            });

            return new JsonResult(value);

        }

    }

}
