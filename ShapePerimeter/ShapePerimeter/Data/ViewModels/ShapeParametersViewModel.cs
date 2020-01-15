using ShapePerimeter.Data.Helper;
using System;
using System.Windows;
using System.Windows.Input;

namespace ShapePerimeter.Data.ViewModels
{
    public class ShapeParametersViewModel: ViewModelBase
    {
        public IShape Shape { get; private set; }

        public ShapeParametersViewModel(IShape shape) { Shape = shape; }
        
        private ICommand _acceptCommand;
        public ICommand AcceptCommand { get { return _acceptCommand ?? (new RelayCommand(OnAccept, CanAccept)); } }
        private bool CanAccept(object obj)
        {
            return Shape.IsValid;
        }

        private void OnAccept(object obj)
        {
            
        }
    }
}

        
    
