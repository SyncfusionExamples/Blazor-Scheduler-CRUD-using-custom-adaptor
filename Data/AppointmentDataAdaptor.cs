using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace syncfusion_blazor_app.Data {
    public class AppointmentDataAdaptor : DataAdaptor {
        private readonly AppointmentDataService _appService;
        public AppointmentDataAdaptor(AppointmentDataService appService) {
            _appService = appService;
        }

        List<AppointmentData>? EventData;
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null) {
            await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
            EventData = await _appService.Get();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = EventData, Count = EventData.Count() } : EventData;
        }
        public async override Task<object> InsertAsync(DataManager dataManager, object data, string key) {
            await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
            await _appService.Insert(data as AppointmentData);
            return data;
        }
        public async override Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key) {
            await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
            await _appService.Update(data as AppointmentData);
            return data;
        }
        public async override Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key) //triggers on appointment deletion through public method DeleteEvent
        {
            await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
            var app = await _appService.GetByID((int)data);
            await _appService.Delete(app);
            return data;
        }
        public async override Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex) {
            await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
            object records = deletedRecords;
            List<AppointmentData>? deleteData = deletedRecords as List<AppointmentData>;
            if(deleteData != null) {
                foreach (var data in deleteData) {
                    await _appService.Delete(data as AppointmentData);
                }
            }
            List<AppointmentData>? addData = addedRecords as List<AppointmentData>;
            if(addData != null) {
                foreach (var data in addData) {
                    await _appService.Insert(data as AppointmentData);
                    records = addedRecords;
                }
            }
            List<AppointmentData>? updateData = changedRecords as List<AppointmentData>;
            if (updateData != null) {
                foreach (var data in updateData) {
                    await _appService.Update(data as AppointmentData);
                    records = changedRecords;
                }
            }
            return records;
        }
    }
}
