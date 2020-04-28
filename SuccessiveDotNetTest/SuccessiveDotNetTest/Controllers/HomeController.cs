using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuccessiveDotNetTest.Models;

namespace SuccessiveDotNetTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ScheduleInterview()
        {
            List<Candidates> candidates = _context.Candidates.ToList();
            List<string> candidateDetail = new List<string>();
            foreach (Candidates candidate in candidates)
            {
                candidateDetail.Add(candidate.FirstName + " " + candidate.LastName + " <" + candidate.Email + ">");
            }
            ViewBag.candidate = new SelectList(candidateDetail);
            return View();
        }
        [HttpPost]
        public IActionResult ScheduleInterview(Registeration register)
        {
            if (ModelState.IsValid)
            {
                register.CandidateId = _context.Candidates.Where(d => d.Email.Equals(register.Email)).Select(f => f.Id).SingleOrDefault();
                int id = _context.Candidates.Where(d => d.FirstName.Equals(register.FirstName)).Select(f => f.Id).SingleOrDefault();
                if (register.CandidateId == id)
                {
                    if (register.CandidateId == 0)
                    {
                        Candidates candidate = new Candidates();
                        candidate.DOB = register.DOB;
                        candidate.Email = register.Email;
                        candidate.FirstName = register.FirstName;
                        candidate.LastName = register.LastName;
                        candidate.Mobile = register.Mobile;
                        candidate.Experience = register.Experience;
                        _context.Add(candidate);
                        _context.SaveChanges();
                        InterviewSchedules interview = new InterviewSchedules();
                        interview.InterviewerName = register.InterviewerName;
                        interview.Date = register.Date;
                        interview.TimeTO = register.TimeTo;
                        interview.TimeFrom = register.TimeFrom;
                        interview.CandidateId = _context.Candidates.Where(d => d.Email.Equals(register.Email)).Select(f => f.Id).SingleOrDefault();
                        _context.Add(interview);
                        _context.SaveChanges();
                        return RedirectToAction("CandidateDetail");
                    }
                    else
                    {
                        return RedirectToAction("AlreadyExist");
                    }
                }
                else
                {
                    return RedirectToAction("AlreadyExist");
                }
            }
            else
            { return RedirectToAction("CandidateDetail"); }
        }
        [HttpPost]
        public IActionResult UpdateData(Registeration register)
        {
            if (ModelState.IsValid)
            {
                register.CandidateId = _context.Candidates.Where(d => d.Email.Equals(register.Email)).Select(f => f.Id).SingleOrDefault();
                int id = _context.Candidates.Where(d => d.FirstName.Equals(register.FirstName)).Select(f => f.Id).SingleOrDefault();
                if (register.CandidateId == id)
                {
                    if (register.CandidateId == 0)
                    {
                        Candidates candidate = new Candidates();
                        candidate.DOB = register.DOB;
                        candidate.Email = register.Email;
                        candidate.FirstName = register.FirstName;
                        candidate.LastName = register.LastName;
                        candidate.Mobile = register.Mobile;
                        candidate.Experience = register.Experience;
                        _context.Add(candidate);
                        _context.SaveChanges();
                        InterviewSchedules interview = new InterviewSchedules();
                        interview.InterviewerName = register.InterviewerName;
                        interview.Date = register.Date;
                        interview.TimeTO = register.TimeTo;
                        interview.TimeFrom = register.TimeFrom;
                        interview.CandidateId = _context.Candidates.Where(d => d.Email.Equals(register.Email)).Select(f => f.Id).SingleOrDefault();
                        _context.Add(interview);
                        _context.SaveChanges();
                        return RedirectToAction("CandidateDetail");
                    }
                    else
                    {
                        InterviewSchedules interview = new InterviewSchedules();
                        interview.InterviewerName = register.InterviewerName;
                        interview.Date = register.Date;
                        interview.TimeTO = register.TimeTo;
                        interview.TimeFrom = register.TimeFrom;
                        interview.CandidateId = register.CandidateId;
                        _context.Add(interview);
                        _context.SaveChanges();
                        return RedirectToAction("InterviewDetail");
                    }
                }
                else
                {
                    return RedirectToAction("AlreadyExist");
                }
            }
            else
            { return RedirectToAction("ScheduleInterview"); }
        }
        public IActionResult ScheduledInterviewDetails()
        {
           List<Candidates> candidate= _context.Candidates.ToList();
            List<InterviewSchedules> interview = _context.InterviewSchedules.ToList();
            List<ScheduledInterviewDetails> details = new List<ScheduledInterviewDetails>();
            return View();
        }
        public IActionResult AlreadyExist()
        {
            return View();
        }
        public async Task<IActionResult> CandidateDetail()
        {
            return View(await _context.Candidates.ToListAsync());
        }
        public async Task<IActionResult> InterviewDetail()
        {
            return View(await _context.InterviewSchedules.ToListAsync());
        }



    }
}
