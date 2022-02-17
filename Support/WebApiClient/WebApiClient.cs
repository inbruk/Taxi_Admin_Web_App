namespace Rapport.Support.WebApiClient
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using Rapport.AuxiliaryTools.AsyncHelper;
    using Rapport.AuxiliaryTools.WabApiTools;
    using Rapport.BusinessTools.AuthenticationEngine;
    using Rapport.BusinessTools.WebApiRequestHelpers;
    using Rapport.BusinessTools.DirectoryEngine;

    using Rapport.Support.WebApiClient.DTO;
    using Rapport.Support.WebApiClient.DirectoryValues;

    public class WebApiClient : _BaseWebApiController
    {
        private AuthenticationEngine _authEngine;
        
        public WebApiClient(String commonUrl)
            : base(new Uri(commonUrl), new HttpClient())
        {
            _authEngine = AuthenticationEngineHandler.Get();
        }

        public async Task<JsonPagedArray<DriverView>> GetDriversListAsync(int? page = null, int[] profileStateIds = null, String tin = null)
        {
            var result = await RequestWithAuthAndResponseWithoutParams <JsonPagedArray<DriverView>>.Send
            ( 
                RequestType.GET, 
                this, 
                "drivers", 
                new Dictionary<string, object>
                {
                    { nameof(page), page }
                    ,{ nameof(profileStateIds), profileStateIds }
//                    ,{ nameof(tin), tin }
                }
            );

            return result;
        }

        public async Task< JsonPagedArray<VehicleView> > GetVehiclesListAsync(int? page = null, int[] profileStateIds = null)
        {
            var result = await RequestWithAuthAndResponseWithoutParams< JsonPagedArray<VehicleView> >.Send
            (
                RequestType.GET,
                this,
                "vehicles",
                new Dictionary<string, object>
                {
                    { nameof(page), page },
                    { nameof(profileStateIds), profileStateIds }
                }
            );

            return result;
        }

        public async Task<JsonPagedArray<CompanyView>> GetCompaniesListAsync(int? page = null, int[] profileStateIds = null, String tin = null)
        {
            var result = await RequestWithAuthAndResponseWithoutParams<JsonPagedArray<CompanyView>>.Send
            (
                RequestType.GET,
                this,
                "companies",
                new Dictionary<string, object>
                {
                    { nameof(page), page }
//                    ,{ nameof(profileStateIds), profileStateIds }
                    //,{ nameof(tin), tin }
                }
            );

            foreach(CompanyView currItem in result.Items)
            {
                StringBuilder sb = new StringBuilder(100);
                foreach (DirectoryItem currValue in currItem.ProfileStateReason)
                {
                    sb.Append(currValue.Name);
                    sb.Append(", ");
                }
                currItem.ProfileStateReasonStr = sb.ToString();
            }

            return result;
        }

        public async Task< JsonPagedArray<RecordView> > GetFinanceRecordsListByDriverIdAsync(int page, int driverId)
        {
            String currLastUriPart = "drivers/"+driverId.ToString()+"/finance/records";

            var result = await RequestWithAuthAndResponseWithoutParams< JsonPagedArray<RecordView> >.Send
            (
                RequestType.GET,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                    { nameof(page), page }
                }
            );

            if (result == null)
            {
                result = new JsonPagedArray<RecordView>( new List<RecordView>(), 1, 0 );
            }

            return result;
        }

        //public async Task<JsonPagedArray<RecordView>> GetFinanceRecordsListByCompanyIdAsync(int page, int companyId)
        //{
        //    String currLastUriPart = "drivers/" + driverId.ToString() + "/finance/records";

        //    var result = await RequestWithAuthAndResponseWithoutParams<JsonPagedArray<RecordView>>.Send
        //    (
        //        RequestType.GET,
        //        this,
        //        currLastUriPart,
        //        new Dictionary<string, object>
        //        {
        //            { nameof(page), page }
        //        }
        //    );

        //    if (result == null)
        //    {
        //        result = new JsonPagedArray<RecordView>(new List<RecordView>(), 1, 0);
        //    }

        //    return result;
        //}

        public async Task<CompanyView> GetCompanyByIdAsync(int? companyId)
        {
            String currLastUriPart = "companies/" + companyId.ToString();

            var result = await RequestWithAuthAndResponseWithoutParams<CompanyView>.Send
            (
                RequestType.GET,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            StringBuilder sb = new StringBuilder(100);
            foreach (DirectoryItem currValue in result.ProfileStateReason)
            {
                sb.Append(currValue.Name);
                sb.Append(", ");
            }
            result.ProfileStateReasonStr = sb.ToString();

            if (result.IsSoleProprietor == true)
                result.IsSoleProprietorStr = "да";
            else
                result.IsSoleProprietorStr = "нет";


            return result;
        }

        public async Task<VehicleView> GetVehicleByIdAsync(int? vehicleId)
        {
            String currLastUriPart = "vehicles/" + vehicleId.ToString();

            var result = await RequestWithAuthAndResponseWithoutParams<VehicleView>.Send
            (
                RequestType.GET,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            return result;
        }

        public async Task<DriverView> GetDriverByIdAsync(int? driverId)
        {
            String currLastUriPart = "drivers/" + driverId.ToString();

            var result = await RequestWithAuthAndResponseWithoutParams<DriverView>.Send
            (
                RequestType.GET,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            // если координаты не заполнены, то заполним их тестовыми значениями !!!
            if (result != null && result.Shift != null )
            {
                if (result.Shift.Location.Latitude == 0.0 && result.Shift.Location.Longitude == 0.0)
                {
                    result.Shift.Location = new Location()
                    {
                        Latitude = 55.822456,
                        Longitude = 37.639675
                    };
                }
            }

            return result;
        }

        public async Task<ShiftOrderView> GetShiftOrderByRegistrationPhoneAsync(String registrationPhone)
        {
            String currLastUriPart = "shifts/phone/" + registrationPhone;

            var result = await RequestWithAuthAndResponseWithoutParams<ShiftOrderView>.Send
            (
                RequestType.GET,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            // если координаты не заполнены, то заполним их тестовыми значениями !!!
            if (result != null && result.Shift != null)
            {
                if (result.Shift.Location.Latitude == 0.0 && result.Shift.Location.Longitude == 0.0)
                {
                    result.Shift.Location = new Location()
                    {
                        Latitude = 55.822456,
                        Longitude = 37.639675
                    };
                }
            }

            return result;
        }

        public void GetNextProfileStateIdAndName(ProfileState currProfileState, out long? nextPorfStateId, out String nextProfStateName)
        {
            List<DirectoryItem> dir = DirectoryPool.GetDirectoryValuesById(DirectoryIds.ProfileState);

            if( currProfileState == ProfileState.Incompleted ||
                currProfileState == ProfileState.Confirmed ||
                currProfileState == ProfileState.Rejected )
            {
                nextPorfStateId = null;
                nextProfStateName = null;
            }
            else
            {
                switch (currProfileState)
                {
                    case ProfileState.Updated:
                        nextPorfStateId = (long?) ProfileState.Verificating;
                        nextProfStateName = dir.Single( x => x.Id==(long) ProfileState.Verificating).Name;
                    break;
                    case ProfileState.Verificating:
                        nextPorfStateId = (long?)ProfileState.Approved;
                        nextProfStateName = dir.Single(x => x.Id == (long)ProfileState.Approved).Name;
                    break;
                    case ProfileState.Approved:
                        nextPorfStateId = (long?)ProfileState.Confirmed;
                        nextProfStateName = dir.Single(x => x.Id == (long)ProfileState.Confirmed).Name;
                    break;
                    default:
                        nextPorfStateId = null;
                        nextProfStateName = null;
                    break;
                }
            }
        }

        public async Task<Boolean> VehicleVerifyAsync(int? vehicleId)
        {
            String currLastUriPart = "vehicles/" + vehicleId.ToString() + "/verify";

            var result = await RequestWithAuthWithoutParamsAndResponse.Send
            (
                RequestType.PUT,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            return result;
        }

        public async Task<Boolean> VehicleApproveAsync(int? vehicleId)
        {
            String currLastUriPart = "vehicles/" + vehicleId.ToString() + "/approve";

            var result = await RequestWithAuthWithoutParamsAndResponse.Send
            (
                RequestType.PUT,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            return result;
        }

        public async Task<Boolean> VehicleConfirmAsync(int? vehicleId)
        {
            String currLastUriPart = "vehicles/" + vehicleId.ToString() + "/confirm";

            var result = await RequestWithAuthWithoutParamsAndResponse.Send
            (
                RequestType.PUT,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            return result;
        }

        public async Task<Boolean> VehicleRejectAsync(int? vehicleId)
        {
            String currLastUriPart = "vehicles/" + vehicleId.ToString() + "/reject";

            var result = await RequestWithAuthWithoutParamsAndResponse.Send
            (
                RequestType.PUT,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            return result;
        }

        public async Task<Boolean> DriverVerifyAsync(int? driverId)
        {
            String currLastUriPart = "drivers/" + driverId.ToString() + "/verify";

            var result = await RequestWithAuthWithoutParamsAndResponse.Send
            (
                RequestType.PUT,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            return result;
        }

        public async Task<Boolean> DriverApproveAsync(int? driverId)
        {
            String currLastUriPart = "drivers/" + driverId.ToString() + "/approve";

            var result = await RequestWithAuthWithoutParamsAndResponse.Send
            (
                RequestType.PUT,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            return result;
        }

        public async Task<Boolean> DriverConfirmAsync(int? driverId)
        {
            String currLastUriPart = "drivers/" + driverId.ToString() + "/confirm";

            var result = await RequestWithAuthWithoutParamsAndResponse.Send
            (
                RequestType.PUT,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            return result;
        }

        public async Task<Boolean> DriverRejectAsync(int? driverId)
        {
            String currLastUriPart = "drivers/" + driverId.ToString() + "/reject";

            var result = await RequestWithAuthWithoutParamsAndResponse.Send
            (
                RequestType.PUT,
                this,
                currLastUriPart,
                new Dictionary<string, object>
                {
                }
            );

            return result;
        }

    }
}
