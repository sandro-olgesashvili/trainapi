using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainApi.Models;
using TrainApi.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainApi.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ITrainService _trainService;
        private readonly IBookingService _bookingService;

        public AdminController(ITrainService trainService, IBookingService bookingService)
        {
            _trainService = trainService;
            _bookingService = bookingService;
        }

        [HttpPost("trains")]
        public async Task<IActionResult> AddTrain([FromBody] Train train)
        {
            await _trainService.AddTrainAsync(train);
            return Ok(new { message = "Train added successfully" });
        }

        [HttpGet("bookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }
    }
}

