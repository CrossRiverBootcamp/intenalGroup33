using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Data.Entities
{
    public class MeasureEntity
    {
        [Key]
        public string  Id { get; set; }
        public int CardId { get; set; }
        public float Weight { get; set; }
        public DateTime Date { get; set; }
        public MeasureStatus Status { get; set; }
        public string Commments { get; set; }

    }
}
