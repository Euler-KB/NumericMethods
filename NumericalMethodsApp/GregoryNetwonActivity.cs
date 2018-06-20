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
    [Activity(Label = "Gregory Newton Interpolation")]
    public class GregoryNetwonActivity : BaseActivity
    {
        public GregoryNetwonActivity() : base(Resource.Layout.gregory_newton_layout)
        {
            Loaded += delegate
            {
                //
                var tbA1 = FindViewById<EditText>(Resource.Id.tbA1);
                var tbA2 = FindViewById<EditText>(Resource.Id.tbA2);
                var tbA3 = FindViewById<EditText>(Resource.Id.tbA3);
                var tbA4 = FindViewById<EditText>(Resource.Id.tbA4);
                var tbA5 = FindViewById<EditText>(Resource.Id.tbA5);
                var tbA6 = FindViewById<EditText>(Resource.Id.tbA6);
                var tbA7 = FindViewById<EditText>(Resource.Id.tbA7);

                var tbX1 = FindViewById<EditText>(Resource.Id.tbX1);
                var tbX2 = FindViewById<EditText>(Resource.Id.tbX2);
                var tbX3 = FindViewById<EditText>(Resource.Id.tbX3);
                var tbX4 = FindViewById<EditText>(Resource.Id.tbX4);
                var tbX5 = FindViewById<EditText>(Resource.Id.tbX5);
                var tbX6 = FindViewById<EditText>(Resource.Id.tbX6);
                var tbX7 = FindViewById<EditText>(Resource.Id.tbX7);

                var tbXP = FindViewById<EditText>(Resource.Id.tbXP);

                var lbAnswer = FindViewById<TextView>(Resource.Id.lb_output);

                FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                {
                    double.TryParse(tbX1.Text, out var x1);
                    double.TryParse(tbX2.Text, out var x2);
                    double.TryParse(tbX3.Text, out var x3);
                    double.TryParse(tbX4.Text, out var x4);
                    double.TryParse(tbX5.Text, out var x5);
                    double.TryParse(tbXP.Text, out var xp);

                    bool hasX6 = double.TryParse(tbX6.Text, out var x6);
                    bool hasX7 = double.TryParse(tbX7.Text, out var x7);

                    double.TryParse(tbA1.Text, out var a1);
                    double.TryParse(tbA2.Text, out var a2);
                    double.TryParse(tbA3.Text, out var a3);
                    double.TryParse(tbA4.Text, out var a4);
                    double.TryParse(tbA5.Text, out var a5);
                    bool hasA6 = double.TryParse(tbA6.Text, out var a6);
                    bool hasA7 = double.TryParse(tbA7.Text, out var a7);

                    if (!hasX6 || !hasX7)
                        x6 = 0;

                    if (!hasA6)
                        a6 = 0;

                    if (!hasA7)
                        a7 = 0;

                    //    'variables for the diference table
                    //'declear the following variables
                    double b1, b2, b3, b4, b5, b6;
                    double c1, c2, c3, c4, c5;
                    double d1, d2, d3, d4;
                    double e1, e2, e3;
                    double f1, f2;
                    double g1;


                    //'constructing a diference table
                    b1 = a2 - a1;
                    b2 = a3 - a2;
                    b3 = a4 - a3;
                    b4 = a5 - a4;
                    b5 = a6 - a5;
                    b6 = a7 - a6;



                    // If x7 <= x6 And x6 = Nothing Then
                    if (x6 <= x7 && x7 == 0)
                    {
                        b5 = 0;
                    }

                    if (x7 == 0)
                    {

                        b6 = 0;
                    }

                    c1 = b2 - b1;
                    c2 = b3 - b2;
                    c3 = b4 - b3;
                    c4 = b5 - b4;
                    c5 = b6 - b5;

                    if (x6 <= x7 && x7 == 0)
                    {
                        c4 = 0;
                    }
                    if (x7 == 0)
                    {
                        c5 = 0;
                    }

                    d1 = c2 - c1;
                    d2 = c3 - c2;
                    d3 = c4 - c3;
                    d4 = c5 - c4;
                    if (x6 <= x7 && x7 == 0)
                    {
                        b3 = 0;
                    }
                    if (x7 == 0)
                    {
                        d4 = 0;
                    }

                    e1 = d2 - d1;
                    e2 = d3 - d2;
                    e3 = d4 - d3;

                    if (x6 <= x7 && x7 == 0)
                    {
                        e2 = 0;
                    }
                    if (x7 == -0)
                    {
                        e3 = 0;
                    }
                    f1 = e2 - e1;
                    f2 = e3 - e2;
                    if (x6 <= x7 && x7 == 0)
                    {
                        f1 = 0;
                    }
                    if (x7 == 0)
                    {
                        f2 = 0;
                    }


                    g1 = f2 - f1;


                    if (x6 <= x7 && x7 == 0)
                    {
                        g1 = 0;
                    }

                    double A, B, C, D, P, F;

                    double Aa, Bb, Cc, Dd, Ee, Ff, Gg, G, answer;

                    if (xp > x1 && xp < x2)
                    {
                        P = (xp - x1) / (x2 - x1);
                        A = P - 1;
                        B = P - 2;
                        C = P - 3;
                        D = P - 4;
                        F = P - 5;

                        Aa = a1;
                        Bb = P * b1;
                        Cc = (P * A * c1) / 2;
                        Dd = (P * A * B * d1) / 6;
                        Ee = (P * A * B * C * e1) / 24;
                        Ff = (P * A * B * C * D * f1) / 120;
                        Gg = (P * A * B * C * D * F * g1) / 720;
                        answer = Aa + Bb + Cc + Dd + Ee + Ff + Gg;
                        lbAnswer.Text = $"Answer: {answer}";
                    }



                    if (xp > x2 && xp < x3)
                    {

                        P = (xp - x2) / (x3 - x2);
                        A = P - 1;
                        B = P - 2;
                        C = P - 3;
                        D = P - 4;
                        F = P - 5;

                        Aa = a2;
                        Bb = P * b2;
                        Cc = (P * A * c2) / 2;
                        Dd = (P * A * B * d2) / 6;
                        Ee = (P * A * B * C * e2) / 24;
                        Ff = (P * A * B * C * D * f2) / 120;


                        answer = Aa + Bb + Cc + Dd + Ee + Ff;
                        lbAnswer.Text = $"Answer: {answer}";
                    }

                    if (xp > x6 && xp < x7)
                    {

                        P = (xp - x6) / (x7 - x6);
                        A = P + 1;
                        B = P + 2;
                        C = P + 3;
                        D = P + 4;
                        F = P + 5;

                        Aa = a6;
                        Bb = P * b5;
                        Cc = (P * A * c4) / 2;
                        Dd = (P * A * B * d3) / 6;
                        Ee = (P * A * B * C * e2) / 24;
                        Ff = (P * A * B * C * D * f1) / 120;

                        answer = Aa + Bb + Cc + Dd + Ee + Ff;
                        lbAnswer.Text = $"Answer: {answer}";
                    }


                    if (xp > x5 && xp < x6)
                    {

                        P = (xp - x5) / (x6 - x5);
                        A = P + 1;
                        B = P + 2;
                        C = P + 3;
                        D = P + 4;
                        F = P + 5;

                        Aa = a5;
                        Bb = P * b4;
                        Cc = (P * A * c3) / 2;
                        Dd = (P * A * B * d3) / 6;
                        Ee = (P * A * B * C * d2) / 24;
                        Ff = (P * A * B * C * D * e1) / 120;

                        answer = Aa + Bb + Cc + Dd + Ee + Ff;
                        lbAnswer.Text = $"Answer: {answer}";
                    }



                    if (xp > x4 && xp < x5)
                    {
                        P = (xp - x4) / (x5 - x4);
                        A = P - 1;
                        B = P + 1;
                        C = P - 2;
                        D = P + 2;
                        F = P - 3;
                        G = P + 3;

                        Aa = a4;
                        Bb = P * b4;
                        Cc = (P * A * c3) / 2;
                        Dd = (P * A * B * d3) / 6;
                        Ee = (P * A * B * C * e2) / 24;
                        Ff = (P * A * B * C * D * F * f2) / 120;
                        Gg = (P * A * B * C * D * F * G * g1) / 720;


                        answer = Aa + Bb + Cc + Dd + Ee + Ff + Gg;
                        lbAnswer.Text = $"Answer: {answer}";

                    }

                    if (xp > x3 && xp < x4)
                    {
                        P = (xp - x3) / (x4 - x3);
                        A = P - 1;
                        B = P + 1;
                        C = P - 2;
                        D = P + 2;
                        F = P - 3;
                        G = P + 3;

                        Aa = a3;
                        Bb = P * b3;
                        Cc = (P * A * c2) / 2;
                        Dd = (P * A * B * d2) / 6;
                        Ee = (P * A * B * C * e1) / 24;
                        Ff = (P * A * B * C * D * F * f1) / 120;

                        answer = Aa + Bb + Cc + Dd + Ee + Ff;
                        lbAnswer.Text = $"Answer: {answer}";
                    }


                };

            };
        }

    }
}