using ShapePerimeter.Data.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ShapePerimeter.View
{
    /// <summary>
    /// Interaction logic for ShapeParameterWindow.xaml
    /// </summary>
    public partial class ShapeParameterWindow : Window
    {
       
        public ShapeParameterWindow(IShape shape)
        {
            InitializeComponent();
            DataContext = new ShapeParametersViewModel(shape);
            var control = (ContentControl)this.FindName(shape.Type.ToString());
            control.Visibility = Visibility.Visible;
        }

        private void OnApprove_Click(object sender, RoutedEventArgs e) { this.DialogResult = true; Close(); }
        private void OnCancel_Click(object sender, RoutedEventArgs e) { this.DialogResult = false;Close(); }
    }
}
