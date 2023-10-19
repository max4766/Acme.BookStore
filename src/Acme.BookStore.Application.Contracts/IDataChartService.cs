using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DataChart
{
    public interface IDataChartService : IApplicationService
    {
        Task<List<ChartRandomDataItemDto>> GetListAsync();
        /*Task<ChartRandomDataItemDto> CreateAsync(string text);*/
        /*Task DeleteAsync(Guid id);*/
    }
}

