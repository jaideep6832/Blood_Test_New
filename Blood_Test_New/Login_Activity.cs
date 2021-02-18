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
    [Activity(Label = "Login_Activity")]
    public class Login_Activity : Activity
    {
        EditText txt_ur_nm;
        EditText txt_pass;
        Button btn_log;
        Button btn_new_user;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login_Layout);
            btn_log = FindViewById<Button>(Resource.Id.btn_log);
            btn_new_user = FindViewById<Button>(Resource.Id.btn_new_user);

            txt_ur_nm = FindViewById<EditText>(Resource.Id.txt_ur_nm);
            txt_pass = FindViewById<EditText>(Resource.Id.txt_pass);

            btn_log.Click += btn_log_Click;
            btn_new_user.Click += btn_new_user_Click;

        }

        private void btn_new_user_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(New_User_Activity));
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Blood_Tests.sqlite");
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<Tbl_Login_Names>();

                var data1 = data.Where(x => x.username == txt_ur_nm.Text && x.password == txt_pass.Text).FirstOrDefault();

                if (data1 != null)
                {
                    Toast.MakeText(this, "Login Success", ToastLength.Short).Show();

                    StartActivity(typeof(New_Test_Activity));

                }
                else
                {
                    Toast.MakeText(this, "Username or Password invalid", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();

            }
        }
    }
}