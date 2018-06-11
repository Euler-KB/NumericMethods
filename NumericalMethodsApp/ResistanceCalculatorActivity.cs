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
    [Activity(Label = "Resistance Calculator")]
    public class ResistanceCalculatorActivity : BaseActivity
    {
        public ResistanceCalculatorActivity():base(Resource.Layout.resistance_calculator_layout)
        {
            Loaded += delegate
            {
                //
                void SetupSpinner(Spinner spinner, int res)
                {
                    spinner.Adapter = ArrayAdapter.CreateFromResource(this, res, Android.Resource.Layout.SimpleSpinnerDropDownItem);
                }

                var fSpinner = FindViewById<Spinner>(Resource.Id.spinner_first_band);
                SetupSpinner(fSpinner, Resource.Array.ResistorColorStandard);

                var sSpinner = FindViewById<Spinner>(Resource.Id.spinner_second_band);
                SetupSpinner(sSpinner, Resource.Array.ResistorColorStandard);

                var tSpinner = FindViewById<Spinner>(Resource.Id.spinner_third_band);
                SetupSpinner(tSpinner, Resource.Array.ResistorColorStandard);

                var ffSpinner = FindViewById<Spinner>(Resource.Id.spinner_fourth_band);
                SetupSpinner(ffSpinner, Resource.Array.ResistorColorFBand);

                var lbResistance = FindViewById<TextView>(Resource.Id.lb_resistance);
                var lbTolerance = FindViewById<TextView>(Resource.Id.lb_tolerance);

                //
                FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                {
                    int a, b, aa, ab;
                    double c1 = 10;
                    int d2 = 0;

                    a = fSpinner.SelectedItemPosition;              // Accepting input using textbox for FirstBand
                    b = sSpinner.SelectedItemPosition;           //  Accepting input using textbox ThirdBand
                    c1 = tSpinner.SelectedItemPosition;           /// Accepting input using textbox for FourthBand
                    d2 = ffSpinner.SelectedItemPosition;

                    //
                    aa = a * 10;
                    ab = aa + b;
                    double cc = Math.Pow(10, c1);
                    double dd = ab * cc;
                    lbResistance.Text = $"{dd} OHMS";                 // displaying output using label

                    double tolerance = 0;                           // calculating tolerance range
                    if (d2 == 1)
                    {
                        tolerance = 0.01 * dd;
                    }
                    else if (d2 == 2)
                    {
                        tolerance = 0.02 * dd;
                    }
                    else if (d2 == 3)
                    {
                        tolerance = 0.05 * dd;
                    }
                    else if (d2 == 3)
                    {
                        tolerance = 0.01 * dd;
                    }
                    double tolerance1, tolerance2;
                    tolerance1 = dd - tolerance;
                    tolerance2 = dd + tolerance;
                    lbTolerance.Text = $"{tolerance1} - {tolerance2}";
                };

            };
        }

    }
}