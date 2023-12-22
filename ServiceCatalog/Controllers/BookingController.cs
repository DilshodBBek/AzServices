using Microsoft.AspNetCore.Mvc;
using ServiceCatalog.Domain.DTO.Booking;
using ServiceCatalog.Domain.Entity.Playstation;

namespace ServiceCatalog.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookingController:ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory= httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> ChekingBookingStatusForPlaystation(int bookingId,int langId)
        {
            // Use the _httpClientFactory to create an instance of HttpClient
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                // Use the httpClient to make HTTP requests
                var response = await httpClient.GetAsync("http://10.10.3.158:5091/api/BookingStatus/GetAll");

                if (response.IsSuccessStatusCode)
                {
                    // Process the successful response
                    string content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                else
                {
                    // Handle the error response
                    return StatusCode((int)response.StatusCode, "Failed to retrieve data");
                }
            }
        }
        public async Task CreateBookingForPlaystation()
        {

        }
    }
}
