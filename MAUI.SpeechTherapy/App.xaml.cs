﻿namespace MAUI.SpeechTherapy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}
