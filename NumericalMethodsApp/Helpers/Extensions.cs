using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace NumericalMethodsApp.Helpers
{
    public static class Extensions
    {
        public static void SetupToolbar(this AppCompatActivity activity, bool allowNavigateHome = true, string title = null)
        {
            var supportToolbar = activity.FindViewById<Toolbar>(Resource.Id.support_toolbar);
            activity.SetSupportActionBar(supportToolbar);

            if (allowNavigateHome)
            {
                activity.SupportActionBar.SetHomeButtonEnabled(true);
                activity.SupportActionBar.SetDefaultDisplayHomeAsUpEnabled(true);
                activity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }

            //
            if (title != null)
            {
                activity.SupportActionBar.Title = title;
            }

        }
    }
}