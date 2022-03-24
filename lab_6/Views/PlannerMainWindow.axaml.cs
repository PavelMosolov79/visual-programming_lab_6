using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab_6.Views
{
    public partial class PlannerMainWindow : UserControl
    {
        public PlannerMainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
