using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace askonUFA.Database
{
    public class Objects
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Type { get; set; }
        [StringLength(255)]
        public string Product { get; set; }

        [InverseProperty(nameof(Attributes.Object))]
        public virtual ICollection<Attributes> Attributess { get; set; }

        // Один Object может быть родителем во многих Links
        [InverseProperty(nameof(Links.Parent))]
        public virtual ICollection<Links> ChildLinks { get; set; }

        // Один Object может быть дочерним во многих Links
        [InverseProperty(nameof(Links.Child))]
        public virtual ICollection<Links> ParentLinks { get; set; }
    }
}
