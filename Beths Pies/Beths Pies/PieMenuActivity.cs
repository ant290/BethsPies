using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Beths_Pies.Adapters;

namespace Beths_Pies
{
    [Activity(Label = "PieMenuActivity", MainLauncher = true)]
    public class PieMenuActivity : Activity
    {
        private RecyclerView _pieRecyclerView;
        private RecyclerView.LayoutManager _pieLayoutManager;
        private PieAdapter _pieAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Pie_menu);
            _pieRecyclerView = FindViewById<RecyclerView>(Resource.Id.pieMenuRecyclerView);

            //layout manager
            _pieLayoutManager = new LinearLayoutManager(this);
            _pieRecyclerView.SetLayoutManager(_pieLayoutManager);

            //pie adapter
            _pieAdapter = new PieAdapter();
            _pieRecyclerView.SetAdapter(_pieAdapter);

            //view holder
        }
    }
}