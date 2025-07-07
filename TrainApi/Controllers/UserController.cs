using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainApi.Models.DTOs;
using TrainApi.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainApi.Controllers
{
    [ApiController]
    [Authorize(Roles = "User,Admin")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ITrainService _trainService;
        private readonly IBookingService _bookingService;

        public UserController(ITrainService trainService, IBookingService bookingService)
        {
            _trainService = trainService;
            _bookingService = bookingService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchTrains([FromBody] TrainSearchRequest request)
        {
            var trains = await _trainService.SearchTrainsAsync(request);
            return Ok(trains);
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookSeat([FromBody] BookingRequest request)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var booking = await _bookingService.BookSeatAsync(userId, request);
            return Ok(booking);
        }

        [HttpGet("bookings")]
        public async Task<IActionResult> GetBookings()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var bookings = await _bookingService.GetUserBookingsAsync(userId);
            return Ok(bookings);
        }
    }
}

