using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Beths_Pies
{
    [Activity(Label = "AboutActivity")]
    public class AboutActivity : Activity
    {
        private Button _phoneButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.About);
            
            // Create your application here
            FindViews();
            LinkEventHandlers();
        }

        private void LinkEventHandlers()
        {
            _phoneButton.Click += _phoneButton_Click;
        }

        private void _phoneButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionDial);
            intent.SetData(Android.Net.Uri.Parse("tel:+1555779933"));
            intent.AddFlags(ActivityFlags.NewTask);
            StartActivity(intent);
        }

        private void FindViews()
        {
            _phoneButton = FindViewById<Button>(Resource.Id.phoneButton);
        }
    }
}