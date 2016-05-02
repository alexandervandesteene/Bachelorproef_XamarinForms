using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace demoApp
{
	public class homePage : ContentPage
	{
		List<User> users;
		ListView listusers;

		public homePage()
		{
			

			ToolbarItems.Add(new ToolbarItem("map", "", () =>
			{
					Navigation.PushAsync(new locationPage());
			}));
			ToolbarItems.Add(new ToolbarItem("add", "", () =>
			{
					long date1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
					Navigation.PushAsync(new addPage(date1));
			}));


			Title = "users";
			listusers = new ListView ();
			Padding = new Thickness (0,20,0,0);
			Content = listusers;
			BackgroundColor = Color.White;

			listusers.ItemSelected += (sender, e) => {
				if (e.SelectedItem != null){
					var user = new User();
					user = (User) e.SelectedItem;
					System.Diagnostics.Debug.WriteLine(user.id);
					Navigation.PushAsync(new editPage(user.id));
				}


				((ListView)sender).SelectedItem = null;


			};

		}
		protected async override void OnAppearing ()
		{
			base.OnAppearing ();
			listusers.ItemsSource = null;

			long date1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			users = await DataController.getUsersAsync ();
			long date2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			long time = date2-date1;
			System.Diagnostics.Debug.WriteLine(" get 100 time in milliseconds: " + time);

			listusers.ItemsSource = users;
			listusers.ItemTemplate = new DataTemplate (typeof(CustomCell));
		}
	}
}


