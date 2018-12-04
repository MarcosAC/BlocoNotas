using Android.Content;
using Android.Graphics.Drawables;
using BlocoNotas.Controls;
using BlocoNotas.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace BlocoNotas.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && e.NewElement != null)
            {
                BorderLessBotton();
                BorderEntry();
            }
        }

        private void BorderLessBotton()
        {
            Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
        }

        private void BorderEntry()
        {
            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(Android.Graphics.Color.White);
            gd.SetCornerRadius(10);
            gd.SetStroke(4, Android.Graphics.Color.LightGray);
            Control.SetBackground(gd); ;
        }
    }
}