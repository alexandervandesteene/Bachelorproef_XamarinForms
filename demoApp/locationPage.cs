using System;
using Plugin.Geolocator;

using Xamarin.Forms;

namespace demoApp
{
	public class locationPage : ContentPage
	{
		Button btnLocation;
		Label lbllat,lbllong,txtlat,txtlong;
		StackLayout stacklat,stacklong;

		public locationPage ()
		{
			btnLocation = new Button ();
			btnLocation.Text = "get location";

			btnLocation.Clicked += async (object sender, EventArgs e) => {
				
				long date1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
				
				try
				{
					var locator = CrossGeolocator.Current;
					locator.DesiredAccuracy = 50;

					var position = await locator.GetPositionAsync (timeoutMilliseconds: 10000);

					long date2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
					long time = date2-date1;
					System.Diagnostics.Debug.WriteLine("time in milliseconds: " + time);

					txtlat.Text = position.Latitude+"";
					txtlong.Text = position.Longitude+"";
				}
				catch(Exception ex)
				{
					
				}

			};

			lbllat = new Label ();
			lbllat.Text = "lat: ";
			txtlat = new Label ();

			stacklat = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { lbllat, txtlat }
			};

			lbllong = new Label ();
			lbllong.Text = "lat: ";
			txtlong = new Label ();

			stacklong = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { lbllong, txtlong }
			};
					
			Content = new StackLayout {
				Children = { btnLocation, stacklat,stacklong}
			};


		}
	}
}


