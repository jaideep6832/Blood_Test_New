using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Blood_Test_New
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        List<Tbl_Tests> List_Tests;
        ListView Lv_tests;
        Button btn_create;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            btn_create = FindViewById<Button>(Resource.Id.btn_new_test);

            Lv_tests = FindViewById<ListView>(Resource.Id.lv_tests);


            btn_create.Click += btn_create_Click;

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Blood_Tests.sqlite");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<Tbl_Tests>();
            var data_s = db.Query<Tbl_Tests>("select *  from Tbl_Tests");
            List_Tests = data_s;
            Blood_Test_New.Resources.Adapter_Tests da = new Resources.Adapter_Tests(this, List_Tests);
            Lv_tests.Adapter = da;

        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Login_Activity));
        }
    }
}
