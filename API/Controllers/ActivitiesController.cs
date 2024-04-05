using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseAPIController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        //two endpoints
        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
                return await _context.Activities.ToListAsync();
        }
        
        [HttpGet("{id}")] //api/activitie/{{GUID}}
        public async Task<ActionResult<Activity>> GetActivity(Guid id)

        {

            return await _context.Activities.FindAsync(id);

        }
    }
}