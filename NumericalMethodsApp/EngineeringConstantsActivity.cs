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
    [Activity(Label = "Engineering Constants")]
    public class EngineeringConstantsActivity : BaseActivity
    {
        class Constant
        {
            public string Name { get; set; }

            public string Value { get; set; }

            public Constant()
            {

            }

            public Constant(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }

        static readonly IList<Constant> Constants = new List<Constant>()
        {
            new Constant("Permeability","4π × 10^(−7) Tm/A"),
            new Constant("Boltzmann's constant", "1.380649 × 10^(−23) J/K"),
            new Constant("Permittivity of free space", "8.85×10−12 F/m"),
            new Constant("Planck’s constant","6.625 x 10-34 J · s/molecule"),
            new Constant("Speed of Light in Vacuum", "2.998 x 108 m/s" )
        };

        class ConstantsAdapter : BaseAdapter<Constant>
        {

            public override Constant this[int position] => Constants[position];

            public override int Count => Constants.Count;

            public override long GetItemId(int position) => position;

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                if (convertView == null)
                    convertView = LayoutInflater.From(parent.Context).Inflate(Android.Resource.Layout.SimpleListItem2, parent, false);

                var item = Constants[position];
                convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;
                convertView.FindViewById<TextView>(Android.Resource.Id.Text2).Text = item.Value;

                return convertView;

            }
        }

        public EngineeringConstantsActivity() : base(Resource.Layout.engineering_constants_layout)
        {
            Loaded += delegate
            {
                var listView = FindViewById<ListView>(Resource.Id.lv_constants);
                listView.Adapter = new ConstantsAdapter();
                listView.ItemClick += (s, e) =>
                {
                    var item = Constants[e.Position];

                    new Android.Support.V7.App.AlertDialog.Builder(this)
                        .SetTitle(item.Name)
                        .SetMessage(item.Value)
                        .SetPositiveButton("OK", delegate { })
                        .Show();

                };
            };
        }

        
    }
}