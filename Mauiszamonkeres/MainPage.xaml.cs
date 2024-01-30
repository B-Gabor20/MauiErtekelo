namespace Mauiszamonkeres
{
    public partial class MainPage : ContentPage
    {
        string meglevofelhasznalo = "admin";
        string meglevojeszo = "admin";
        string beirtjelszo;
        public static string beirtfelhasznalo { get; set; }
        public static bool sikereslogin { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        void OnEntryTextChangedfelhasznalo(object sender, TextChangedEventArgs e)
        {
            string oldfelhasznalo = e.OldTextValue;
            string newfehasznalo = e.NewTextValue;
            string myfelhasznalo = entryfelhasznalo.Text;
            beirtfelhasznalo = myfelhasznalo;
        }
        void OnEntryCompletedfelhasznalo(object sender, EventArgs e)
        {
            string text1 = ((Entry)sender).Text;
        }
        void OnEntryTextChangedjelszo(object sender, TextChangedEventArgs e)
        {
            string oldjelszo = e.OldTextValue;
            string newjelszo = e.NewTextValue;
            string myjelszo = entryjelszo.Text;
            beirtjelszo = myjelszo;
        }
        void OnEntryCompletedjelszo(object sender, EventArgs e)
        {
            string text2 = ((Entry)sender).Text;
        }
        async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            if ((meglevofelhasznalo == beirtfelhasznalo) && (meglevojeszo == beirtjelszo))
            {
                sikereslogin = true;
                await Shell.Current.GoToAsync("ListPage");
                await DisplayAlert("Alert", "Sikerült belépni", "OK");
            }
            else
            {
                sikereslogin = false;
                beirtfelhasznalo = "Vendég";
                await Shell.Current.GoToAsync("ListPage");
                await DisplayAlert("Alert", "Nem sikerült belépni, vendég lettél xd", "OK");
            }
        }
    }

}
