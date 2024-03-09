using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMeetingService
    {
        IDataResult<List<Meeting>> GetAll();
        IDataResult<Meeting> GetById(int id);
        IDataResult<List<Meeting>> GetAllByCategoryId(int id);
        //IDataResult<List<Meeting>> GetAllByPriceRange(int minPrice, int maxPrice);
        //IDataResult<List<MeetingDetailsDto>> GetMeetingDetails();
        //IDataResult<List<WeddingPlaceDetailDto>> GetDetailsByFilter(FilterOptions filter);
        //IDataResult<MeetingDetailsDto> GetWeddingPlaceDetail(int id);
        IResult Add(Meeting meeting);
        IResult Update(Meeting meeting);
        IResult Delete(Meeting meeting);
    }
}
