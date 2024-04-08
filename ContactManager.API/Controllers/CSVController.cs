using ContactManager.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CSVController : Controller
    {
        private readonly IUserService _userService;

        public CSVController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("uploadCSV")]
        public async Task<IActionResult> UploadFile([FromForm]IFormFile file)
        {
            var response = await _userService.UploadUserCSV(file);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCVS()
        {
            var response = await _userService.GetAllUser();
            return Ok(response);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var response = await _userService.DeleteUserAsync(id);
            if(response is null) return BadRequest(response);
            return Ok(response);
        }
    }
}
