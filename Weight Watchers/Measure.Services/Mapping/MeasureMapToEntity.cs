using AutoMapper;
using Measure.Data.Entities;
using Measure.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Services.Mapping
{
    public class MeasureMapToEntity:Profile
    {
        public MeasureMapToEntity()
        {
            CreateMap<MeasureModel, MeasureEntity>();
        }
    }
}
