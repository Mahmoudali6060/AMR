
using Users.DataAccessLayer;
using Users.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.DataServiceLayer
{
    //public class UserDetailDSL : IStationDSL
    //{
    //    IUserDetailDAL _stationDAL;
    //    IAccountingSharedDSL _accountingSharedDSL;
    //    private readonly IMapper _mapper;
    //    public UserDetailDSL(IUserDetailDAL stationDAL, IAccountingSharedDSL accountingSharedDSL, IMapper mapper)
    //    {
    //        _stationDAL = stationDAL;
    //        _accountingSharedDSL = accountingSharedDSL;
    //        _mapper = mapper;
    //    }

    //    public async Task<long> Save(StationDTO entity)
    //    {
    //        try
    //        {
    //            if (entity.Id > 0)
    //            {
    //                await _accountingSharedDSL.UpdateAccountName(entity.Id, entity.OwnerName);
    //            }
    //            return await _stationDAL.Save(_mapper.Map<Station>(entity));
    //        }
    //        catch (Exception ex)
    //        {
    //            return 0;
    //        }
    //    }


    //    public async Task<long> Delete(long id)
    //    {
    //        return await _stationDAL.Delete(id);
    //    }

    //    public async Task<Response> GetAll(DataSource dataSource)
    //    {
    //        var list = _mapper.Map<IEnumerable<StationDTO>>(await _stationDAL.GetAll()).AsQueryable();
    //        return Helper.ToResult(list, dataSource);
    //    }
    //    public async Task<StationDTO> GetById(long id)
    //    {
    //        return _mapper.Map<StationDTO>(await _stationDAL.GetById(id));
    //    }

    //    public async Task<ResponseEntityList<StationDTO>> GetAllLite()
    //    {
    //        return new ResponseEntityList<StationDTO>()
    //        {
    //            List = _mapper.Map<IEnumerable<StationDTO>>(await _stationDAL.GetAll()).ToList(),
    //        };
    //    }
    //}
}
