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
    [Activity(Label = "Capacitive Reactance And Capacitance", WindowSoftInputMode = SoftInput.AdjustNothing)]
    public class CapacitiveReactanceActivity : BaseActivity
    {
        public CapacitiveReactanceActivity() : base(Resource.Layout.capacitive_reactance_layout)
        {
            Loaded += delegate
            {
                //
                var tbCapacitanceFreq = FindViewById<EditText>(Resource.Id.tb_capacitive_freq);
                var tbCapCapacitance = FindViewById<EditText>(Resource.Id.tb_capacitive_capacitance);
                var lbCapacitanceOut = FindViewById<TextView>(Resource.Id.lb_capacitance_out);

                //
                var tbInductiveFreq = FindViewById<EditText>(Resource.Id.tb_inductive_freq);
                var tbInductiveInductance = FindViewById<EditText>(Resource.Id.tb_inductive_inductance);
                var lbInductanceOut = FindViewById<TextView>(Resource.Id.lb_inductance_out);

                //
                FindViewById<Button>(Resource.Id.btn_evaluate_capacitance).Click += delegate
                {
                    if (double.TryParse(tbCapacitanceFreq.Text, out var freq) && double.TryParse(tbCapCapacitance.Text, out var cap))
                    {
                        lbCapacitanceOut.Text = (1.0 / (2.0 * Math.PI * freq * cap)).ToString();
                    }
                    else
                    {
                        ToastHelpers.ShowRequiredInputs(this);
                    }
                };

                FindViewById<Button>(Resource.Id.btn_evaluate_reactance).Click += delegate
                {
                    if (double.TryParse(tbInductiveFreq.Text, out var freq) && double.TryParse(tbInductiveInductance.Text, out var inductance))
                    {
                        lbInductanceOut.Text = (2.0 * Math.PI * freq * inductance).ToString();
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