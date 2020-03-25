using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GazeNote
{
    [ContentProperty("Source")]
    class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider) {
            if (Source == null) {
                return null;
            }
            // You use a overload of ImageSource.FromResource method that takes two attributes: a path to image
            // and the assembly in which it is located, which is obtained using some shenanigans with System.Reflection
            // That is required to use embedded resources on UWP
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            return imageSource;
        }
    }
}
