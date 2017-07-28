using System;
using System.Windows;
using System.Windows.Markup;

namespace Common
{

    [MarkupExtensionReturnType(typeof(Style))]
    public class MultiStyle //: MarkupExtension
    {



        //public Style BaseStyle
        //{
        //    get { return (Style)GetValue(BaseStyleProperty); }
        //    set { SetValue(BaseStyleProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for BaseStyle.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty BaseStyleProperty =
        //    DependencyProperty.Register("BaseStyle", typeof(Style), typeof(MultiStyle));




        //public Style StyleTwo
        //{
        //    get { return (Style)GetValue(StyleTwoProperty); }
        //    set { SetValue(StyleTwoProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for StyleTwo.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty StyleTwoProperty =
        //    DependencyProperty.Register("StyleTwo", typeof(Style), typeof(MultiStyle));




        //public Style BasedOn { get; set; }
        //public Style MergeStyle { get; set; }

        //public override object ProvideValue(IServiceProvider serviceProvider)
        //{
        //    if (StyleTwo == null)
        //        return BaseStyle;

        //    Style newStyle = new Style(BaseStyle.TargetType, BaseStyle);

        //    MergeWithStyle(newStyle, StyleTwo);

        //    return newStyle;
        //}

        //private static void MergeWithStyle(Style style, Style mergeStyle)
        //{
        //    if (mergeStyle.BasedOn != null)
        //    {
        //        MergeWithStyle(style, mergeStyle.BasedOn);
        //    }
        //    foreach (var setter in mergeStyle.Setters)
        //        style.Setters.Add(setter);
        //    foreach (var trigger in mergeStyle.Triggers)
        //        style.Triggers.Add(trigger);
        //}
    }
}
