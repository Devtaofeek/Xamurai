using System;
using Xamarin.Forms;

namespace Xamurai
{
    public class HorizontalListViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MercedesTemplate { get; set; }
        public DataTemplate CarTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var car = item as Car;
            if (car.Make == CarMake.Mercedes)
            {
                return MercedesTemplate;
            }
            else
            {
                return CarTemplate;
            }
        }
    }
}

