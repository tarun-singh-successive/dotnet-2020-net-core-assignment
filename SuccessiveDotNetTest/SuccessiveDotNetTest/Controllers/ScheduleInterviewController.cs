using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuccessiveDotNetTest.Models;
using DataLayer;

namespace SuccessiveDotNetTest.Controllers
{
    public class ScheduleInterviewController : Controller
    {
        //Using Scoped Dependency Injection using DbManger Class
        private readonly DbManager _context;

        public ScheduleInterviewController(DbManager context)
        {
            _context = context;
        }

        // GET: ScheduleInterview Form
        public ActionResult ScheduleInterview()
        {
            return View();
        }

        // POST: ScheduleInterview/Create for Inserting Records
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleInterviewModal modal)
        {
            //var exist = _context.EmailExists(modal.Email);
            Candidates candidate = new Candidates();
            InterviewSchedules schedule = new InterviewSchedules();
            if (_context.EmailExists(modal.Email)==false)
            {
                    candidate.FirstName = modal.FirstName;
                    candidate.LastName = modal.LastName;
                    candidate.DOB = modal.DOB;
                    candidate.Email = modal.Email;
                    candidate.Mobile = modal.Mobile;
                    candidate.Experience = modal.Experience;
                    _context.Add(candidate);
                    await _context.Save();

                    int id = _context.CandidateList().Where(e => e.Email == modal.Email).Select(i => i.Id).First();
                    schedule.CandidateId = id;
                    schedule.Date = modal.Date;
                    schedule.TimeFrom = modal.TimeFrom;
                    schedule.TimeTo = modal.TimeTo;
                    schedule.InterviewerName = modal.InterviewerName;

                    _context.AddInterviewDetails(schedule);
                    await _context.Save();
                    ViewBag.SuccessMessage = "Interview is Scheduled Successfully";
                    return RedirectToAction(nameof(ScheduleInterview));
                   
                //}
                //catch
                //{
                //    ViewBag.SuccessMessage = "Candidate Email already exist";
                   
                //    return View("ScheduleInterview");
                //}
               
            }
            else {
                    int id = _context.CandidateList().Where(e => e.Email == modal.Email).Select(i => i.Id).First();
                    schedule.CandidateId = id;
                    schedule.Date = modal.Date;
                    schedule.TimeFrom = modal.TimeFrom;
                    schedule.TimeTo = modal.TimeTo;
                    schedule.InterviewerName = modal.InterviewerName;
                    _context.AddInterviewDetails(schedule);
                    await _context.Save();
                    ViewBag.SuccessMessage = "Interview is Scheduled Successfully";
                    return RedirectToAction(nameof(ScheduleInterview));
            }
        }

        //Get List of Data having Last Interview Scheduled Date and Time
        public ActionResult ScheduledInterviewDetails()
        {
            var result = _context.GetInterviewDataWithCandidate().Select(e => new ScheduleInterviewModal
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Experience = e.Experience,
                Date = e.InterviewSchedules.OrderByDescending(d => d.Date).FirstOrDefault().Date,
                TimeFrom = e.InterviewSchedules.OrderByDescending(d => d.TimeFrom).FirstOrDefault().TimeFrom,
                TimeTo = e.InterviewSchedules.OrderByDescending(d => d.TimeTo).FirstOrDefault().TimeTo,
                InterviewerName = e.InterviewSchedules.OrderByDescending(d => d.InterviewerName).FirstOrDefault().InterviewerName
            }).ToList();
            //var candidatList = _context.GetCandidateDataWithInterviewSchedule().OrderByDescending(e=>e.Date).Select(s => new ScheduleInterviewModal
            //{
            //    FirstName = s.candidates.FirstName,
            //    LastName = s.candidates.LastName,
            //    Email = s.candidates.Email,
            //    Experience = s.candidates.Experience,
            //    Date = s.Date,
            //    TimeFrom = s.TimeFrom,
            //    TimeTo = s.TimeTo,
            //    InterviewerName = s.InterviewerName

            //}).ToList();
            return View(result);
           
        }

        
    }
}