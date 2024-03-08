using MAUI.SpeechTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.SpeechTherapy.Utils
{
    public class MyUtils
    {

  
        public static void FillDataBase()
        {
            try
            {
                //// TODO Only do this when app first runs
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                using (Stream stream = assembly.GetManifestResourceStream("MAUI.SpeechTherapy.SpeechDB.db3"))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);

                        File.WriteAllBytes(Constants.DbPath, memoryStream.ToArray());
                    }
                }

            }
            catch (Exception ex) { string msg = ex.Message; }
        }

        public static bool FirstRun
        {
            get => Preferences.Get(nameof(FirstRun), true);
            set => Preferences.Set(nameof(FirstRun), value);
        }

        public static T GetValueFromTapped<T>(TappedEventArgs e)
        {
            var tapEventArgs = (TappedEventArgs)e;
            return (T)tapEventArgs.Parameter;
        }

        public static T GetValueFromCollectionView<T>(SelectionChangedEventArgs e)
        {
           return  (T) e.CurrentSelection.FirstOrDefault();
        }

        public static async void ChangeItemListBackGround(ContentView contentView)
        {
            try
            {
                Grid grid = contentView.Children[0] as Grid;
                Border border = grid.Children[0] as Border;
                HorizontalStackLayout hStack = border.GetVisualTreeDescendants().
                    Where(x => x.GetType() == typeof(HorizontalStackLayout)).First() as HorizontalStackLayout;
                Label label = hStack.Children[0] as Label;


                border.BackgroundColor = Color.FromHex("#E8FDFF");
                await Task.Delay(300);

                label.TextColor = Colors.White;
                border.BackgroundColor = Color.FromHex("#0F7F8C");
                await Task.Delay(300);


                border.BackgroundColor = Colors.White;
                label.TextColor = Colors.Black;
            }
            catch (Exception e) { string msg = e.Message; }

        }

        public static Color GetColorFromResourse(string resourse)
        {
            if (App.Current.Resources.TryGetValue(resourse, out var colorvalue))
                return (Color)colorvalue;
            return null;

        }

        public static async Task NavigateTo(string pagePath)
        {
            try
            {
                await Shell.Current.GoToAsync(pagePath);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

        }

    }
}
