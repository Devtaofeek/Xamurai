using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamurai
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
		SampleViewModel Vm => BindingContext as SampleViewModel;
		public ListViewPage ()
        {
            BindingContext = new SampleViewModel();
            InitializeComponent();
            InitializeAppOrientationSettings();
        }

        private void InitializeAppOrientationSettings()
        {
            if (DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Landscape)
            {
                CarList.IsVisible = false;
                HorizontalList.IsVisible = true;
            }
            else
            {
                HorizontalList.IsVisible = false;
                CarList.IsVisible = true;
            }
            DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
			if (e.DisplayInfo.Orientation == DisplayOrientation.Portrait)
            {
				HorizontalList.IsVisible = false;
                CarList.IsVisible = true;
            }
            else
            {
                CarList.IsVisible = false;
                HorizontalList.IsVisible = true;
            }
        }

        protected override void OnAppearing()
        {

            CarList.ItemsSource = new ObservableCollection<Car>(Vm.Cars);
            DependencyService.Get<IStatusBar>().HideStatusBar();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }

        void SwipeItem_Clicked(System.Object sender, System.EventArgs e)
        {

            // this was done in the 
            var contentView = sender as SwipeItem;
            var car = contentView.BindingContext as Car;
            Vm.Cars.Remove(car);
            CarList.ItemsSource = new ObservableCollection<Car>(Vm.Cars);
        }
    }
}