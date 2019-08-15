using System.Collections.Generic;
using MediatR;
using WeatherInfo.Models;

namespace WeatherInfo.Queries
{
    public class GetMeteoDataForStationQuery : IRequest<IEnumerable<ImgwClimateMeteoData>>
    {
        public string StationCode { get; set; }
        public int PageSize { get; set; } = 100;
        public int PageNumber { get; set; } = 0;
    }
}