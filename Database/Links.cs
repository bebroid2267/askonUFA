using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askonUFA.Database
{
    public class Links
    {
        [Key]
        public int Id { get; set; } // Предполагаю, что у Links тоже должен быть уникальный идентификатор

        [ForeignKey(nameof(Parent))]
        public int ParentId { get; set; }
        [InverseProperty("ChildLinks")]
        public virtual Objects Parent { get; set; }

        [ForeignKey(nameof(Child))]
        public int ChildId { get; set; }
        [InverseProperty("ParentLinks")]
        public virtual Objects Child { get; set; }
    }
}
