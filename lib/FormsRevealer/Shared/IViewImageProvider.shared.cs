using Xamarin.Forms;

namespace FormsRevealer.Shared
{
    public interface IViewImageProvider
    {
        byte[] GetViewImage(View view);
    }
}

