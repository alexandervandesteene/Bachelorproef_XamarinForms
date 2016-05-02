using System;

using Xamarin.Forms;

namespace demoApp
{
	public class addPage : ContentPage
	{
		Label lblFirstname,lblLastname,lblEmail,lblGender,lblIpAddress;
		Entry txtFirstname,txtLastname,txtEmail,txtGender,txtIpAddress;
		StackLayout stackFirstname,stackLastname,stackEmail,stackGender,stackIpAddress,stackButtons;
		Button btnAdd;

		public addPage (long date11)
		{
			long date21 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			long time1 = date21-date11;
			System.Diagnostics.Debug.WriteLine("change page: " + time1);

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

			btnAdd = new Button{ };
			btnAdd.Text = "Add";
			btnAdd.Clicked += async (object sender, EventArgs e) => {
				long date1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
				Boolean test = await DataController.addUser(txtFirstname.Text,txtLastname.Text,txtEmail.Text,txtGender.Text,txtIpAddress.Text);
				if(test){
					long date2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
					long time = date2-date1;
					System.Diagnostics.Debug.WriteLine(" add user time in milliseconds: " + time);
					await Navigation.PopAsync();
				}
			};
				
			stackButtons = new StackLayout {
				Spacing = 0,
				Padding = new Thickness (10, 5, 10, 5),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { btnAdd }
			};

			Content =new ScrollView{ Content= new StackLayout{
				Children={stackFirstname,stackLastname,stackEmail,stackGender,stackIpAddress,stackButtons}
				}};
		}
	}
}


