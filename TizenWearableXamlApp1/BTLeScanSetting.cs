using System.Runtime.InteropServices;
using Tizen;
using Tizen.Network.Bluetooth;
using System.Threading;

namespace TizenWearableXamlApp1
{
    // NOTICE
    // Use below BTConfigure.SetBLEScanning for scan mode of low latency.
    // Must call BTConfigure.SetBLEScanning() just before scanning for safety because this method assumes BT initializtion.
    public class BTConfigure
    {
        [DllImport("libcapi-network-bluetooth.so.0", EntryPoint = "bt_adapter_le_set_scan_mode")]
        public static extern int SetLeScanMode(int mode);

        public static void SetBLEScanning()
        {
            bool isEnabled = false;
            isEnabled = BluetoothAdapter.IsBluetoothEnabled;
            if (isEnabled)
            {
                Log.Info("VCApp", "Bluetooth is enabled");

                // BT_ADAPTER_LE_SCAN_MODE_BALANCED 0 Balanced mode of power consumption and connection latency
                // BT_ADAPTER_LE_SCAN_MODE_LOW_LATENCY 1 for low connection latency but high power consumption
                // BT_ADAPTER_LE_SCAN_MODE_LOW_ENERGY 2 for low power consumption but high connection latency
                SetLeScanMode(1);
                Log.Info("VCApp", "Bluetooth SetLE Called. BT_ADAPTER_LE_SCAN_MODE_LOW_LATENCY");
            }
        }

        public static void TestScanning()
        {
            /// For more information on scanning for BLE devices, see Managing Bluetooth LE Scans
            BluetoothAdapter.ScanResultChanged += scanResultEventHandler;
            BluetoothAdapter.StartLeScan();
            Thread.Sleep(10000);
            /// Wait while the system searches for the LE target you want to connect to
            /// If you find the LE target you want, stop the scan
            BluetoothAdapter.StopLeScan();
        }

        private static void scanResultEventHandler(object sender, AdapterLeScanResultChangedEventArgs e)
        {
            Log.Info("VCApp", "Bluetooth scanResultEventHandler Called.");
        }
    }
}