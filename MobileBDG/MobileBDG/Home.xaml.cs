
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MobileBDG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsyncToPage(new Video(), this);
        }
        
    }
}
