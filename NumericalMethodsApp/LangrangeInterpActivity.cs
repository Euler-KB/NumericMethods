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
        [Activity(Label = "Langrange Interpolation (Two Points) ")]
        class LangrangeTwoPtsActivity : BaseActivity
        {
            public LangrangeTwoPtsActivity() : base(Resource.Layout.langrange_2pts_layout)
            {
                Loaded += delegate
                {
                    //
                    var tbX1 = FindViewById<EditText>(Resource.Id.tbX1);
                    var tbX2 = FindViewById<EditText>(Resource.Id.tbX2);
                    var tbY1 = FindViewById<EditText>(Resource.Id.tbY1);
                    var tbY2 = FindViewById<EditText>(Resource.Id.tbY2);
                    var tbXP = FindViewById<EditText>(Resource.Id.tbXP);

                    var lbOutput = FindViewById<TextView>(Resource.Id.lb_output);

                    //
                    FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                    {
                        double a, b, x, y, z, Answer;
                        a = double.Parse(tbX1.Text);
                        b = double.Parse(tbX2.Text);
                        x = double.Parse(tbXP.Text);
                        y = double.Parse(tbY1.Text);
                        z = double.Parse(tbY2.Text);

                        Answer = ((b * y) - (a * y) + (a * z) - (b * z)) / ((a - b) * (b - a)) + ((-b * b * y) + (a * b * y - a * a * z) + (a * b * z)) / ((a - b) * (b - a));

                        double An = ((b * y) - (a * y) + (a * z) - (b * z)) / ((a - b) * (b - a));

                        double An2 = ((-b * b * y) + (a * b * y - a * a * z) + (a * b * z)) / ((a - b) * (b - a));

                        Answer = x * An + An2;

                        lbOutput.Text = Answer.ToString();

                    };
                };
            }
        }

        [Activity(Label = "Langrange Interpolation (Three Points)")]
        class LangrangeThreePtsActivity : BaseActivity
        {
            public LangrangeThreePtsActivity() : base(Resource.Layout.langrange_3pts_layout)
            {
                Loaded += delegate
                {
                    //
                    var tbX1 = FindViewById<EditText>(Resource.Id.tbX1);
                    var tbX2 = FindViewById<EditText>(Resource.Id.tbX2);
                    var tbX3 = FindViewById<EditText>(Resource.Id.tbX3);

                    var tbY1 = FindViewById<EditText>(Resource.Id.tbY1);
                    var tbY2 = FindViewById<EditText>(Resource.Id.tbY2);
                    var tbY3 = FindViewById<EditText>(Resource.Id.tbY3);
                    var tbXP = FindViewById<EditText>(Resource.Id.tbXP);


                    var lbOutput = FindViewById<TextView>(Resource.Id.lb_output);

                    FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                    {
                        double.TryParse(tbX1.Text, out double a);
                        double.TryParse(tbX2.Text, out double b);
                        double.TryParse(tbX3.Text, out double c);

                        double.TryParse(tbY1.Text, out double m);
                        double.TryParse(tbY2.Text, out double y);
                        double.TryParse(tbY3.Text, out double z);
                        double.TryParse(tbXP.Text, out double Q);

                        //
                        var XX = ((Q - b) * (Q - c) * m) / ((a - b) * (a - c));
                        var X = ((Q - a) * (Q - c) * y) / ((b - a) * (b - c));
                        var K = ((Q - a) * (Q - b) * z) / ((c - a) * (c - b));
                        var answer = XX + X + K;
                        lbOutput.Text = answer.ToString();

                    };
                };
            }
        }

        public LangrangeInterpActivity() : base(Resource.Layout.langrange_interp_layout)
        {
            Loaded += delegate
            {
                FindViewById<Button>(Resource.Id.btn_two_pts).Click += delegate
                {
                    StartActivity(typeof(LangrangeTwoPtsActivity));
                };

                FindViewById<Button>(Resource.Id.btn_three_pts).Click += delegate
                {
                    StartActivity(typeof(LangrangeThreePtsActivity));
                };
            };
        }

    }
}