using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WheatherStation.DAL.Entities
{
    [Table("Arduino Data")]

    public class Arduino : IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        [StringLength(300)]
        public string Tempetature { get; set; }
        [StringLength(300)]
        public string Pressure { get; set; }
        public Arduino() => Created = DateTime.Now;
    }
}
