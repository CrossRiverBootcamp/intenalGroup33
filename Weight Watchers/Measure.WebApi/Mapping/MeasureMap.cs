using AutoMapper;
using Measure.Services.Models;
using Measure.WebApi.DTO;

namespace Measure.WebApi.Mapping
{
    public class MeasureMap:Profile
    {
        public MeasureMap()
        {
            CreateMap<MeasureDTO, MeasureModel>();
        }
    }
}
