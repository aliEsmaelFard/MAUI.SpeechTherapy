using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MAUI.SpeechTherapy.Utils
{
    public class LabelCharConverter : IValueConverter
    {
        public static char Letter { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                var formattedString = new FormattedString();
                var currentColor = Colors.Black;

                var ligatureRegex = new Regex(@"\p{IsArabic}(\p{IsArabic})*");
                var ligatureMatches = ligatureRegex.Matches(str);

                foreach (Match match in ligatureMatches)
                {
                    var ligature = match.Value;
                    var ligatureLength = ligature.Length;

                    for (int i = 0; i < ligatureLength; i++)
                    {
                        var c = ligature[i];

                        if (c == Letter)
                        {
                            formattedString.Spans.Add(new Span { Text = c.ToString(), TextColor = Colors.Aqua });
                        }
                        else
                        {
                            formattedString.Spans.Add(new Span { Text = c.ToString(), TextColor = currentColor });
                        }
                    }

                    if (ligature.Contains(Letter))
                    {
                        currentColor = Colors.Aqua;
                    }
                }

                return formattedString;
            }

            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
