﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BethanysPieShopMobile.Utility;
using Beths_Pies.ViewHolders;
using BethsPiesMobile.core.Models;
using BethsPiesMobile.core.Repositories;

namespace Beths_Pies.Adapters
{
    public class PieAdapter: RecyclerView.Adapter
    {
        private List<Pie> _pies;
        public event EventHandler<int> ItemClick;

        public PieAdapter()
        {
            //var pieRepository = new PieRepository();
            //_pies = pieRepository.GetAllPies();
        }

        public async Task LoadData()
        {
            var pieRepository = new PieRepositoryWeb();
            _pies = await pieRepository.GetAllPies();
        }

        public PieAdapter(Category category)
        {
            _pies = category.Pies;
        }

        public override int ItemCount => _pies.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is PieViewHolder pieViewHolder)
            {
                pieViewHolder.PieNameTextView.Text = _pies[position].Name;

                var imageBitmap = ImageHelper.GetImageBitmapFromUrl(_pies[position].ImageThumbnailUrl);
                pieViewHolder.PieImageView.SetImageBitmap(imageBitmap);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView =
                LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Pie_viewHolder, parent, false);

            PieViewHolder pieViewHolder = new PieViewHolder(itemView, OnClick);
            return pieViewHolder;
        }

        void OnClick(int position)
        {
            var pieId = _pies[position].PieId;
            ItemClick?.Invoke(this, pieId);
        }
    }
}