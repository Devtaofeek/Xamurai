using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Xamarin.Forms;

namespace Xamurai
{
    public partial class MercedesView : ContentView
    {
        public MercedesView()
        {
            IsExpanded = true;
            InitializeComponent();
        }
        double contentSize;
        public ICommand ToggleCollapseCommand { get {

                return new Command( async a =>
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
            } }

        public bool IsExpanded { get; set; }

    }
}

