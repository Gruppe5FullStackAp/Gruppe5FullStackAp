using System;
using System.Collections.Generic;

namespace Eksamen2025Gruppe5.Models
{
    public class DateInfo
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<IndexInfo> Indexes { get; set; }
        public int PollenResponseId { get; set; }
        public PollenResponse PollenResponse { get; set; }
    }
}
