using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DataChart
{
    public class DataChartService : ApplicationService, IDataChartService
    {
        private readonly IRepository<ChartRandomDataItem, Guid> _chartRandomDataItemRepository;

        public DataChartService(IRepository<ChartRandomDataItem, Guid> chartRandomDataItemRepository)
        {
            _chartRandomDataItemRepository = chartRandomDataItemRepository;
        }

        // TODO: Implement the methods here...
        public async Task<List<ChartRandomDataItemDto>> GetListAsync()
        {
            var items = await _chartRandomDataItemRepository.GetListAsync();
            return items
                .Select(item => new ChartRandomDataItemDto
                {
                    Id = item.Id,
                    Text = item.Text
                }).ToList();
        }

        /*public async Task<ChartRandomDataItemDto> CreateAsync(string text)
        {
            var chartRandomDataItem = await _chartRandomDataItemRepository.InsertAsync(
                new ChartRandomDataItem { Text = text }
            );

            return new ChartRandomDataItemDto
            {
                Id = chartRandomDataItem.Id,
                Text = chartRandomDataItem.Text
            };
        }*/

        /*public async Task DeleteAsync(Guid id)
        {
            await _chartRandomDataItemRepository.DeleteAsync(id);
        }*/

    }
}

