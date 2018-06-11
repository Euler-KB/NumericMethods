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
    [Activity(Label = "Simulataneous Equations")]
    public class SimultaneousEquationActivity : BaseActivity
    {
        public SimultaneousEquationActivity() : base(Resource.Layout.simultaneous_equation_layout)
        {
            Loaded += delegate
            {
                //
                var tbA = FindViewById<EditText>(Resource.Id.tb_a);
                var tbB = FindViewById<EditText>(Resource.Id.tb_b);
                var tbC = FindViewById<EditText>(Resource.Id.tb_c);
                var tbD = FindViewById<EditText>(Resource.Id.tb_d);
                var tbE = FindViewById<EditText>(Resource.Id.tb_e);
                var tbF = FindViewById<EditText>(Resource.Id.tb_f);
                var lbX = FindViewById<TextView>(Resource.Id.lb_output_x);
                var lbY = FindViewById<TextView>(Resource.Id.lb_output_y);

                //
                FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                {
                    if (double.TryParse(tbA.Text, out var a) &&
                        double.TryParse(tbB.Text, out var b) &&
                        double.TryParse(tbC.Text, out var c) &&
                        double.TryParse(tbD.Text, out var d) &&
                        double.TryParse(tbE.Text, out var e) &&
                        double.TryParse(tbF.Text, out var f))
                    {
                        //
                        double y = ((a * f) - (d * c)) / ((a * e) - (b * d));
                        double x = (c - (b * y)) / a;

                        lbX.Text = x.ToString("N");
                        lbY.Text = y.ToString("N");
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