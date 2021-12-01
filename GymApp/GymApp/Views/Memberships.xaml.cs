using GymAppV2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Memberships : ContentPage
    {
        public Memberships()
        {
            InitializeComponent();
            this.Title = "Membresías";

            CargaLista();
        }

        CardData cards = new CardData();

        StackLayout cardstack = new StackLayout
        {
            Spacing = 15,
            Padding = new Thickness(10),
            VerticalOptions = LayoutOptions.StartAndExpand,
        };
        StackLayout shadowcardstack = new StackLayout
        {
            Spacing = 5,
            Padding = new Thickness(5),
            VerticalOptions = LayoutOptions.StartAndExpand,
        };

        public void CargaLista()
        {
            foreach (var card in cards)
            {
                cardstack.Children.Add(new CardView(card));
            }
            this.BackgroundColor = Color.White;

            Content = new ScrollView()
            {
                Content = new StackLayout()
                {

                    Spacing = 30,
                    Padding = 25,
                    Children =
                    {

                            cardstack,
                            shadowcardstack
                    }
                }
            };

        }
    }
}