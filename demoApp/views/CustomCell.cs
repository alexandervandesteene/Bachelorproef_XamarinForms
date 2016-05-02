using System;
using Xamarin.Forms;


namespace demoApp
{
	public class CustomCell : ViewCell
	{
		public CustomCell ()
		{
			var firstNameLabel = new Label () {
				FontFamily = "HelveticaNeue-Medium",
				FontSize = 18,
				TextColor = Color.Black
			};
			firstNameLabel.SetBinding (Label.TextProperty, "first_name");

			var lastNameLabel = new Label () {
				FontFamily = "HelveticaNeue-Medium",
				FontSize = 18,
				TextColor = Color.Black
			};
			lastNameLabel.SetBinding (Label.TextProperty, "last_name");


			var vetDetailsLayout = new StackLayout {
				Padding = new Thickness (10, 0, 0, 0),
				Spacing = 5,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { firstNameLabel, lastNameLabel }
			};


			var cellLayout = new StackLayout {
				Spacing = 0,
				Padding = new Thickness (10, 5, 10, 5),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { vetDetailsLayout}
			};

			this.View = cellLayout;

		}
	}
}

