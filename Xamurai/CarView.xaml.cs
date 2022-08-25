using Prism.Commands;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Xamurai
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarView : ContentView, INotifyPropertyChanged
	{
		public CarView ()
		{
			IsExpanded = true;
			InitializeComponent ();
		}
        double contentSize;
        public ICommand ToggleCollapseCommand
        {
            get
            {

                return new Command(async a =>
                {
                    if (IsExpanded)
                    {
                        contentSize = this.Content.Height;
                        await this.HeightTo(50, 250, null);
                    }
                    else
                    {
                        await this.HeightTo(contentSize, 250, null);
                    }
                    IsExpanded = !IsExpanded;
                });
            }
        }

        public bool IsExpanded { get; set; }
	}
}