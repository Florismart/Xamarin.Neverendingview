using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Florismart.Neverendingview.Droid.Views;

namespace Florismart.Neverendingview.Droid.Sample
{
	[Activity (Label = "Florismart.Neverendingview.Droid.Sample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected HorizontalNeverendingView horizontal;
		protected Button startButton;
		protected Button stopButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			horizontal = FindViewById<HorizontalNeverendingView> (Resource.Id.my_neverendingview1);
			startButton = FindViewById<Button> (Resource.Id.start_button);
			stopButton = FindViewById<Button> (Resource.Id.stop_button);

			startButton.Click += (object sender, EventArgs e) => {
				horizontal.GetController ().Start ();
			};

			stopButton.Click += (object sender, EventArgs e) => {
				horizontal.GetController ().Stop ();
			};

			horizontal.ScrollLimitReached += (o, e) => {
				RunOnUiThread (() => {
					Toast.MakeText (this, "Limit Reached", ToastLength.Long).Show ();
				});
			};
		}
	}
}


