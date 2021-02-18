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
    public class Tbl_Tests
    {
        [PrimaryKey, AutoIncrement] //Column("Id")]
        public int Id { get; set; }

        public string Test_Name { get; set; }

        public string Test_Range { get; set; }
    }
}