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
    [Activity(Label = "DC Analysis")]
    public class DCCalcActivity : BaseActivity
    {
        [Activity(Label = "DC Current Calculator")]
        class CurrentCalcActivity : BaseActivity
        {
            public CurrentCalcActivity() : base(Resource.Layout.dc_current_calc_layout)
            {
                Loaded += delegate
                {
                    var tbPower = FindViewById<EditText>(Resource.Id.tb_p);
                    var tbVoltage = FindViewById<EditText>(Resource.Id.tb_v);
                    var tbResistance = FindViewById<EditText>(Resource.Id.tb_r);
                    var lbOutput = FindViewById<TextView>(Resource.Id.lb_output);

                    FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                    {
                        var hasP = double.TryParse(tbPower.Text, out double p);
                        var hasVoltage = double.TryParse(tbVoltage.Text, out double v);
                        var hasResistance = double.TryParse(tbResistance.Text, out double r);

                        //
                        double current = 0;
                        if (hasVoltage && hasResistance)
                        {
                            current = v / r;
                        }
                        else if (hasP && hasVoltage)
                        {
                            current = p / v;
                        }
                        else if (hasP && hasResistance)
                        {
                            current = Math.Sqrt(p / r);
                        }
                        else
                        {
                            Toast.MakeText(this, "Enter required input pair V,R or P,V or P,R", ToastLength.Short).Show();
                            return;
                        }

                        //
                        lbOutput.Text = current.ToString();

                    };
                };
            }
        }

        [Activity(Label = "DC Power Calculator")]
        class PowerCalcActivity : BaseActivity
        {
            public PowerCalcActivity() : base(Resource.Layout.dc_power_calc_layout)
            {
                Loaded += delegate
                {
                    var tbV = FindViewById<EditText>(Resource.Id.tb_v);
                    var tbI = FindViewById<EditText>(Resource.Id.tb_i);
                    var tbR = FindViewById<EditText>(Resource.Id.tb_r);
                    var lbOutput = FindViewById<TextView>(Resource.Id.lb_output);

                    FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                    {
                        var hasV = double.TryParse(tbV.Text, out double v);
                        var hasI = double.TryParse(tbI.Text, out double i);
                        var hasR = double.TryParse(tbR.Text, out double r);

                        double power = 0;
                        if (hasV && hasR)
                        {
                            power = v * v / r;
                        }
                        else if (hasI && hasR)
                        {
                            power = i * i * r;
                        }
                        else if (hasV && hasI)
                        {
                            power = v * i;
                        }
                        else
                        {
                            Toast.MakeText(this, "Enter required input pair V,R or I,R or V,I", ToastLength.Short).Show();
                            return;
                        }

                        lbOutput.Text = power.ToString();
                    };
                };
            }

        }

        [Activity(Label = "DC Voltage Calculator")]
        class VoltageCalcActivity : BaseActivity
        {
            public VoltageCalcActivity() : base(Resource.Layout.dc_voltage_calc_layout)
            {
                Loaded += delegate
                {
                    var tbP = FindViewById<EditText>(Resource.Id.tb_p);
                    var tbI = FindViewById<EditText>(Resource.Id.tb_i);
                    var tbR = FindViewById<EditText>(Resource.Id.tb_r);
                    var lbOutput = FindViewById<TextView>(Resource.Id.lb_output);

                    FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                    {
                        var hasP = double.TryParse(tbP.Text, out double p);
                        var hasI = double.TryParse(tbI.Text, out double i);
                        var hasR = double.TryParse(tbR.Text, out double r);

                        double voltage = 0;

                        if (hasP && hasR)
                        {
                            voltage = Math.Sqrt(p * r);
                        }
                        else if (hasI && hasR)
                        {
                            voltage = i * r;
                        }
                        else if (hasP && hasI)
                        {
                            voltage = p / i;
                        }
                        else
                        {
                            Toast.MakeText(this, "Enter required input pair P,R or I,R or P,I", ToastLength.Short).Show();
                            return;
                        }

                        lbOutput.Text = voltage.ToString();
                    };
                };
            }


        }

        [Activity(Label = "DC Resistance Calculator")]
        class ResistanceCalcActivity : BaseActivity
        {
            public ResistanceCalcActivity() : base(Resource.Layout.dc_resistance_calc_layout)
            {
                Loaded += delegate
                {
                    var tbP = FindViewById<EditText>(Resource.Id.tb_p);
                    var tbI = FindViewById<EditText>(Resource.Id.tb_i);
                    var tbV = FindViewById<EditText>(Resource.Id.tb_v);
                    var lbOutput = FindViewById<TextView>(Resource.Id.lb_output);

                    FindViewById<Button>(Resource.Id.btn_evaluate).Click += delegate
                    {
                        var hasP = double.TryParse(tbP.Text, out double p);
                        var hasI = double.TryParse(tbI.Text, out double i);
                        var hasV = double.TryParse(tbV.Text, out double v);

                        double resistance = 0;
                        if (hasV && hasP)
                        {
                            resistance = v * v / p;
                        }
                        else if (hasI && hasP)
                        {
                            resistance = p / (i * i);
                        }
                        else if (hasV && hasI)
                        {
                            resistance = v / i;
                        }
                        else
                        {
                            Toast.MakeText(this, "Enter required input pairs I,P or V,P or V,I", ToastLength.Short).Show();
                            return;
                        }

                        lbOutput.Text = resistance.ToString();
                    };

                };
            }

        }

        public DCCalcActivity() : base(Resource.Layout.dc_analysis_layout)
        {
            Loaded += delegate
            {
                //
                FindViewById<Button>(Resource.Id.btn_dc_current_calc).Click += delegate
                {
                    StartActivity(typeof(CurrentCalcActivity));
                };

                FindViewById<Button>(Resource.Id.btn_dc_power_calc).Click += delegate
                {
                    StartActivity(typeof(PowerCalcActivity));
                };

                FindViewById<Button>(Resource.Id.btn_dc_voltage_calc).Click += delegate
                {
                    StartActivity(typeof(VoltageCalcActivity));
                };

                FindViewById<Button>(Resource.Id.btn_dc_resistance_calc).Click += delegate
                {
                    StartActivity(typeof(ResistanceCalcActivity));
                };
            };
        }

    }
}