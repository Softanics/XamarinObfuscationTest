using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Widget;
using System.Text;
using System.Security.Cryptography;

namespace XamarinObfuscationTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            var passwordtext = FindViewById<EditText>(Resource.Id.passwordtext);
            passwordtext.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    var statuslabel = FindViewById<TextView>(Resource.Id.statuslabel);

                    statuslabel.Text = passwordtext.Text + " is " +
                        (CheckPassword(passwordtext.Text) ? "correct" : "wrong");

                    e.Handled = true;
                }
            };
        }

        [ArmDot.Client.VirtualizeCode]
        private bool CheckPassword(string text)
        {
            using (var hash = SHA256.Create())
            {
                var result = hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                return result[0] == 0x99 && result[1] == 0x97 && result[2] == 0xee &&
                    result[3] == 0x6b && result[4] == 0xc0 && result[5] == 0x52 &&
                    result[6] == 0x40 && result[7] == 0x93 && result[8] == 0xf7 &&
                    result[9] == 0xdf && result[10] == 0xb2 && result[11] == 0xae &&
                    result[12] == 0x8f && result[13] == 0x80 && result[14] == 0xa9 &&
                    result[15] == 0x97 && result[16] == 0xd7 && result[17] == 0x55 &&
                    result[18] == 0x04 && result[19] == 0xbf && result[20] == 0xd2 &&
                    result[21] == 0xe8 && result[22] == 0x29 && result[23] == 0xf5 &&
                    result[24] == 0x4a && result[25] == 0x2a && result[26] == 0x0c &&
                    result[27] == 0xd3 && result[28] == 0x17 && result[29] == 0x2a &&
                    result[30] == 0xda && result[31] == 0xd8;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
