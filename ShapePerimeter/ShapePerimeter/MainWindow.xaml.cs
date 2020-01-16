using ShapePerimeter.Data.ViewModels;
using System.Windows;

namespace ShapePerimeter
{
   
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ShapeViewModel();
        }
    }
}
