using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Graphics;

namespace AndroidUIElements.Controls
{
    public class ExFrame : FrameLayout
    {

        public ExFrame(Context context) :base(context)
        {
        }
        public ExFrame(Context context,IAttributeSet attrs) : base(context, attrs)
        {
        }
        public ExFrame(Context context, IAttributeSet attrs,int defualStyle) : base(context, attrs, defualStyle)
        {
        }
    }
}