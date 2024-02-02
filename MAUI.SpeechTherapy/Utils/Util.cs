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

        public static async void ChangeItemListBackGround(ContentView contentView)
        {
            try
            {
                Grid grid = contentView.Children[0] as Grid;
                Border border = grid.Children[0] as Border;
                HorizontalStackLayout hStack = border.GetVisualTreeDescendants().
                    Where(x => x.GetType() == typeof(HorizontalStackLayout)).First() as HorizontalStackLayout ;
                Label label = hStack.Children[0] as Label;


                border.BackgroundColor = Color.FromHex("#E8FDFF");
                await Task.Delay(200);

                label.TextColor = Colors.White;
                border.BackgroundColor = Color.FromHex("#0F7F8C");
                await Task.Delay(200);


                border.BackgroundColor = Colors.White;
                label.TextColor = Colors.Black;
            }
            catch (Exception e) { string msg = e.Message; }

        }
    }
}
