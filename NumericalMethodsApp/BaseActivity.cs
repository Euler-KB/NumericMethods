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
using Android.Support.V7.App;
using NumericalMethodsApp.Helpers;

namespace NumericalMethodsApp
{
    public class BaseActivity : AppCompatActivity
    {
        private int? layout;

        protected event EventHandler<Bundle> Loaded;

        protected virtual bool HasBackButton => true;

        public BaseActivity() { }

        public BaseActivity(int layout)
        {
            this.layout = layout;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (layout != null)
                SetContentView(layout.Value);

            //
            this.SetupToolbar(HasBackButton);

            //
            Loaded?.Invoke(this, savedInstanceState);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}