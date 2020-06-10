using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VueAppTsApi.Core.Commands;
using VueAppTsApi.Core.Commands.User;

namespace VueAppTsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region write

        /// <summary>
        /// Create user.
        /// </summary>
        /// <param name="command">CreateUserCommand</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="command">UpdateUserCommand</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Update user settings.
        /// </summary>
        /// <param name="command">UpdateUserSettingsCommand</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPut("settings")]
        public async Task<IActionResult> UpdateSettings([FromBody] UpdateUserSettingsCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        #endregion
    }
}