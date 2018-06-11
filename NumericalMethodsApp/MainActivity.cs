using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using NumericalMethodsApp.Helpers;
using Android.Graphics;
using System;
using Android.Runtime;
using System.Collections.Generic;
using System.Reflection;

[assembly: Application(Label = "Numerical Methods", Theme = "@style/Theme.Default")]
namespace NumericalMethodsApp
{
    [Activity(Label = "Numerical Methods", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        class DisplayView
        {
            public int Id { get; set; }

            public Type ActivityType { get; set; }

            public string Name { get; set; }

            public View View { get; set; }

            public DisplayView(Type activity, int viewId)
            {
                ActivityType = activity;
                Id = viewId;
                Name = activity.GetCustomAttribute<ActivityAttribute>()?.Label;
            }

            public DisplayView(Type activity, int viewId, string name)
            {
                ActivityType = activity;
                Id = viewId;
                Name = name;
            }

            public DisplayView() { }

            public View BindView(Activity root)
            {
                if (View == null)
                    View = root.FindViewById(Id);

                return View;
            }

        }

        static List<DisplayView> DisplayItems = new List<DisplayView>()
        {
            new DisplayView(typeof(GregoryNetwonActivity), Resource.Id.btn_gregory_newton ),
            new DisplayView(typeof(LangrangeInterpActivity), Resource.Id.btn_langrange_interp ),
            new DisplayView(typeof(SimultaneousEquationActivity), Resource.Id.btn_simultaneous_eqn),
            new DisplayView(typeof(CapacitiveReactanceActivity), Resource.Id.btn_capacitance_calculator),
            new DisplayView(typeof(PowerDensityCalculatorActivity), Resource.Id.btn_power_density),
            new DisplayView(typeof(ResistanceCalculatorActivity),Resource.Id.btn_resistance_calculator),
            new DisplayView(typeof(EngineeringConstantsActivity),Resource.Id.btn_engineering_constants),
            new DisplayView(typeof(SkinEffectActivity),Resource.Id.btn_skin_effect),
            new DisplayView(typeof(DCCalcActivity) , Resource.Id.btn_dc_analysis),
            new DisplayView(typeof(RadarRangeActivity),Resource.Id.btn_radar_range),
            new DisplayView(typeof(NewtonRaphsonActivity),Resource.Id.btn_newton_raphson),
            new DisplayView(typeof(UnitConversionsActivity),Resource.Id.btn_unit_conversions)
        };

        static MainActivity()
        {

#if DEBUG
            void HandleException(Exception ex)
            {
                new Android.Support.V7.App.AlertDialog.Builder(Application.Context, Resource.Style.Base_Animation_AppCompat_Dialog)
                    .SetTitle("Unhandled Exception")
                    .SetMessage(ex.ToString())
                    .SetPositiveButton("OK", delegate { })
                    .Show();
            }

            System.AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                HandleException(e.ExceptionObject as Exception);
            };

            AndroidEnvironment.UnhandledExceptionRaiser += (s, e) =>
            {
                HandleException(e.Exception);
                e.Handled = true;
            };
#endif

        }

        private SearchView searchView;

        private TextView lbNoSearchResults;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);

            //
            this.SetupToolbar(true);

            //
            if (!UserPreferences.ShowWelcomeTip)
            {
                var dlg = new Android.Support.V7.App.AlertDialog.Builder(this)
                    .SetTitle("Welcome")
                    .SetMessage(Resource.String.WelcomeMessage)
                    .SetPositiveButton("Thanks", delegate { })
                    .Show();

                dlg.DismissEvent += delegate
                {
                    UserPreferences.ShowWelcomeTip = true;
                };
            }

            //
            lbNoSearchResults = FindViewById<TextView>(Resource.Id.lb_no_search_results);

            //
            foreach (var item in DisplayItems)
                item.BindView(this).Click += delegate
                {
                    StartActivity(item.ActivityType);
                };

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //
            MenuInflater.Inflate(Resource.Menu.actions_main, menu);

            //
            var searchMenu = menu.FindItem(Resource.Id.app_bar_search);
            searchView = searchMenu.ActionView as SearchView;
            searchView.Iconified = true;

            //
            searchView.QueryTextChange += delegate { OnSearchItem(); };
            searchView.QueryTextSubmit += delegate { OnSearchItem(); };
            searchView.Close += (s, e) =>
            {
                OnClearSearch();
                e.Handled = false;
            };

            return base.OnCreateOptionsMenu(menu);
        }

        private void OnSearchItem()
        {
            var query = searchView.Query;
            if (string.IsNullOrEmpty(query))
            {
                OnClearSearch();
                return;
            }

            bool anyVisible = false;
            foreach (var item in DisplayItems)
            {
                var visibility = (item.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ? ViewStates.Visible : ViewStates.Gone;
                item.View.Visibility = visibility;

                if (visibility == ViewStates.Visible && !anyVisible)
                    anyVisible = true;

            }

            lbNoSearchResults.Visibility = anyVisible ? ViewStates.Gone : ViewStates.Visible;
        }

        private void OnClearSearch()
        {
            foreach (var item in DisplayItems)
                item.View.Visibility = ViewStates.Visible;

            //
            lbNoSearchResults.Visibility = ViewStates.Gone;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_about)
            {
                new Android.Support.V7.App.AlertDialog.Builder(this)
                    .SetTitle("About Numerical Methods")
                    .SetMessage(Resource.String.AboutMessage)
                    .SetPositiveButton("OK", delegate { })
                    .Show();

                return true;
            }
            else if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}

