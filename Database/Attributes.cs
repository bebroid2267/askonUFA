using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askonUFA.Database
{
    public class Attributes
    {
        [Key]
        public int objectId {  get; set; }
        [ForeignKey(nameof(objectId))]
        [InverseProperty("Attributess")]
        public virtual Objects Object { get; set; }
        [StringLength(255)]
        public string name { get; set; }
        [StringLength(255)]
        public string value { get; set; }
        
    }
}
