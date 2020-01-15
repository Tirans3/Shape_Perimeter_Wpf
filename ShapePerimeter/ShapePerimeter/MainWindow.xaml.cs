using ShapePerimeter.Data.ViewModels;
using System.Windows;

namespace ShapePerimeter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ShapeViewModel();
        }
    }
}
