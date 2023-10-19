using System;
using Volo.Abp.Domain.Entities;

namespace DataChart
{
    public class ChartRandomDataItem : BasicAggregateRoot<Guid>
    {
        public string Text { get; set; }
    }
}

