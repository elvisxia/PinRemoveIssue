using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapsDemo
{
	public partial class MainPage : ContentPage
	{
        Pin myPin;

        public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MyMap.MoveToRegion(
            MapSpan.FromCenterAndRadius(
        new Position(37, -122), Distance.FromMiles(1)));
            myPin = new Pin
            {
                Position = new Position(37, -122),
                Label="Winffee Pin",
            };
            MyMap.Pins.Add(myPin);

            btnRemove.Clicked += BtnRemove_Clicked;
        }

        private void BtnRemove_Clicked(object sender, EventArgs e)
        {
            MyMap.Pins.Remove(myPin);
        }
    }
}
