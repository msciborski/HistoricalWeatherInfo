using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherInfo.Models;

namespace WeatherInfo.Queries
{
    public class GetMeteoDataBetweenYearsQuery : IRequest<IEnumerable<ImgwClimateMeteoData>>
    {
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int PageSize { get; set; } = 100;
        public int PageNumber { get; set; } = 0;
    }
}
