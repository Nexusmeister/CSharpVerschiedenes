using Android.Content;
using Android.Util;
using Android.Views;

namespace KneipenFinder.Droid.Test
{
    public class View1 : View
    {
        public View1(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public View1(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        private void Initialize()
        {
        }
    }
}