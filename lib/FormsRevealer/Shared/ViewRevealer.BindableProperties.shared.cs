using System;
using Xamarin.Forms;

namespace FormsRevealer.Shared
{
    public partial class ViewRevealer
    {
        public static readonly BindableProperty ChildViewProperty = BindableProperty.Create(
            nameof(ChildView),
            typeof(View),
            typeof(ViewRevealer),
            new Label {Text = "Set some content :D", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center},
            propertyChanged: OnChildViewChanged
        );

        private static void OnChildViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ViewRevealer revealer)
            {
                //revealer.HorizontalOptions = revealer.ChildView.HorizontalOptions;
                //revealer.VerticalOptions = revealer.ChildView.VerticalOptions;

                revealer.WidthRequest = revealer.ChildView.WidthRequest;
                revealer.HeightRequest = revealer.ChildView.HeightRequest;

                revealer.MinimumWidthRequest = revealer.ChildView.MinimumWidthRequest;
                revealer.MinimumHeightRequest = revealer.ChildView.MinimumHeightRequest;
            }
        }

        /// <summary>
        /// The <see cref="View"/> to be revealed or hidden
        /// </summary>
        public View ChildView
        {
            get => (View) GetValue(ChildViewProperty);
            set => SetValue(ChildViewProperty, value);
        }

        public static readonly BindableProperty RevealEasingProperty = BindableProperty.Create(
            nameof(RevealEasing),
            typeof(Easing),
            typeof(ViewRevealer),
            Easing.CubicInOut
        );

        /// <summary>
        /// The <see cref="Easing"/> (function) to use for the reveal
        /// </summary>
        public Easing RevealEasing
        {
            get => (Easing) GetValue(RevealEasingProperty);
            set => SetValue(RevealEasingProperty, value);
        }


        public static readonly BindableProperty RevealDurationMillisProperty = BindableProperty.Create(
            nameof(RevealDurationMillis),
            typeof(int),
            typeof(ViewRevealer),
            900
        );

        /// <summary>
        /// The reveal animation duration, expressed in milliseconds
        /// </summary>
        public int RevealDurationMillis
        {
            get => (int) GetValue(RevealDurationMillisProperty);
            set => SetValue(RevealDurationMillisProperty, value);
        }


        public static readonly BindableProperty HorizontalRevealAnchorProperty = BindableProperty.Create(
            nameof(HorizontalRevealAnchor),
            typeof(float),
            typeof(ViewRevealer),
            1.0f
        );

        /// <summary>
        /// The X component of the reveal animation, as a value between 0.0 and 1.0
        /// </summary>
        public float HorizontalRevealAnchor
        {
            get => (float) GetValue(HorizontalRevealAnchorProperty);
            set => SetValue(HorizontalRevealAnchorProperty, value);
        }

        public static readonly BindableProperty VerticalRevealAnchorProperty = BindableProperty.Create(
            nameof(VerticalRevealAnchor),
            typeof(float),
            typeof(ViewRevealer),
            1.0f
        );

        /// <summary>
        /// The X component of the reveal animation, as a value between 0.0 and 1.0
        /// </summary>
        public float VerticalRevealAnchor
        {
            get => (float) GetValue(VerticalRevealAnchorProperty);
            set => SetValue(VerticalRevealAnchorProperty, value);
        }

        public static readonly BindableProperty ShouldRevealProperty = BindableProperty.Create(
            nameof(ShouldReveal),
            typeof(bool),
            typeof(ViewRevealer),
            false,
            BindingMode.TwoWay,
            propertyChanged: OnShouldRevealChanged
        );

        private static void OnShouldRevealChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
//            Console.WriteLine($"{nameof(ShouldReveal)} changed from {oldvalue} to {newvalue}");
            if (bindable is ViewRevealer viewRevealer && (bool) oldvalue != (bool) newvalue)
            {
                if ((bool) newvalue)
                {
                    viewRevealer._StartRevealAnimation();
                }
                else
                {
                    viewRevealer._StartHidingAnimation();
                }
            }
        }

        /// <summary>
        /// Controls whether or not the <see cref="ViewRevealer"/> should be revealing its child view. This is a two-way bindable property.
        /// </summary>
        public bool ShouldReveal
        {
            get => (bool) GetValue(ShouldRevealProperty);
            set => SetValue(ShouldRevealProperty, value);
        }

        public static readonly BindableProperty CurrentRevealStateProperty = BindableProperty.Create(
            nameof(CurrentRevealState),
            typeof(RevealState),
            typeof(ViewRevealer),
            RevealState.Hidden
        );

        /// <summary>
        /// Gets the current <see cref="RevealState"/> of the <see cref="ViewRevealer"/>. This is a BindableProperty.
        /// </summary>
        public RevealState CurrentRevealState
        {
            get => (RevealState) GetValue(CurrentRevealStateProperty);
            set => SetValue(CurrentRevealStateProperty, value);
        }
    }
}