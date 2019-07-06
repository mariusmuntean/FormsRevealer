using System;
using System.ComponentModel;
using System.IO;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FormsRevealer.Shared
{
    [Preserve(AllMembers = true)]
    [DesignTimeVisible(true)]
    public partial class ViewRevealer : ContentView
    {
        Grid _rootLayout;
        SKBitmap _childViewImage;
        SKCanvasView _canvasView;
        private float _revealProgress;
        
        public ViewRevealer()
        {
            this.BackgroundColor = Color.Transparent;
            CurrentRevealState = RevealState.Hidden;
            //ToDo: make InputTransparent while NOT Revealed
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            _canvasView = new SKCanvasView();
            _canvasView.PaintSurface += Paint;

            _rootLayout = new Grid();

            ChildView.Opacity = 0.0;
            _rootLayout.Children.Add(ChildView);

            Content = _rootLayout;

            //StartRevealAnimation();
        }

        public void StartRevealAnimation()
        {
            ShouldReveal = true;
        }

        public void StartHidingAnimation()
        {
            ShouldReveal = false;
        }

        private void _StartRevealAnimation()
        {
            CurrentRevealState = RevealState.Revealing;

            ChildView.Opacity = 0.0;

            //_childViewImage = _childViewImage ?? GetChildViewImage();
            _childViewImage = GetChildViewImage();
            _rootLayout.Children.Add(_canvasView);

            var revealAnimation = new Animation(
                interpolatedValue =>
                {
                    _revealProgress = (float) interpolatedValue;
                    _canvasView.InvalidateSurface();
                },
                easing: RevealEasing
            );

            revealAnimation.Commit(this, "RevealAnimation", length: Convert.ToUInt32(RevealDurationMillis), finished: (d, b) =>
            {
                CurrentRevealState = RevealState.Revealed;
                ChildView.Opacity = 1.0;
                _rootLayout.Children.Remove(_canvasView);
            });
        }

        private void _StartHidingAnimation()
        {
            CurrentRevealState = RevealState.Hiding;

            _childViewImage = GetChildViewImage();
            _rootLayout.Children.Add(_canvasView);
            ChildView.Opacity = 0.0;

            var hideAnimation = new Animation(
                interpolatedValue =>
                {
                    _revealProgress = (float) interpolatedValue;
                    _canvasView.InvalidateSurface();
                },
                start: 1.0,
                end: 0.0,
                easing: RevealEasing
            );

            hideAnimation.Commit(this, "HideAnimation", length: Convert.ToUInt32(RevealDurationMillis), finished: (d, b) =>
            {
                CurrentRevealState = RevealState.Hidden;
                _rootLayout.Children.Remove(_canvasView);
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
            var radius = (float) (_revealProgress * hypotenuse);
            clippingPath.AddCircle(info.Width * HorizontalRevealAnchor,
                info.Height * VerticalRevealAnchor,
                radius);

            canvas.ClipPath(clippingPath);

            canvas.DrawBitmap(_childViewImage, new SKPoint(0.0f, 0.0f));
        }

        private SKBitmap GetChildViewImage()
        {
            var childViewImageBytes = DependencyService.Get<IViewImageProvider>(DependencyFetchTarget.GlobalInstance).GetViewImage(ChildView);
            SKCodec codec = SKCodec.Create(new MemoryStream(childViewImageBytes));
            return SKBitmap.Decode(codec);
        }
    }
}