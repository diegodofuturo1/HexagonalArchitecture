using Application.Dtos;
using Application.Ports;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> logger;
        private readonly IGuestManage manager;

        public GuestController(ILogger<GuestController> logger, IGuestManage manager)
        {
            this.logger = logger;
            this.manager = manager;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostGuestDto guest)
        {
            try
            {
                var response = await manager.Create(guest);
                logger.Log(LogLevel.Information, $"Guest created with id: ${response.Id}");
                return Created("", new ResponseDto<GuestDto>("Hóspede criado com sucesso.").SendData(response));

            }
            catch (DomainException exception)
            {
                logger.LogError($"Guest not created: \n ${exception.Errors}");
                return BadRequest(new ResponseDto<string>("Não foi possível criar um hóspede.").WithErrors(exception.Errors));
            }
            catch (Exception exception)
            {
                logger.LogError($"Guest not created: \n ${exception.Message}");
                return BadRequest(new ResponseDto<string>("Erro não mapeado.").WithErrors(exception.Message));
            }

        }
    }
}
