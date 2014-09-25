using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReizenReview.Factories;
using Xamarin.Forms;

namespace ReizenReview.Pages.XAML
{
    public partial class SplashPageXaml
    {
        public SplashPageXaml()
        {
            InitializeComponent();
			this.loginButton.Clicked += (sender, args) =>
			{
				DisplayAlert("Welcome", nameEntry.Text, "ok");
				this.Navigation.PushAsync(PageFactory.MainPage);
			};
        }
    }
}
