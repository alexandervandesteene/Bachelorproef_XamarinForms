using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace demoApp
{
	public class editPage : ContentPage
	{
		String id;
		User user;
		Label lblFirstname,lblLastname,lblEmail,lblGender,lblIpAddress;
		Entry txtFirstname,txtLastname,txtEmail,txtGender,txtIpAddress;
		StackLayout stackFirstname,stackLastname,stackEmail,stackGender,stackIpAddress,stackButtons;
		Button btnUpdate,btnRemove;

		public editPage (string id)
		{
			this.id = id;
			Title="user";

			lblFirstname = new Label ();
			lblFirstname.Text = "first name:";
			txtFirstname = new Entry ();
			stackFirstname = new StackLayout {
				Spacing = 0,
				Padding = new Thickness (10, 5, 10, 5),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { lblFirstname, txtFirstname }
			};

			lblLastname = new Label ();
			lblLastname.Text = "last name:";
			txtLastname = new Entry ();
			stackLastname = new StackLayout {
				Spacing = 0,
				Padding = new Thickness (10, 5, 10, 5),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { lblLastname, txtLastname }
			};

			lblEmail = new Label ();
			lblEmail.Text = "email:";
			txtEmail = new Entry ();
			stackEmail = new StackLayout {
				Spacing = 0,
				Padding = new Thickness (10, 5, 10, 5),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { lblEmail, txtEmail }
			};

			lblGender = new Label ();
			lblGender.Text = "gender:";
			txtGender = new Entry ();
			stackGender = new StackLayout {
				Spacing = 0,
				Padding = new Thickness (10, 5, 10, 5),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { lblGender, txtGender }
			};

			lblIpAddress = new Label ();
			lblIpAddress.Text = "ip-address:";
			txtIpAddress = new Entry ();
			stackIpAddress = new StackLayout {
				Spacing = 0,
				Padding = new Thickness (10, 5, 10, 5),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { lblIpAddress, txtIpAddress }
			};

			btnUpdate = new Button{ };
			btnUpdate.Text = "update";
			btnUpdate.Clicked += async (object sender, EventArgs e) => {
				long date1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
				Boolean test = await DataController.updateUser(user.id,txtFirstname.Text,txtLastname.Text,txtEmail.Text,txtGender.Text,txtIpAddress.Text);
				System.Diagnostics.Debug.WriteLine ("boolean" + test);
				if(test){
					long date2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
					long time = date2-date1;
					System.Diagnostics.Debug.WriteLine("update time in milliseconds: " + time);
					await Navigation.PopAsync();
				}
			};

			btnRemove = new Button{ };
			btnRemove.Text = "remove";
			btnRemove.Clicked += async (object sender, EventArgs e) => {
				long date1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
				Boolean test = await DataController.removeUser(user.id);
				if(test){
					long date2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
					long time = date2-date1;
					System.Diagnostics.Debug.WriteLine(" remove time in milliseconds: " + time);
					await Navigation.PopAsync();
				}
			};

			stackButtons = new StackLayout {
				Spacing = 0,
				Padding = new Thickness (10, 5, 10, 5),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { btnUpdate, btnRemove }
			};
					
			Content =new ScrollView{ Content= new StackLayout{
					Children={stackFirstname,stackLastname,stackEmail,stackGender,stackIpAddress,stackButtons}
				}};
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();
			long date1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			user = await DataController.getUserAsync(id);
			long date2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			long time = date2-date1;
			System.Diagnostics.Debug.WriteLine("get 1 time in milliseconds: " + time);

			txtFirstname.Text = user.first_name;
			txtLastname.Text = user.last_name;
			txtEmail.Text = user.email;
			txtGender.Text = user.gender;
			txtIpAddress.Text = user.ip_address;

		}
	}
}


