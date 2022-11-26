using Application;
using Domain.Exceptions;
using Application.Bookings.Dtos;
using Application.Bookings.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("booking")]
    public class BookingController : ControllerBase
    {
        private IBookingManager Manager { get; set; }
        private ILogger<BookingController> Logger { get; set; }

        public BookingController(ILogger<BookingController> logger, IBookingManager manager)
        {
            this.Logger = logger;
            this.Manager = manager;
        }

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult> Post([FromBody] PostBookingDto booking)
        {
            try
            {
                var data = await Manager.Create(booking);

                var response = new ResponseDto<BookingDto>()
                    .WithMessage("Aluguel criado com sucesso.")
                    .SendData(data);

                return Created("", response);

            }
            catch (DomainException exception)
            {
                var response = new ResponseDto<BookingDto>()
                    .WithMessage("Não foi possível criar um aluguel.")
                    .WithErrors(exception.Errors);

                return BadRequest(response);
            }
            catch (Exception exception)
            {
                Logger.LogError($"Booking not created: ${exception.Message}");

                var response = new ResponseDto<BookingDto>()
                    .WithMessage("Não foi possível criar um aluguel.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }

        }
        [HttpPut]
        [Route("put")]
        public async Task<ActionResult> Put([FromBody] PutBookingDto booking)
        {
            try
            {
                var data = await Manager.Update(booking);

                var response = new ResponseDto<BookingDto>()
                    .WithMessage("Aluguel atualizado com sucesso.")
                    .SendData(data);

                return Created("", response);

            }
            catch (DomainException exception)
            {
                var response = new ResponseDto<BookingDto>()
                    .WithMessage("Não foi possível atualizar o aluguel.")
                    .WithErrors(exception.Errors);

                return BadRequest(response);
            }
            catch (Exception exception)
            {
                Logger.LogError($"Booking not created: ${exception.Message}");

                var response = new ResponseDto<BookingDto>()
                    .WithMessage("Não foi possível atualizar o aluguel.")
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

                var response = new ResponseDto<BookingDto>()
                    .WithMessage("Aluguel deletado com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                Logger.LogError($"Booking not deleted: ${exception.Message}", exception);

                var response = new ResponseDto<BookingDto>()
                    .WithMessage("Não foi possível deletar o aluguel.")
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

                var response = new ResponseDto<IEnumerable<BookingDto>>()
                    .WithMessage("Aluguels obtidos com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                Logger.LogError($"Booking not readed: {exception.Message}");

                var response = new ResponseDto<BookingDto>()
                    .WithMessage("Não foi possível obter o aluguel.")
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

                var response = new ResponseDto<BookingDto>()
                    .WithMessage("Aluguel obtido com sucesso.")
                    .SendData(data);

                return Ok(response);

            }
            catch (Exception exception)
            {
                Logger.LogError($"Booking not readed: ${exception.Message}");

                var response = new ResponseDto<BookingDto>()
                    .WithMessage("Não foi possível obter o aluguel.")
                    .WithErrors(exception.Message);

                return BadRequest(response);
            }
        }
    }
}
