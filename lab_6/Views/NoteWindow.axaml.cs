using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab_6.Views
{
    public partial class NoteWindow : UserControl
    {
        public NoteWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
