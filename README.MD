## FormsRevealer

A custom control that allows to show and hide Xamarin.Forms Views using a reveal animation.


Here's a quick rundown of the control's features:

* Reveal and hide the child view.
* Adjust the duration of the reveal and hiding animation. Around 900 milliseconds is the default.
* Use any Easing that Xamarin.Forms supports. CubicInOut is the default.
* Choose custom anchor points for the animation. They are similar to Xamarin.Forms' AnchorX and AnchorY concepts. The default is 1.0 and 1.0, i.e. the lower right corner of the child view. The Central Reveal page uses 0.5 and 0.5.
* Control the revealing or hiding through the ShouldReveal BindableProperty. Use Two-way binding to get notified if the reveal state change. See the Login Register Page.
* Get information about the current state of the reveal animation through the CurrentRevealState BindableProperty. It has the values Revealing, Revealed, Hiding and Hidden. See the Huge Reveal page.

## Packages

| Package | Version | Dependencies |
|---|---|---|
| FormsRevealer | [![Nuget](https://img.shields.io/nuget/vpre/FormsRevealer)](https://www.nuget.org/packages/FormsRevealer) | [![Nuget](https://img.shields.io/badge/Xamarin.Forms-v3.6-green)](https://www.nuget.org/packages/Xamarin.Forms/) [![Nuget](https://img.shields.io/badge/SkiaSharp-v1.68-blue)](https://www.nuget.org/packages/SkiaSharp/) [![Nuget](https://img.shields.io/badge/SkiaSharp.Views.Forms-v1.68-blue)](https://www.nuget.org/packages/SkiaSharp.Views.Forms/)

## Known Limitations

For some reason setting the child view's InputTransparent to true has no effect and neither does the combination InputTransparent=true and CascadeInputTransparent=true on the ViewRevealer. This means that while the child view is hidden, it is still receiving touch input. 
For the time being I suggest you make use of the CurrentRevealState BindableProperty of the ViewRevealer class, such that when the child view is Hidden you just set IsVisible(either on the child view or on the ViewRevealer) to false. This removes the control completely.

Here's a gif of the included sample app:

![Sample](media/g1.gif)



As usual you can do everything you want with my code. Have fun!

Have a question?  Tweet at me: https://twitter.com/MunteanMarius
