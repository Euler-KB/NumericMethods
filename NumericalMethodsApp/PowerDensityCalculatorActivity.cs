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
    [Activity(Label = "Power Density Calculator")]
    public class PowerDensityCalculatorActivity : BaseActivity
    {
        public PowerDensityCalculatorActivity() : base(Resource.Layout.power_density_layout)
        {
            Loaded += delegate
            {

                var tbPower = FindViewById<EditText>(Resource.Id.tb_power);
                var tbGain = FindViewById<EditText>(Resource.Id.tb_gain);
                var tbDistance = FindViewById<EditText>(Resource.Id.tb_distance);

                var powerUnitSpinner = FindViewById<Spinner>(Resource.Id.spinner_out_power_unit);
                var gainUnitSpinner = FindViewById<Spinner>(Resource.Id.spinner_gain_unit);
                var distanceSpinner = FindViewById<Spinner>(Resource.Id.spinner_distancer_unit);

                //
                var lbOutput = FindViewById<TextView>(Resource.Id.lb_output);

                //
                powerUnitSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, new string[]
                {
                "mW",
                "dbM",
                "dBW",
                "W"
                });

                gainUnitSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, new string[]
                {
                "Linear"
                });

                distanceSpinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, new string[]
                {
                "Inches",
                "Yards",
                "Miles",
                "Feets",
                "Metres"
                });

                FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                {
                    if (double.TryParse(tbPower.Text, out var pOut) &&
                     double.TryParse(tbDistance.Text, out var D) &&
                     double.TryParse(tbGain.Text, out var gain))
                    {

                        switch (powerUnitSpinner.SelectedItemPosition)
                        {
                            case 0:
                                pOut = pOut / 100.0;
                                break;
                            case 1:
                                pOut = Math.Pow(10, pOut / 10.0) / 1000.0;
                                break;
                            case 2:
                                pOut = Math.Pow(10, pOut / 10.0);
                                break;
                        }

                        switch (distanceSpinner.SelectedItemPosition)
                        {
                            case 0:
                                D = 0.0254 * D;
                                break;
                            case 1:
                                D = 0.9144 * D;
                                break;
                            case 2:
                                D = 1609.344 * D;
                                break;
                            case 3:
                                D = D * 0.3048;
                                break;
                        }

                        //
                        double power = (pOut * gain) / (4 * Math.PI * (D * D));
                        lbOutput.Text = power.ToString();
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