using Microsoft.EntityFrameworkCore;
using WheatherStation.DAL.Entities;
using WheatherStation.DAL.Repositiories;

namespace WheatherStation.Services
{
    public class ArduinoDbService : IArduinoDbService
    {
        private IBaseRepository<Arduino> _arduinoRepository;

        public ArduinoDbService(IBaseRepository<Arduino> arduinoRespository)
        {
            _arduinoRepository = arduinoRespository;
        }
        public async Task AddData(Arduino arduino)
        {
            await _arduinoRepository.Create(arduino);
        }

        public async Task<IEnumerable<Arduino>> GetAllArduinoData()
        {
            return await _arduinoRepository.FindAll();
        }

        public async Task<List<Arduino>> GetDataByDate(DateTime dateFrom, DateTime dateTo)
        {
            dateTo = dateTo.AddDays(1);
            return await _arduinoRepository.GetAllQueryable()
                .Where(s => s.Created >= dateFrom && s.Created < dateTo).ToListAsync();
        }

        public async Task<Arduino> GetDataById(int id)
        {
            return await _arduinoRepository.FindById(id);
        }
    }
}
