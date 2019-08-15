using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WeatherInfo.Models;
using WeatherInfo.Queries;

namespace WeatherInfo.Handlers
{
    public class GetMeteoDataForStationQueryHandler : IRequestHandler<GetMeteoDataForStationQuery, IEnumerable<ImgwClimateMeteoData>>
    {
        private readonly IMeteoDataUnitOfWork _unitOfWork;

        public GetMeteoDataForStationQueryHandler(IMeteoDataUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<ImgwClimateMeteoData>> Handle(GetMeteoDataForStationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _unitOfWork.ImgwClimateMeteDataRepository.GetMeteoDataForStation(request.StationCode,
                    request.PageSize, request.PageNumber);
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}