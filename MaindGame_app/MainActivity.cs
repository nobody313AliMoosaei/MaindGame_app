
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using Android.Util;
namespace MaindGame_app
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true,Icon ="@mipmap/math_maind_Icon"
        )]
    public class MainActivity : AppCompatActivity
    {


        public Button
            btn1, btn2, btn3, btn4, btn5, btn7, btn8,
            btn9, btn10, btn11, btn13, btn14, btn15,
            btn16, btn17,  btn19, btn20, btn21, btn22,
            btn23,  btn25, btn26, btn27, btn28, btn29;

        public RelativeLayout layout_Buttons;
        public Button btn_Save, btn_Resualt;
        public TextView txtTime;

        public int count, countNumber = 26;
        public int NumMaxBlok = 25;
        public Dialog dialog;
        public int TimeGame = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);


            
            SetWidget();

            #region Dialog panel
            dialog = new Dialog(this);
            dialog.SetContentView(Resource.Layout.layout_Start_Dialog);
            dialog.Window.SetSoftInputMode(Android.Views.SoftInput.StateVisible);
            dialog.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutInScreen, Android.Views.WindowManagerFlags.BlurBehind);
            dialog.SetCancelable(false);
            dialog.Show();
            Spinner spinner = dialog.FindViewById<Spinner>(Resource.Id.spinner1);
            Button btn_Start, btn_Exit;
            btn_Start = dialog.FindViewById<Button>(Resource.Id.btn_Start);
            btn_Exit = dialog.FindViewById<Button>(Resource.Id.btn_Exit);
            
            btn_Start.Click += async (sender, e) =>
              {
                  #region progressDialog
                  
                  ProgressDialog progress = new ProgressDialog(this);
                  progress.SetMessage("لطفا صبر کنید ...");
                  progress.SetCancelable(false);
                  progress.Indeterminate = true;
                  progress.SetCancelable(false);
                  progress.SetProgressStyle(ProgressDialogStyle.Spinner);
                  progress.Show();

                  #endregion
                  var MaxBlok = spinner.SelectedItem;
                  NumMaxBlok = int.Parse(MaxBlok.ToString());
                  count = 1;
                  dialog.Cancel();
                  await System.Threading.Tasks.Task.Delay(3000);
                  
                  #region make number random and Set in Buttons
                  List<int> numbers = new List<int>();
                  List<Button> buttons = new List<Button>()
            {
                btn1 , btn2, btn3, btn4, btn5, btn7, btn8, btn9, btn10, btn11, btn13, btn14, btn15, btn16, btn17,btn19, btn20
            , btn21, btn22, btn23,  btn25, btn26, btn27, btn28, btn29
            };
                  SetNumberRandom(numbers);
                  SetNumbersInButtons(buttons, numbers);
                  #endregion

                  #region Event Click
                  btn1.Click += Btn_Click;
                  btn2.Click += Btn_Click;
                  btn3.Click += Btn_Click;
                  btn4.Click += Btn_Click;
                  btn5.Click += Btn_Click;
                 // btn6.Click += Btn_Click;
                  btn7.Click += Btn_Click;
                  btn8.Click += Btn_Click;
                  btn9.Click += Btn_Click;
                  btn10.Click += Btn_Click;
                  btn11.Click += Btn_Click;
                  //btn12.Click += Btn_Click;
                  btn13.Click += Btn_Click;
                  btn14.Click += Btn_Click;
                  btn15.Click += Btn_Click;
                  btn16.Click += Btn_Click;
                  btn17.Click += Btn_Click;
                  //btn18.Click += Btn_Click;
                  btn19.Click += Btn_Click;
                  btn20.Click += Btn_Click;
                  btn21.Click += Btn_Click;
                  btn22.Click += Btn_Click;
                  btn23.Click += Btn_Click;
                  //btn24.Click += Btn_Click;
                  btn25.Click += Btn_Click;
                  btn26.Click += Btn_Click;
                  btn27.Click += Btn_Click;
                  btn28.Click += Btn_Click;
                  btn29.Click += Btn_Click;
                  /*
                  btn30.Click += Btn_Click;
                  btn31.Click += Btn_Click;
                  btn32.Click += Btn_Click;
                  btn33.Click += Btn_Click;
                  btn34.Click += Btn_Click;
                  btn35.Click += Btn_Click;
                  btn36.Click += Btn_Click;
                  */
                  #endregion
                  
                  await System.Threading.Tasks.Task.Delay(500);
                  SetTime(txtTime);
                  progress.Cancel();
              };

            btn_Exit.Click += delegate
            {
                Finish();
                Finish();
                OnDestroy();
            };
            #endregion


             // Set Time Course
        }

        #region Click
        private void Btn_Click(object sender, EventArgs e)
        {
            var r = (Button)sender;
            int n = int.Parse(r.Text);
            Android.Views.Animations.Animation anim =
                Android.Views.Animations.AnimationUtils.LoadAnimation(this, Resource.Animation.abc_fade_in);
            anim.Duration = 350;
            r.StartAnimation(anim);
            if (n == count)
            {
                if (countNumber > NumMaxBlok)
                {
                    r.Visibility = Android.Views.ViewStates.Invisible;
                    count++;
                    btn_Save.Text = count.ToString();
                }
                else
                {
                    r.Text = "";
                    count++;
                    r.Text = countNumber.ToString();
                    countNumber++;
                    btn_Save.Text = count.ToString();
                }
            }
            //  زمانی که آخرین بلوک انتخاب میشود
            if (NumMaxBlok == count)
            {
                SetTime(txtTime, false);

                Android.Content.Intent intent = new Android.Content.Intent(this , typeof(Activity2));
                intent.PutExtra("REQUEST_CODE_TIMEALL", TimeGame);
                intent.PutExtra("REQUEST_CODE_MAX_BLOK", NumMaxBlok);
                StartActivity(intent);
            }
        }
        #endregion

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
        #region Methods
        public void SetWidget()
        {
            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn2 = FindViewById<Button>(Resource.Id.button2);
            btn3 = FindViewById<Button>(Resource.Id.button3);
            btn4 = FindViewById<Button>(Resource.Id.button4);
            btn5 = FindViewById<Button>(Resource.Id.button5);
            //btn6 = FindViewById<Button>(Resource.Id.button6);
            btn7 = FindViewById<Button>(Resource.Id.button7);
            btn8 = FindViewById<Button>(Resource.Id.button8);
            btn9 = FindViewById<Button>(Resource.Id.button9);
            btn10 = FindViewById<Button>(Resource.Id.button10);
            btn11 = FindViewById<Button>(Resource.Id.button11);
            //btn12 = FindViewById<Button>(Resource.Id.button12);
            btn13 = FindViewById<Button>(Resource.Id.button13);
            btn14 = FindViewById<Button>(Resource.Id.button14);
            btn15 = FindViewById<Button>(Resource.Id.button15);
            btn16 = FindViewById<Button>(Resource.Id.button16);
            btn17 = FindViewById<Button>(Resource.Id.button17);
            //btn18 = FindViewById<Button>(Resource.Id.button18);
            btn19 = FindViewById<Button>(Resource.Id.button19);
            btn20 = FindViewById<Button>(Resource.Id.button20);
            btn21 = FindViewById<Button>(Resource.Id.button21);
            btn22 = FindViewById<Button>(Resource.Id.button22);
            btn23 = FindViewById<Button>(Resource.Id.button23);
            //btn24 = FindViewById<Button>(Resource.Id.button24);
            btn25 = FindViewById<Button>(Resource.Id.button25);
            btn26 = FindViewById<Button>(Resource.Id.button26);
            btn27 = FindViewById<Button>(Resource.Id.button27);
            btn28 = FindViewById<Button>(Resource.Id.button28);
            btn29 = FindViewById<Button>(Resource.Id.button29);
            //btn30 = FindViewById<Button>(Resource.Id.button30);
            //btn31 = FindViewById<Button>(Resource.Id.button31);
            //btn32 = FindViewById<Button>(Resource.Id.button32);
            //btn33 = FindViewById<Button>(Resource.Id.button33);
            //btn34 = FindViewById<Button>(Resource.Id.button34);
            //btn35 = FindViewById<Button>(Resource.Id.button35);
            //btn36 = FindViewById<Button>(Resource.Id.button36);

            btn_Save = FindViewById<Button>(Resource.Id.btn_NumberBlok);
            layout_Buttons = FindViewById<RelativeLayout>(Resource.Id.relativeLayout_buttons);

            txtTime = FindViewById<TextView>(Resource.Id.txtTime);
        }
        private void SetNumberRandom(List<int> number)
        {
            int c = 0;
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(100);

                Random random = new Random();
                var r = random.Next(1, 25);

                if (!IsNumberInArray(number, r))
                {
                    number.Add(r);
                }

            }
            for (int i = 1; i <= 25; i++)
            {
                if (!IsNumberInArray(number, i))
                {
                    number.Add(i);
                }
            }
        }
        private void SetNumbersInButtons(List<Button> btns, List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                btns[i].Text = numbers[i].ToString();
            }
        }
        private bool IsNumberInArray(List<int> numbers, int a)
        {
            foreach (int i in numbers)
            {
                if (i == a)
                    return true;
            }
            return false;
        }
        private async void SetTime(TextView txt , bool t = true)
        {

            int time = 0;
            while (t)
            {
                await System.Threading.Tasks.Task.Delay(1000);
                time++;
                TimeGame = time;
                txt.Text = TimeSpan.FromSeconds(time).ToString();
            }
        }
        #endregion

    }
}