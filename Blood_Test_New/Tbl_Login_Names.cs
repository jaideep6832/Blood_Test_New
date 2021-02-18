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
using SQLite;

namespace Blood_Test_New
{
    public class Tbl_Login_Names
    {
        public string username { get; set; }
        [MaxLength(15)]
        public string password { get; set; }
    }
}