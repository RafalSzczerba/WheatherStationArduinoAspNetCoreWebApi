using WheatherStation.DAL.Entities;

namespace WheatherStation.DAL.Context
{
    public static class SeedData
    {
        public static void SeedArduinoData(ApplicationDbContext context)
        {
             var transfers = new List<Arduino>{
             new Arduino() {Tempetature ="20", Pressure ="1020"},
             new Arduino() {Tempetature="30", Pressure="1030"}
            };
            context.AddRange(transfers);
            context.SaveChanges();
        }
    }
}





