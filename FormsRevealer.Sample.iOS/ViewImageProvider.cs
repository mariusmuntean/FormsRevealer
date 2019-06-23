using System;
using System.IO;
using FormsRevealer.Sample.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(ViewImageProvider))]
namespace FormsRevealer.Sample.iOS
{
    public class ViewImageProvider : IViewImageProvider
    {
        public byte[] GetViewImage(View formsView)
        {
            var view = Platform.GetRenderer(formsView).NativeView;


            var renderer = new UIGraphicsImageRenderer(view.Bounds.Size);
            var jpgData = renderer.CreateJpeg(0.5f, ctx =>
            {
                Console.WriteLine(ctx);
            });
            var bytes = new byte[jpgData.Length];
            System.Runtime.InteropServices.Marshal.Copy(jpgData.Bytes, bytes, 0, Convert.ToInt32(jpgData.Length));

            return bytes;


            //UIGraphics.BeginImageContextWithOptions(view.Bounds.Size, true, 0);
            //view.Layer.RenderInContext(UIGraphics.GetCurrentContext());
            //var img = UIGraphics.GetImageFromCurrentImageContext();
            //UIGraphics.EndImageContext();
            //var imgData = img;

            //UIGraphics.BeginImageContextWithOptions(view.Bounds.Size, view.Opaque, 1);
            //view.DrawViewHierarchy(view.Frame, false); //this was key line
            //UIImage imgData = UIGraphics.GetImageFromCurrentImageContext();
            //UIGraphics.EndImageContext();

            //var jpgData = imgData.AsJPEG();
            //var bytes = new byte[jpgData.Length];
            //System.Runtime.InteropServices.Marshal.Copy(jpgData.Bytes, bytes, 0, Convert.ToInt32(jpgData.Length));


            //return bytes;
        }
    }
}
