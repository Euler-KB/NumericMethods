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
    [Activity(Label = "Skin Effect Calculator")]
    public class SkinEffectActivity : BaseActivity
    {
        public SkinEffectActivity() : base(Resource.Layout.skin_effect_layout)
        {
            Loaded += delegate
            {
                //
                var tbFrequency = FindViewById<EditText>(Resource.Id.tb_frequency);
                var tbResitivity = FindViewById<EditText>(Resource.Id.tb_resistivity);
                var tbPermeability = FindViewById<EditText>(Resource.Id.tb_permeability);
                var lbOutput = FindViewById<TextView>(Resource.Id.lb_output);

                FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                {
                    if (double.TryParse(tbPermeability.Text, out var pm) &&
                        double.TryParse(tbFrequency.Text, out var freq) &&
                        double.TryParse(tbResitivity.Text, out var resistivity))
                    {
                        double a = Math.PI * pm * freq;
                        var SkinDepth = resistivity / a;
                        var b = Math.Sqrt(SkinDepth);
                        lbOutput.Text = b.ToString();
                    }
                    else
                    {
                        ToastHelpers.ShowRequiredInputs(this);
                    }




                };
            };
        }

    }
}