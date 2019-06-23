using System.IO;
using Xamarin.Forms;

namespace FormsRevealer.Sample
{
    public interface IViewImageProvider
    {
        byte[] GetViewImage(View view);
    }
}

