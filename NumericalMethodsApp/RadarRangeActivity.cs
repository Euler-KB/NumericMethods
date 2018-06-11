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
    [Activity(Label = "Radar Range")]
    public class RadarRangeActivity : BaseActivity
    {
        public RadarRangeActivity() : base(Resource.Layout.radar_range_layout)
        {
            Loaded += delegate
            {
                var tbPulsePeakPower = FindViewById<EditText>(Resource.Id.tb_pulse_peak_power);
                var tbMaxPowerGain = FindViewById<EditText>(Resource.Id.tb_max_power_gain);
                var tbAntennaAperture = FindViewById<EditText>(Resource.Id.tb_antenna_aperture);
                var tbCrossSectionArea = FindViewById<EditText>(Resource.Id.tb_cross_section_area);
                var tbPowerReceived = FindViewById<EditText>(Resource.Id.tb_power_received);
                var lbResult = FindViewById<TextView>(Resource.Id.lb_output);

                //
                FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                {
                    if (double.TryParse(tbPulsePeakPower.Text, out var pulsePeakPower) &&
                        double.TryParse(tbMaxPowerGain.Text, out var maxPowerGain) &&
                        double.TryParse(tbAntennaAperture.Text, out var aperture) &&
                        double.TryParse(tbCrossSectionArea.Text, out var crossSectionArea) &&
                        double.TryParse(tbPowerReceived.Text, out var powerReceived))
                    {
                        lbResult.Text = ((pulsePeakPower * maxPowerGain * aperture * crossSectionArea) / (Math.Pow(88.0 / 7.0, 2) * powerReceived)).ToString();
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