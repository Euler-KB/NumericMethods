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
    [Activity(Label = "Lagrange Interpolation")]
    public class LangrangeInterpActivity : BaseActivity
    {
        public LangrangeInterpActivity():base(Resource.Layout.langrange_interp_layout)
        {
            Loaded += delegate
            {
                //
                var tbX0 = FindViewById<EditText>(Resource.Id.tbX0);
                var tbX1 = FindViewById<EditText>(Resource.Id.tbX1);
                var tbX2 = FindViewById<EditText>(Resource.Id.tbX2);
                var tbY0 = FindViewById<EditText>(Resource.Id.tbY0);
                var tbY1 = FindViewById<EditText>(Resource.Id.tbY1);
                var tbY2 = FindViewById<EditText>(Resource.Id.tbY2);
                var tbX = FindViewById<EditText>(Resource.Id.tbX);
                var tbXP = FindViewById<EditText>(Resource.Id.tbXP);

                var lbAnswer = FindViewById<TextView>(Resource.Id.lb_answer);
                var lbOut2 = FindViewById<TextView>(Resource.Id.lb_output_2);
                var lbOut3 = FindViewById<TextView>(Resource.Id.lb_output_3);

                //
                FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                {
                    double.TryParse(tbX0.Text, out var a);
                    double.TryParse(tbX1.Text, out var b);
                    bool hasX2 = double.TryParse(tbX2.Text, out var c);

                    double.TryParse(tbY0.Text, out var m);
                    double.TryParse(tbY1.Text, out var y);
                    bool hasY2 = double.TryParse(tbY2.Text, out var z);

                    bool hasXP = double.TryParse(tbXP.Text, out var q);
                    bool hasX = double.TryParse(tbX.Text, out var x);

                    if (hasX2 && hasXP && hasY2)
                    {
                        //  Three data points
                        var XX = y / ((b - a) * (b - c)) + m / ((a - b) * (a - c)) + z / ((c - a) * (c - b));
                        var X = (c * m + b * m) / (a - b) * (a - c) + (c * y + a * y) / (b - a) * (b - c) + (b * z + a * z) / (c - a) * (c - b);
                        var K = ((a * c * m) / (a - b) * (a - c)) + ((a * c * y) / (b - a) * (b - c)) + ((a * b * z) / (c - a) * (c - b));
                        var answer = XX * q * q + X * q + K;

                        lbAnswer.Text = $"F(x) = {answer}";

                    }
                    else
                    {
                        //  Two data points
                        double answer = ((b * y) - (a * y) + (a * z) - (b * z)) / ((a - b) * (b - a)) + ((-b * b * y) + (a * b * y - a * a * z) + (a * b * z)) / ((a - b) * (b - a));
                        double o2 = (((b * y) - (a * y) + (a * z) - (b * z)) / ((a - b) * (b - a)));
                        double o3 = (((-b * b * y) + (a * b * y - a * a * z) + (a * b * z)) / ((a - b) * (b - a)));

                        //
                        lbAnswer.Text = answer.ToString("N");
                        lbOut2.Text = o2.ToString("N");
                        lbOut3.Text = o3.ToString("N");

                    }

                };
            };
        }

    }
}