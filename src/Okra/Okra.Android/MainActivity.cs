﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism;
using Prism.Ioc;
using Okra.Services;
using Okra.Droid.Services;
using Xamarin.Forms;

namespace Okra.Droid
{
    [Activity(Label = "Okra", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FormsMaterial.Init(this, savedInstanceState);
            LoadApplication(new App(new AndroidPlatformInitializer()));
        }
    }

    public class AndroidPlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDataBaseAccessService, DataBaseAccessService>();
        }
    }
}