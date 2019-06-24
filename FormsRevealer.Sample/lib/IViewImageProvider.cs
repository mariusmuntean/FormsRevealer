using Xamarin.Forms;

namespace FormsRevealer.Sample.lib
{
    public interface IViewImageProvider
    {
        byte[] GetViewImage(View view);
    }
}

