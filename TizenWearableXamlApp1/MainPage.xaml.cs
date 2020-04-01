using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tizen.Wearable.CircularUI.Forms;
using System.Runtime.InteropServices;
using Tizen;
using Tizen.Network.Bluetooth;

namespace TizenWearableXamlApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : CirclePage
    {
        [DllImport("libcapi-network-bluetooth.so.0", EntryPoint = "bt_adapter_le_set_scan_mode")]
        public static extern int SetLeScanMode(int mode);

        public MainPage()
        {
            InitializeComponent();
            BTConfigure.SetBLEScanning();
            BTConfigure.TestScanning();
        }

        void OnImageButtonClicked(object sender, EventArgs e)
        {
            label.Text = "ImageButtonClicked.";
        }
    }
}