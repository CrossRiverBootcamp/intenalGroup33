using Measure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Services.Models
{
    public class MeasureModel
    {
        public string Id { get; set; }
        public int CardId { get; set; }
        public float Weight { get; set; }
        public DateTime Date { get; set; }
        public MeasureStatus Status { get; set; }
        public string Commments { get; set; }
    }
}
