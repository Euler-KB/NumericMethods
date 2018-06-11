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
    public static class UserPreferences
    {
        static class Keys
        {
            public const string WelcomeMessage = "welcome_tip";
        }

        static ISharedPreferences _preferences;

        static UserPreferences()
        {
            _preferences = Application.Context.GetSharedPreferences("_default", FileCreationMode.Private);
        }

        public static T Get<T>(string key)
        {
            var type = typeof(T);
            object value = default(T);
            if (type == typeof(int))
            {
                value = _preferences.GetInt(key, -1);
            }
            else if (type == typeof(string))
            {
                value = _preferences.GetString(key, "");
            }
            else if (type == typeof(bool))
            {
                value = _preferences.GetBoolean(key, false);
            }

            return (T)value;
        }

        public static void Set<T>(string key, T value)
        {
            var editor = _preferences.Edit();
            Set(editor, key, value);
            editor.Commit();
        }

        static void Set<T>(ISharedPreferencesEditor editor, string key, T value)
        {
            var type = typeof(T);
            if (type == typeof(int))
            {
                editor.PutInt(key, (int)(object)value);
            }
            else if (type == typeof(string))
            {
                editor.PutString(key, value.ToString());
            }
            else if (type == typeof(bool))
            {
                editor.PutBoolean(key, (bool)(object)value);
            }
        }

        public static bool Contains(string key)
        {
            return _preferences.Contains(key);
        }

        public static bool ShowWelcomeTip
        {
            get
            {
                if (Contains(Keys.WelcomeMessage))
                    return Get<bool>(Keys.WelcomeMessage);

                return false;
            }

            set
            {
                Set<bool>(Keys.WelcomeMessage, value);
            }
        }


    }
}