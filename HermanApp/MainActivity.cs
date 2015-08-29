using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HermanApp
{
	[Activity (Label = "HermanApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		//Define UI controls
		Button submitButton;
		EditText InputText;
		TextView DisplayText;
		CheckBox FontinBold;
		CheckBox FontinItalic;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our UI controls from the loaded layout:
			submitButton = FindViewById<Button>(Resource.Id.Button1);
			InputText = FindViewById<EditText>(Resource.Id.TextInput1);
			DisplayText = FindViewById<EditText>(Resource.Id.TextView1);
			FontinBold = FindViewById<CheckBox> (Resource.Id.BoldChecked);
			FontinItalic = FindViewById<CheckBox> (Resource.Id.ItalicChecked);

			InputText.Text = "";

			// Get our button from the layout resource,
			// and attach an event to it
			submitButton.Click += (object sender, EventArgs e) =>
			{
				//Set the font type depend on the options selected
				if ((FontinBold.Checked) && (FontinItalic.Checked))
					DisplayText.SetTypeface (null,Android.Graphics.TypefaceStyle.BoldItalic);
				else if (FontinBold.Checked)
					DisplayText.SetTypeface (null,Android.Graphics.TypefaceStyle.Bold);
				else if (FontinItalic.Checked)
					DisplayText.SetTypeface (null,Android.Graphics.TypefaceStyle.Italic);
				else DisplayText.SetTypeface (null,Android.Graphics.TypefaceStyle.Normal);

				//Echo the word into output field
				if (String.IsNullOrWhiteSpace(InputText.Text))
					DisplayText.Text = "Nothing was entered";
				else
					DisplayText.Text = "You entered: " + InputText.Text;
			};
		}
	}
}


