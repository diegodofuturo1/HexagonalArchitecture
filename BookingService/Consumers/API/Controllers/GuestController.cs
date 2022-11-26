using Application;
using Domain.Exceptions;
using Application.Guests.Dtos;
using Application.Guests.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("guest")]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> logger;
        private IGuestManager Manager { get; set; }

        public GuestController(ILogger<GuestController> logger, IGuestManager manager)
        {
            this.logger = logger;
            this.Manager = manager;
        }

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult> Post([FromBody] PostGuestDto guest)
        {
            try
            {
                var data = await Manager.Create(guest);

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Hóspede criado com sucesso.")
                    .SendData(data);

                return Created("", response);

            }
            catch (DomainException exception)
            {
                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Não foi possível criar um hóspede.")
                    .WithErrors(exception.Errors);

                return BadRequest(response);
            }
            catch (Exception exception)
            {
                logger.LogError($"Guest not created: ${exception.Message}");

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Não foi possível criar um hóspede.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }

        }
        [HttpPut]
        [Route("put")]
        public async Task<ActionResult> Put([FromBody] PutGuestDto guest)
        {
            try
            {
                var data = await Manager.Update(guest);

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Hóspede atualizado com sucesso.")
                    .SendData(data);

                return Created("", response);

            }
            catch (DomainException exception)
            {
                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Não foi possível atualizar o hóspede.")
                    .WithErrors(exception.Errors);

                return BadRequest(response);
            }
            catch (Exception exception)
            {
                logger.LogError($"Guest not created: ${exception.Message}");

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Não foi possível atualizar o hóspede.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var data = await Manager.Delete(id);

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Hóspede deletado com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                logger.LogError($"Guest not deleted: ${exception.Message}", exception);

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Não foi possível deletar o hóspede.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var data = await Manager.Read();

                var response = new ResponseDto<IEnumerable<GuestDto>>()
                    .WithMessage("Hóspedes obtidos com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                logger.LogError($"Guest not readed: ${exception.Message}");

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Não foi possível obter o hóspede.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }
        }


        [HttpGet]
        [Route("get/id")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var data = await Manager.Read(id);

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Hóspede obtido com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                logger.LogError($"Guest not readed: ${exception.Message}");

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Não foi possível obter o hóspede.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("get/email")]
        public async Task<ActionResult> GetByEmail(string email)
        {
            try
            {
                var data = await Manager.ReadByEmail(email);

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Hóspedes obtidos com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                logger.LogError($"Guest not readed: ${exception.Message}");

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Não foi possível obter o hóspede.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("search/email")]
        public async Task<ActionResult> SearchByEmail(string email)
        {
            try
            {
                var data = await Manager.SearchByEmail(email);

                var response = new ResponseDto<IEnumerable<GuestDto>>()
                    .WithMessage("Hóspedes obtidos com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                logger.LogError($"Guest not readed: ${exception.Message}");

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Não foi possível obter o hóspede.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("search/name")]
        public async Task<ActionResult> SearchByName(string name)
        {
            try
            {
                var data = await Manager.SearchByName(name);

                var response = new ResponseDto<IEnumerable<GuestDto>>()
                    .WithMessage("Hóspedes obtidos com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                logger.LogError($"Guest not readed: ${exception.Message}");

                var response = new ResponseDto<GuestDto>()
                    .WithMessage("Não foi possível obter o hóspede.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }
        }
    }
}
