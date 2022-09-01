using AutoMapper;
using Measure.Services.Interfaces;
using Measure.Services.Models;
using Measure.WebApi.DTO;
using Measure.WebApi.Mapping;
using Messages;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;

namespace Measure.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeasureController : Controller
{
    private readonly IMeasureService _measureService;
    private readonly IMapper _mapper;
    private readonly IMessageSession _messageSession;
    public MeasureController(IMeasureService measureService, IMapper mapper, IMessageSession messageSession)
    {
        _measureService = measureService;
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MeasureMap>();
        });
        _mapper = config.CreateMapper();
        _messageSession = messageSession;
    }
    [HttpPost]
    public async Task<ActionResult> postWeight([FromBody] MeasureDTO measureDTO)
    {
        MeasureModel measure = _mapper.Map<MeasureModel>(measureDTO);
        //get measure id
        string id = "dd";
        MeasureDataAdded measureData = new()
        {
            MeasureId = id,
            CardId = measureDTO.CardId,
            Weight = measureDTO.Weight
        };
        await _messageSession.Publish(measureData);
        Console.WriteLine($"measure added Id = {id}");
        return Ok("measure added succesfully");
    }


}
