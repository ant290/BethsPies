using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace Beths_Pies
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _orderButton;
        private Button _cartButton;
        private Button _aboutButton;
        private Button _orderWithTabsButton;
        private Button _googleMapsButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity_main);

            FindViews();
            LinkEventHandlers();
        }

        private void LinkEventHandlers()
        {
            _orderButton.Click += _orderButton_Click;
            _cartButton.Click += _cartButton_Click;
            _aboutButton.Click += _aboutButton_Click;
            _orderWithTabsButton.Click += _orderWithTabsButton_Click;
            _googleMapsButton.Click += _googleMapsButton_Click;
        }

        private void _googleMapsButton_Click(object sender, EventArgs e)
        {
            var geolocation = Android.Net.Uri.Parse("geo:50.850346,4.351721");
            var intent = new Intent(Intent.ActionView, geolocation);
            StartActivity(intent);
        }

        private void _orderWithTabsButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PieMenuWithTabsActivity));
            StartActivity(intent);
        }

        private void _aboutButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        private void _cartButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CartActivity));
            StartActivity(intent);
        }

        private void _orderButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PieMenuActivity));
            StartActivity(intent);
        }

        private void FindViews()
        {
            _orderButton = FindViewById<Button>(Resource.Id.orderButton);
            _cartButton = FindViewById<Button>(Resource.Id.cartButton);
            _aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            _orderWithTabsButton = FindViewById<Button>(Resource.Id.tabsButton);
            _googleMapsButton = FindViewById<Button>(Resource.Id.googleMapsButton);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}