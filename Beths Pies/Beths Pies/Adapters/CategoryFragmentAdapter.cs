using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Beths_Pies.Fragments;
using BethsPiesMobile.core.Models;
using BethsPiesMobile.core.Repositories;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace Beths_Pies.Adapters
{
    public class CategoryFragmentAdapter : FragmentPagerAdapter
    {

        private readonly List<Category> _categories;
        public CategoryFragmentAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CategoryFragmentAdapter(FragmentManager fm) : base(fm)
        {
            var pieRepository = new PieRepository();
            _categories = pieRepository.GetCategoriesWithPies();
        }

        public override int Count => _categories.Count;
        public override Fragment GetItem(int position)
        {
            PieCategoryFragment pieCategoryFragment = new PieCategoryFragment(_categories[position]);
            return pieCategoryFragment;
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(_categories[position].CategoryName);
        }
    }
}