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
    [Activity(Label = "Newton Raphson")]
    public class NewtonRaphsonActivity : BaseActivity
    {
        public NewtonRaphsonActivity():base(Resource.Layout.newton_raphson_layout)
        {
            Loaded += delegate
            {
                //
                var tbA = FindViewById<EditText>(Resource.Id.tb_a);
                var tbB = FindViewById<EditText>(Resource.Id.tb_b);
                var tbC = FindViewById<EditText>(Resource.Id.tb_c);
                var tbD = FindViewById<EditText>(Resource.Id.tb_d);
                var lbX1 = FindViewById<TextView>(Resource.Id.lb_x1);
                var lbX2 = FindViewById<TextView>(Resource.Id.lb_x2);
                var lbX3 = FindViewById<TextView>(Resource.Id.lb_x3);

                FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                {
                    if(double.TryParse(tbA.Text, out var a) && double.TryParse(tbB.Text, out var b) && 
                        double.TryParse(tbC.Text, out var c) && double.TryParse(tbD.Text, out var d))
                    {
                        double x = 1;
                        double y1 = 3 * a * x * x + 2 * b * x + c;

                        if (y1 == 0)
                        {

                            x = x + 0.5;
                            y1 = 3 * a * x * x + 2 * b * x + c;
                        }

                        int i = 0;

                        double y2 = a * x * x * x + b * x * x + c * x + d;
                        double y = x - y2 / y1;
                        while (x != y && i != 100)
                        {
                            i = i + 1;
                            x = y;
                            y1 = 3 * a * x * x + 2 * b * x + c;
                            y2 = a * x * x * x + b * x * x + c * x + d;
                            y = x - y2 / y1;

                        }
                        double xo = x;

                        double x1 = -1;
                        x = x1;
                        y1 = 3 * a * x * x + 2 * b * x + c;

                        if (y1 == 0)
                        {

                            x = x + 0.5;
                            y1 = 3 * a * x * x + 2 * b * x + c;
                        }
                        int i1 = 0;

                        y2 = a * x * x * x + b * x * x + c * x + d;
                        y = x - y2 / y1;
                        while (x != y && i1 != 100)
                        {
                            i = i1 + 1;
                            x = y;

                            y1 = 3 * a * x * x + 2 * b * x + c;
                            y2 = a * x * x * x + b * x * x + c * x + d;
                            y = x - y2 / y1;

                        }

                        x1 = x;



                        double x2 = 15;
                        x = x2;
                        y1 = 3 * a * x * x + 2 * b * x + c;

                        if (y1 == 0)
                        {
                            x = x + 0.5;
                            y1 = 3 * a * x * x + 2 * b * x + c;
                        }
                        int i2 = 0;

                        y2 = a * x * x * x + b * x * x + c * x + d;
                        y = x - y2 / y1;
                        while (x != y && i2 != 100)
                        {
                            i = i + 1;
                            x = y;
                            y1 = 3 * a * x * x + 2 * b * x + c;
                            y2 = a * x * x * x + b * x * x + c * x + d;
                            y = x - y2 / y1;
                        }

                        x2 = x;

                        //
                        lbX1.Text = xo.ToString();

                        if (x1 != xo && x1 != x2)
                            lbX2.Text = x1.ToString();
                        else
                            lbX2.Text = "0";

                        if (x2 != xo && x2 != x1)
                            lbX3.Text = x2.ToString();
                        else
                            lbX3.Text = "0";

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