using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Blood_Test_New
{
    [Activity(Label = "New_Test_Activity")]
    public class New_Test_Activity : Activity
    {
        List<Tbl_Tests> List_Tests;
        EditText txt_test_name;
        EditText txt_test_range;
        Button btn_save_test;
        Button btn_delete_test;
        Button btn_update_test;
        Button btn_new_test;
        Button btn_home;


        Spinner spinner_tests;
        TextView txt_test_id;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.New_Test_Layout);
            btn_home = FindViewById<Button>(Resource.Id.btn_home);
            btn_save_test = FindViewById<Button>(Resource.Id.btn_save_test);
            btn_delete_test = FindViewById<Button>(Resource.Id.btn_delete_test);

            btn_new_test = FindViewById<Button>(Resource.Id.btn_new_test);
            btn_update_test = FindViewById<Button>(Resource.Id.btn_update_test);
            txt_test_name = FindViewById<EditText>(Resource.Id.txt_test_name);
            txt_test_range = FindViewById<EditText>(Resource.Id.txt_test_range);
            spinner_tests = FindViewById<Spinner>(Resource.Id.spinner_tests);
            txt_test_id = FindViewById<TextView>(Resource.Id.txt_test_id);


            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Blood_Tests.sqlite");
            var db = new SQLiteConnection(dpPath);

            db.CreateTable<Tbl_Tests>();






            load_spiner_tests();

            spinner_tests.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_tests_ItemSelected);

            btn_home.Click += Btn_home_Click;
            btn_save_test.Click += btn_save_test_Click; ;
            btn_new_test.Click += btn_new_test_Click;
            btn_delete_test.Click += btn_delete_test_Click;
            btn_update_test.Click += btn_update_test_Click;


        }

        private void Btn_home_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void btn_delete_test_Click(object sender, EventArgs e)
        {

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Blood_Tests.sqlite");
            var db = new SQLiteConnection(dpPath);


            var subitem = new Tbl_Tests();

            var item = new Tbl_Tests();
            item.Id = Convert.ToInt32(txt_test_id.Text);
            var data = db.Delete(item);
            Toast.MakeText(this, "Record Deleted Successfully...,", ToastLength.Short).Show();
            txt_test_name.Text = "";
            txt_test_range.Text = "";
            load_spiner_tests();



        }

        private void btn_new_test_Click(object sender, EventArgs e)
        {
            txt_test_name.Text = "";
            txt_test_range.Text = "";


        }

        private void btn_update_test_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_test_Click(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Blood_Tests.sqlite");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<Tbl_Tests>();
            Tbl_Tests tbl = new Tbl_Tests();
            tbl.Test_Name = txt_test_name.Text;
            tbl.Test_Range = txt_test_range.Text;

            db.Insert(tbl);
            Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
            txt_test_name.Text = "";
            txt_test_range.Text = "";
            load_spiner_tests();

        }

        private void spinner_tests_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            var id = this.List_Tests.ElementAt(e.Position).Id;
            var testname = this.List_Tests.ElementAt(e.Position).Test_Name;
            var testrange = this.List_Tests.ElementAt(e.Position).Test_Range;

            txt_test_id.Text = Convert.ToString(id);
            // txt_category.Text = masteraccountname;
            btn_delete_test.Enabled = true;

        }

        private void load_spiner_tests()
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Blood_Tests.sqlite");
            var db = new SQLiteConnection(dpPath);
            var data_s = db.Query<Tbl_Tests>("select *  from Tbl_Tests");
            List_Tests = data_s;
            Blood_Test_New.Resources.Adapter_Tests da = new Resources.Adapter_Tests(this, List_Tests);
            spinner_tests.Adapter = da;
        }
    }
}