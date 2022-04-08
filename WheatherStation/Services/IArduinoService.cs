using WheatherStation.DAL.Entities;

namespace WheatherStation.Services
{
    public interface IArduinoService
    {
        Arduino ReadMeasure();
        Task WriteMeasureToDataBase();
    }
}
