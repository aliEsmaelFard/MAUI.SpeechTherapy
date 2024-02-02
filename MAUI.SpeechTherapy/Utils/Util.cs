using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.SpeechTherapy.Utils
{
    public class Util
    {
        public static T GetValueFromTapped<T>(TappedEventArgs e)
        {
            var tapEventArgs = (TappedEventArgs)e;
            return (T)tapEventArgs.Parameter;
        }
    }
}
