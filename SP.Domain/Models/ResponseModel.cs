using SP.Domain.Entities.LocationEntities;
using SP.Domain.Models.RegionDTO;
using System.Net;

namespace SP.Domain.Models;

public class ResponseModel<T>
{
    private DistrictEntity _districtEntity;
    private RegionCreateDTO _regionCreateDTO;
    public ResponseModel(RegionCreateDTO regionCreateDTO)
    {
        _regionCreateDTO = regionCreateDTO;
    }

    public ResponseModel(T result, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        Result = result;
        StatusCode = statusCode;
    }
    public ResponseModel(string error, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        Error = error;
        StatusCode = statusCode;
    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public string Error { get; set; }
    public T Result { get; set; }
}
