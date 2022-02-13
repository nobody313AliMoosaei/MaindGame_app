using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaindGame_app
{
    [Activity(Label = "@string/app_name", NoHistory = true)]
    public class Activity2 : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout2);

            int time = Intent.GetIntExtra("REQUEST_CODE_TIMEALL", -1);
            int maxblok = Intent.GetIntExtra("REQUEST_CODE_MAX_BLOK", -1);

            #region
            Dialog dialog = new Dialog(this);
            dialog.SetContentView(Resource.Layout.layout_Result_Dialog);
            TextView txtTime = dialog.FindViewById<TextView>(Resource.Id.txtTimeDialog2);
            TextView txtMaind = dialog.FindViewById<TextView>(Resource.Id.txt_MaindDialog2);
            Button btn_Submit = dialog.FindViewById<Button>(Resource.Id.btn_Submit_Dialog2);
            TextView txt_bloks = dialog.FindViewById<TextView>(Resource.Id.txtBlokDialog2);
            txt_bloks.Text = maxblok.ToString();
            txtTime.Text = TimeSpan.FromSeconds(time).ToString();
            txtMaind.Text = GetMaindByTime(time, maxblok);
            dialog.Window.SetSoftInputMode(SoftInput.AdjustPan);
            dialog.SetCancelable(false);
            dialog.Show();
            btn_Submit.Click += async delegate
            {
                await System.Threading.Tasks.Task.Delay(1000);
                Toast.MakeText(this, "Finish", ToastLength.Long).Show();
                StartActivity(typeof(MainActivity));
            };
            #endregion

        }
        public string GetMaindByTime(int time, int blok)
        {
            if (time < blok - 30)
                return "بابا انشتین";
            else if (time >= blok - 30 && time < blok - 20)
                return "بسیار باهوش";

            else if (time >= blok - 20 && time < blok - 10)
                return "باهوش";

            else if (time >= blok - 10 && time < blok + 10)
                return "خیلی خوب";
            else if (time >= blok + 10 && time < blok + 30)
                return "خوب";
            else if (time >= blok + 30 && time < blok + 50)
                return "طبیعی";
            else if (time >= blok + 50 && time < blok + 80)
                return "مغزت خسته است";
            else
                return "در آستانه پیر مغزی هستی";
        }
    }
}