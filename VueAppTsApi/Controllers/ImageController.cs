using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VueAppTsApi.Core.Commands;
using VueAppTsApi.Core.Queries;

namespace VueAppTsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public ImageController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region write

        /// <summary>
        /// Save/unsaved image.
        /// </summary>
        /// <param name="command">SaveImageCommand</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPut]
        public async Task<IActionResult> SaveImage([FromBody] SaveImageCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        #endregion

        #region read

        /// <summary>
        /// Get all images.
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(int userId)
        {
            var result = await _mediator.Send(new GetAllImagesQuery(userId));

            return Ok(result);
        }

        #endregion
    }
}