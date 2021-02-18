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
    [Activity(Label = "New_User_Activity")]
    public class New_User_Activity : Activity
    {
        EditText txt_ur_nm;
        EditText txt_pass;
        Button btn_save;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.New_User_lyt);
            // Create your application here

            btn_save = FindViewById<Button>(Resource.Id.btn_save);
            txt_ur_nm = FindViewById<EditText>(Resource.Id.txt_ur_nm);
            txt_pass = FindViewById<EditText>(Resource.Id.txt_pass);

            btn_save.Click += Btn_save_Click;
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Blood_Tests.sqlite");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<Tbl_Login_Names>();
                Tbl_Login_Names tbl = new Tbl_Login_Names();
                tbl.username = txt_ur_nm.Text;
                tbl.password = txt_pass.Text;
                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
                SetContentView(Resource.Layout.New_User_lyt);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}