using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Subscriber.Services.Interfaces;
using Subscriber.Services.Models;
using Subscriber.WebApi.DTO;
using Subscriber.WebApi.Mapping;

namespace Subscriber.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : Controller
    {
        ISubscriberService _subscriberService;
        IMapper _mapper;
        public SubscriberController(ISubscriberService subsriberService)
        {
            _subscriberService = subsriberService;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SubscriberMap>();
            });
            _mapper = config.CreateMapper();
        }
        [HttpPost("subscriber")]
        public async Task<ActionResult<bool>> PostSubscriber([FromBody] SubscriberDTO subscriberDTO)
        {
            if (!ModelState.IsValid)
            {
                //return StatusCode(400, ModelState);
                return BadRequest();
            }
            SubscriberModel subscriber = _mapper.Map<SubscriberModel>(subscriberDTO);

            return await _subscriberService.AddSubscriberAndCard(subscriberDTO.Height, subscriber); ;


        }

        [HttpPost("Login")]
        public async Task<ActionResult<int>> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                //return StatusCode(400, ModelState);
                return BadRequest();
            }
            try
            {
                var cardId = await _subscriberService.Login(loginDTO.Email, loginDTO.Password);
                if (cardId == null)
                {
                    return Unauthorized();
                }
                return cardId;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
