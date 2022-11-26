using Application;
using Domain.Exceptions;
using Application.Rooms.Dtos;
using Application.Rooms.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("room")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> logger;
        private IRoomManager Manager { get; set; }

        public RoomController(ILogger<RoomController> logger, IRoomManager manager)
        {
            this.logger = logger;
            this.Manager = manager;
        }

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult> Post([FromBody] PostRoomDto room)
        {
            try
            {
                var data = await Manager.Create(room);

                var response = new ResponseDto<RoomDto>()
                    .WithMessage("Quarto criado com sucesso.")
                    .SendData(data);

                return Created("", response);

            }
            catch (DomainException exception)
            {
                var response = new ResponseDto<RoomDto>()
                    .WithMessage("Não foi possível criar um quarto.")
                    .WithErrors(exception.Errors);

                return BadRequest(response);
            }
            catch (Exception exception)
            {
                logger.LogError($"Room not created: ${exception.Message}");

                var response = new ResponseDto<RoomDto>()
                    .WithMessage("Não foi possível criar um quarto.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }

        }
        [HttpPut]
        [Route("put")]
        public async Task<ActionResult> Put([FromBody] PutRoomDto room)
        {
            try
            {
                var data = await Manager.Update(room);

                var response = new ResponseDto<RoomDto>()
                    .WithMessage("Quarto atualizado com sucesso.")
                    .SendData(data);

                return Created("", response);

            }
            catch (DomainException exception)
            {
                var response = new ResponseDto<RoomDto>()
                    .WithMessage("Não foi possível atualizar o quarto.")
                    .WithErrors(exception.Errors);

                return BadRequest(response);
            }
            catch (Exception exception)
            {
                logger.LogError($"Room not created: ${exception.Message}");

                var response = new ResponseDto<RoomDto>()
                    .WithMessage("Não foi possível atualizar o quarto.")
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

                var response = new ResponseDto<RoomDto>()
                    .WithMessage("Quarto deletado com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                logger.LogError($"Room not deleted: ${exception.Message}", exception);

                var response = new ResponseDto<RoomDto>()
                    .WithMessage("Não foi possível deletar o quarto.")
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

                var response = new ResponseDto<IEnumerable<RoomDto>>()
                    .WithMessage("Quartos obtidos com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                logger.LogError($"Room not readed: ${exception.Message}");

                var response = new ResponseDto<RoomDto>()
                    .WithMessage("Não foi possível obter o quarto.")
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

                var response = new ResponseDto<RoomDto>()
                    .WithMessage("Quarto obtido com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                logger.LogError($"Room not readed: ${exception.Message}");

                var response = new ResponseDto<RoomDto>()
                    .WithMessage("Não foi possível obter o quarto.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }
        }
    }
}
