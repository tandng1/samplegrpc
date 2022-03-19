using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrpcService1.Entities
{
    public class PatientEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string SoHS { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
    }
}
