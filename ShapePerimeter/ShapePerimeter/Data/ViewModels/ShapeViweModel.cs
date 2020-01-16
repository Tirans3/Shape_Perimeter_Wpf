using ShapePerimeter.Data.Helper;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using ShapePerimeter.Data.Model;
using System.Collections.ObjectModel;
using ShapePerimeter.View;
using System.Windows;

namespace ShapePerimeter.Data.ViewModels
{
    public class ShapeViewModel : ViewModelBase
    {
        public ObservableCollection<IShape> Shapes { get; set; }
        public IShape Shape { get; set; }
        public double Perimeters
        {
            get
            {
                double per = 0;
                foreach (var shape in Shapes) per += shape.GetPeremiter();
                return per == 0 ? 0 : per / Shapes.Count;
            }
        }

        private bool _isCilcleChecked;
        public bool IsCilcleChecked
        {
            get { return _isCilcleChecked; }
            set
            {
                if (_isCilcleChecked == value) return;
                _isCilcleChecked = value;
                if (value)
                {
                    IsRectangleChecked = false;
                    IsTriangleChecked = false;
                }
                OnPropertyChanged("IsCilcleChecked");
                Shape = value ? new CircleModel() : null;
                OnPropertyChanged("Shape");
            }
        }

        private bool _isRectangleChecked;
        public bool IsRectangleChecked
        {
            get { return _isRectangleChecked; }
            set
            {
                if (_isRectangleChecked == value) return;
                _isRectangleChecked = value;
                if (value)
                {
                    IsCilcleChecked = false;
                    IsTriangleChecked = false;
                }
                OnPropertyChanged("IsRectangleChecked");
                Shape = value ? new RectangleModel() : null;
                OnPropertyChanged("Shape");
            }
        }

        private bool _isTriangleChecked;
        public bool IsTriangleChecked
        {
            get { return _isTriangleChecked; }
            set
            {
                if (_isTriangleChecked == value) return;
                _isTriangleChecked = value;
                if (value)
                {
                    IsCilcleChecked = false;
                    IsRectangleChecked = false;
                }
                OnPropertyChanged("IsTriangleChecked");
                Shape = value ? new TriangleModel() : null;
                OnPropertyChanged("Shape");
            }
        }

        public ShapeViewModel()
        {
            Shapes = new ObservableCollection<IShape>();
        }

        #region Drawing
        private void OnDrawShape(IShape shape)
        {
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

        private ShapeTypeEnum GetShapetype()
        {
            if (IsTriangleChecked) return ShapeTypeEnum.Triangle;
            if (IsCilcleChecked) return ShapeTypeEnum.Circle;
            if (IsRectangleChecked) return ShapeTypeEnum.Rectangle;
            return default(ShapeTypeEnum);
        }
        #endregion Drawing

        #region Commands
        private ICommand _createShpeCommand;
        private ICommand _getPermiterCommand;

        public ICommand CreateShapeCommand => _createShpeCommand ?? (_createShpeCommand = new RelayCommand<Point>(OnExecute));

        private bool CanExecute(Point e)
        {
            return  Shape.IsValid;
        }

        private void OnExecute(Point e)
        {
            if (!CanExecute(e)) return;

            var shape = (IShape)Shape.Clone();
            switch (GetShapetype())
            {
                case ShapeTypeEnum.Triangle:
                    shape.X = e.X;
                    shape.Y = e.Y;
                    //DrawTrinagle();
                    break;
                case ShapeTypeEnum.Rectangle:
                    shape.X = e.X;
                    shape.Y = e.Y;
                    //DrawRectangle();
                    break;
                case ShapeTypeEnum.Circle:
                    shape.X = e.X ;
                    shape.Y = e.Y ;
                    //DrawCircle();
                    break;
            }

            Shapes.Add(shape);
            OnPropertyChanged("Perimeters");
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
