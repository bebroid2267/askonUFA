using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace askonUFA.Database
{
    public class Objects : TreeItems 
    {
        private string _type;
        private string _product;
        
        [StringLength(255)]
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }
        [StringLength(255)]
        public string Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged("Product");
            }
        }
        [InverseProperty(nameof(Links.Child))]
        public virtual ObservableCollection<Links> ParentLinks { get; set; }
        [InverseProperty(nameof(Attributes.Object))]
        public List<Attributes> Attributess { get; set; } = new List<Attributes>();

        [InverseProperty(nameof(Links.Parent))]
        public virtual ObservableCollection<Links> ChildLinks { get; set; }
        
        public IEnumerable<TreeItems> ChildTreeItems
        {
            get
            {   
                if(ChildLinks != null)
                foreach (var link in ChildLinks)
                    yield return link.Child;
                if(Attributess != null)
                foreach (var attribute in Attributess)
                    yield return attribute;
            }
        }
        public IEnumerable<TreeItems> CombinedChildren
        {
            get
            {
                var children = new List<TreeItems>();

                if (ChildLinks != null)
                    children.AddRange(ChildLinks.Select(link => link.Child));

                if (Attributess != null)
                    children.AddRange(Attributess);

                return children;
            }
        }

    }
}
