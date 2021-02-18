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

namespace Blood_Test_New.Resources
{
   public  class Adapter_Tests : BaseAdapter<Tbl_Tests>
    {
        private readonly Activity context;
        private readonly List<Tbl_Tests> mItems;

        public Adapter_Tests(Activity context, List<Tbl_Tests> items)
        {
            this.mItems = items;
            this.context = context;
        }



        public override int Count
        {
            get { return mItems.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Tbl_Tests this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var row = convertView;


            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.Adpter_test_Layout, null, false);
            }

         
            TextView txtRowName = row.FindViewById<TextView>(Resource.Id.txtRowName);
            txtRowName.Text = mItems[position].Test_Name;
            TextView txt_test_range = row.FindViewById<TextView>(Resource.Id.txtRange);

            txt_test_range.Text = "    Range : " + Convert.ToString(mItems[position].Test_Range);


            return row;


        }
    }
}