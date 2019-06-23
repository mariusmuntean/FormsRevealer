using System;
using System.IO;
using Android.Graphics;
using FormsRevealer.Sample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(ViewImageProvider))]
namespace FormsRevealer.Sample.Droid
{
    public class ViewImageProvider : IViewImageProvider
    {
        public byte[] GetViewImage(View formsView)
        {
            //var view = Platform.GetRenderer(formsView).View;
            var view = Platform.GetRenderer(formsView).View;

            Bitmap bitmap = Bitmap.CreateBitmap(view.Width, view.Height, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(bitmap);
            canvas.DrawColor(Android.Graphics.Color.Transparent);
            view.Draw(canvas);

            byte[] imageBytes;

            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 50, stream);
                imageBytes = stream.ToArray();
            }

            return imageBytes;
        }
    }
}
