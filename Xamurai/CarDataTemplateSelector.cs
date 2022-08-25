using System;
using Xamarin.Forms;

namespace Xamurai
{
    public class CarDataTemplateSelector : DataTemplateSelector
    {
        public CarDataTemplateSelector()
        {
            this.CarView = new DataTemplate(typeof(CarView));
            this.MercedesView = new DataTemplate(typeof(MercedesView));
            this.MercedesView = new DataTemplate();
        }

        public DataTemplate CarView { get; set; }
        public DataTemplate MercedesView { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var car = item as Car;
            if (car.Make == CarMake.Mercedes)
            {
                return MercedesView;
            }
            else
            {
                return CarView;
            }
        }
    }
}

