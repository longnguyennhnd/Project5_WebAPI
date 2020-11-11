using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EClassCDCDWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EClassCDCDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfile : ControllerBase
    {
		private UserManager<ApplicationUser> _userManager;
		private readonly CoreDbContext _context;
		public UserProfile(UserManager<ApplicationUser> userManager, CoreDbContext context)
		{
			_userManager = userManager;
			_context = context;
		}
		[HttpGet]
		//("{EmployeeId}")
		[Authorize]
		public async Task<IActionResult> GetUserProfile()
		//public async Task<IActionResult> GetUserProfile(string EmployeeId)
		{
			string StudentId = User.Claims.First(c => c.Type == "StudenId").Value;
			//var user = await _userManager.FindByIdAsync(employeeId);
			var user = await _context.Students.FindAsync(StudentId);
			//var user = await _userManager.FindByIdAsync(EmployeeID);
			//user.setRequestProperty("Content-Type", "application/json");
			return Ok(new
			{
				studentId = user.StudentId,
				password = user.Password,
				fullName = user.FullName,
				gender = user.Gender.ToString(),
				birthday = user.Birthday,
				address = user.Address,
				email = user.Email,
				phoneNumber = user.PhoneNumber,
				photo = user.Photo,
				classId = user.ClassId,
			});
		}
	}
}
