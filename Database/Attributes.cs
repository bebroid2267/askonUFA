using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace askonUFA.Database
{
    public class Attributes : TreeItems 
    {
        [ForeignKey("ObjectId")]
        [InverseProperty("Attributess")]
        public int ObjectId { get; set; }
        public virtual Objects Object { get; set; }
        [StringLength(255)]
        public string name 
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }
        
        
        [StringLength(255)]
        public string value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("value");
            }
        }

        private string _name;
        private string _value;
        
    }
}
