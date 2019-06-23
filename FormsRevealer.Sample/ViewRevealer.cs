using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace FormsRevealer.Sample
{
    [DesignTimeVisible(true)]
    public class ViewRevealer : ContentView
    {
        SKBitmap _childViewImage;
        SKCanvasView _canvas;
        private float _revealProgress;

        public ViewRevealer()
        {
            // dependency service that creates a bitmap from a XF.View:
            // https://forums.xamarin.com/discussion/75408/is-it-possible-to-create-an-image-from-a-view-in-xamarin-forms
            // https://michaelridland.com/xamarin/creating-native-view-xamarin-forms-viewpage/

            // create an SKBitmap or better with that

            // reveal result in canvas

            // when done hide the canvas and show the childView

            this.BackgroundColor = Color.Transparent;
        }

        public static readonly BindableProperty ChildViewProperty = BindableProperty.Create(
            nameof(ChildView),
            typeof(VisualElement),
            typeof(ViewRevealer),
            new Label() { Text = "Set some content :D" }
            );

        public VisualElement ChildView
        {
            get => (VisualElement)GetValue(ChildViewProperty);
            set => SetValue(ChildViewProperty, value);
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            _canvas = new SKCanvasView();
            _canvas.PaintSurface += Paint;

            _childViewImage = GetChildViewImage();
            Content = _canvas;

            StartRevealAnimation();
        }

        public void StartRevealAnimation()
        {
            var revealAnimation = new Animation(
                interpolatedValue =>
                {
                    _revealProgress = (float)interpolatedValue;
                    _canvas.InvalidateSurface();
                },
                easing: Easing.CubicOut
                );

            revealAnimation.Commit(this, "RevealAnimation", length: 1200, finished: (d, b) =>
            {

            });
        }

        private void Paint(object sender, SKPaintSurfaceEventArgs args)
        {
            var info = args.Info;
            var surface = args.Surface;
            var canvas = args.Surface.Canvas;

            canvas.Clear(SKColors.Transparent);

            var clippingPath = new SKPath();
            var hypotenuse = Math.Sqrt(Math.Pow(info.Width, 2) + Math.Pow(info.Height, 2));
            var radius = (float)(_revealProgress * hypotenuse);
            clippingPath.AddCircle(info.Width, info.Height, radius);

            canvas.ClipPath(clippingPath);

            canvas.DrawBitmap(_childViewImage, new SKPoint(0.0f, 0.0f));
        }

        private SKBitmap GetChildViewImage()
        {
            string resourceID = "FormsRevealer.Sample.ape.jpg";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            SKBitmap resourceBitmap;
            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                resourceBitmap = SKBitmap.Decode(stream);
            }

            return resourceBitmap;
        }

    }
}

