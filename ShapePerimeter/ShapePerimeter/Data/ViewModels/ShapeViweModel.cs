using ShapePerimeter.Data.Helper;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using ShapePerimeter.Data.Model;
using System.Collections.ObjectModel;
using ShapePerimeter.View;

namespace ShapePerimeter.Data.ViewModels
{
    public class ShapeViewModel : ViewModelBase
    {
        public ObservableCollection<IShape> Shapes { get;  set; }      

        public double Perimeters
        {
            get
            {
                double per = 0;
                foreach (var shape in Shapes) per += shape.GetPeremiter();
                return per==0?0:per/Shapes.Count;
            }
        }
        public ShapeViewModel()
        {
            Shapes = new ObservableCollection<IShape>();
        }        

        #region Drawing
        private void OnDrawShape(IShape shape) {
            if (new ShapeParameterWindow(shape).ShowDialog() != true || !shape.IsValid) return;

            Shapes.Add(shape);
            OnPropertyChanged("Shapes");
        }

        private void DrawCircle()
        {
            var shape = new CircleModel();
            OnDrawShape(shape);
        }

        private void DrawRectangle()
        {
            var shape = new RectangleModel();
            OnDrawShape(shape);
        }

        private void DrawTrinagle()
        {
            var shape = new TriangleModel();            
            OnDrawShape(shape);
        }
        #endregion Drawing

        #region Commands
        private ICommand _createShpeCommand;
        private ICommand _getPermiterCommand;

        public ICommand CreateSharpeCommand => _createShpeCommand ?? (_createShpeCommand = new RelayCommand<ShapeTypeEnum>(action: OnExecute, canExecute: CanExecute));
       
        private bool CanExecute(ShapeTypeEnum shapeType)
        {
            return shapeType != default(ShapeTypeEnum);
        }

        private void OnExecute(ShapeTypeEnum shapeType)
        {
            switch (shapeType)
            {
                case ShapeTypeEnum.Triangle:
                    DrawTrinagle();
                    break;
                case ShapeTypeEnum.Rectangle:
                    DrawRectangle();
                    break;
                case ShapeTypeEnum.Circle:
                    DrawCircle();
                    break;
            }
        }

        public ICommand GetPermiterCommand => _getPermiterCommand ?? (_getPermiterCommand = new RelayCommand(OnGetPermiter, CanGetPermiter));

        private bool CanGetPermiter(object param)
        {
            return Shapes.Any();
        }

        private void OnGetPermiter(object param)
        {
            OnPropertyChanged("Perimeters");
        }


        #endregion Commands
    }
}
