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
    [Activity(Label = "PieMenuActivity")]
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
            
            //view holder
            _pieRecyclerView = FindViewById<RecyclerView>(Resource.Id.pieMenuRecyclerView);

            //layout manager
            //example of horizontal scrolling grid layout
            //_pieLayoutManager = new GridLayoutManager(this, 2, GridLayoutManager.Horizontal, false);
            _pieLayoutManager = new LinearLayoutManager(this);
            _pieRecyclerView.SetLayoutManager(_pieLayoutManager);

            //pie adapter
            _pieAdapter = new PieAdapter();
            _pieAdapter.ItemClick += _pieAdapter_ItemClick;
            _pieRecyclerView.SetAdapter(_pieAdapter);
        }

        private void _pieAdapter_ItemClick(object sender, int e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(PieDetailActivity));
            intent.PutExtra("selectedPieId", e);
            StartActivity(intent);
        }
    }
}