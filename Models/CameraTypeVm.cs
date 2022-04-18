using HelloMauiApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiApp.Models
{
    public class CameraTypeVm : BaseViewModel
    {
        public string Type { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set=>SetProperty(ref _isSelected, value);
        }

        public override bool Equals(object obj)
        {
            var type = obj as CameraTypeVm;
            return this.Type.Equals(type.Type);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
