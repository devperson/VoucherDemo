using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using ZXing.Mobile;
using Xamarin.Forms;
using LaserList.VoucherDemo;
using VoucherDemo.iOS.Services;

[assembly: Xamarin.Forms.Dependency(typeof(QRCodeService))]
namespace VoucherDemo.iOS.Services
{
    public class QRCodeService : IQRCodeService
    {
        MobileBarcodeScanner scanner;
        public async Task<string> Scan()
        {
            scanner = new MobileBarcodeScanner();
            //Tell our scanner to use the default overlay
            scanner.UseCustomOverlay = false;

            //We can customize the top and bottom text of the default overlay
            scanner.TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
            scanner.BottomText = "Wait for the barcode to automatically scan!";

            //By default, all barcode formats are monitored while scanning. 
            //So we can change which formats to check for by passing a ZxingScanningOptions. 
            //In our case we need only to check QR code, so it improves scanning performance
            var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
            options.PossibleFormats = new List<ZXing.BarcodeFormat>() { ZXing.BarcodeFormat.QR_CODE };
            //Start scanning
            var result = await scanner.Scan(options);
            scanner = null;//dispose scanner
            if (result != null && !string.IsNullOrEmpty(result.Text))
                return result.Text;
            return string.Empty; 
        }
    }


}