using WheatherStation.DAL.Entities;

namespace WheatherStation.Services
{
    public interface IArduinoDbService
    {
        public Task AddData(Arduino arduino);
        public Task<IEnumerable<Arduino>> GetAllArduinoData();
        public Task<Arduino> GetLastData();
        public Task<List<Arduino>> GetDataByDate(DateTime dateFrom, DateTime dateTo);
    }
}
