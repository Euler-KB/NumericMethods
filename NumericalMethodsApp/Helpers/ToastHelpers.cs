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

namespace NumericalMethodsApp.Helpers
{
    public static class ToastHelpers
    {
        public static void ShowRequiredInputs(Context context)
        {
            Toast.MakeText(context, "Please enter all required input!", ToastLength.Short).Show();
        }
    }
}