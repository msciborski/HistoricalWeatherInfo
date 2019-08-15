using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherInfo.Models;
using WeatherInfo.Queries;

namespace WeatherInfo.Handlers
{
    public class GetMeteoDataBetweenYearsQueryHandler : IRequestHandler<GetMeteoDataBetweenYearsQuery, IEnumerable<ImgwClimateMeteoData>>
    {
        private readonly IMeteoDataUnitOfWork _unitOfWork;

        public GetMeteoDataBetweenYearsQueryHandler(IMeteoDataUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ImgwClimateMeteoData>> Handle(GetMeteoDataBetweenYearsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _unitOfWork.ImgwClimateMeteDataRepository.GetMeteoDataBetweenYears(request.StartYear, request.EndYear, request.PageSize, request.PageNumber);

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
