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

namespace NumericalMethodsApp
{
    [Activity(Label = "Unit Conversions")]
    public class UnitConversionsActivity : BaseActivity
    {
        public UnitConversionsActivity() : base(Resource.Layout.unit_conversions_layout)
        {
            Loaded += delegate
            {
                var spinner = FindViewById<Spinner>(Resource.Id.conversions_spinner);
                var tbInput = FindViewById<EditText>(Resource.Id.tb_input);
                var lbOutput = FindViewById<TextView>(Resource.Id.lb_output);

                spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, new string[]
                {
                    "W to dBW",
                    "dbW to w",
                    "W to mW",
                    "mW to W",
                    "W to dBm",
                    "dBm to W",
                    "Feet to m",
                    "m to Feet",
                    "Inches to Meters",
                    "Meters to Inches"
                });

                double Convert(int choice, double value)
                {

                    if (choice == 1)
                    {
                        value = 10 * Math.Log10(value);
                    }

                    if (choice == 2)
                    {
                        double dbw = value / 10;
                        value = Math.Pow(10, dbw);
                    }

                    if (choice == 3)
                    {
                        value = value * 1000;
                    }

                    if (choice == 4)
                    {
                        value = value / 1000;
                    }

                    if (choice == 5)
                    {
                        value = 10 * Math.Log10(value) + 30;
                    }

                    if (choice == 6)
                    {
                        double dbm = value / 10;

                        value = Math.Pow(10, dbm);
                        value = value / 1000;
                    }

                    if (choice == 7)
                    {                //7.feet to m
                        value = value * 0.3048;
                    }

                    if (choice == 8)
                    {
                        value = value / 0.3048;
                    }

                    if (choice == 9)
                    {
                        value = value * 0.0254;
                    }

                    if (choice == 10)
                    {
                        value = value / 0.0254;
                    }


                    return value;

                }

                void UpdateConversion()
                {
                    if (double.TryParse(tbInput.Text, out double val))
                        lbOutput.Text = Convert(spinner.SelectedItemPosition + 1, val).ToString("F4");
                    else
                        lbOutput.Text = "0";
                }

                spinner.ItemSelected += (s, e) =>
                {
                    UpdateConversion();
                };

                //
                tbInput.TextChanged += (s, e) =>
                {
                    UpdateConversion();
                };

            };
        }
    }
}