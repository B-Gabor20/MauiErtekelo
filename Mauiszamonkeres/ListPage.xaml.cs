using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.ObjectModel;
namespace Mauiszamonkeres;

public partial class ListPage : ContentPage
{
    async void SaveMauiAsset()
    {
        try
        {
            var docsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.WriteAllLines($"{docsDirectory}/adat.txt", list);
        }
        catch (Exception ex)
        {
            DisplayAlert("Title", ex.Message, "Cancel");
        }
    }
    async void LoadMauiAsset()
    {
        var docsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        string[] data = File.ReadAllLines($"{docsDirectory}/adat.txt");
        for (int i = 0; i < data.Length; i++)
        {
            list.Add(data[i]);
        }
    }
    ObservableCollection<string> list = new ObservableCollection<string>();
    public ListPage()
	{
		InitializeComponent();
        if (MainPage.sikereslogin == true)
        {
            felh.Text = "Üdvözöljük " + MainPage.beirtfelhasznalo.ToString();
        }
        else
        {
            felh.Text = "Üdvözöljük Vendég";
        }
        
         
	}
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    private async void BtnFelvitel_Clicked(object sender, EventArgs e)
    {
        list.Add(EtrBe.Text);
        LwAdatok.ItemsSource = list;

    }
    private async void BtnMent_Clicked(object sender, EventArgs e)
    {
        if(MainPage.sikereslogin ==  true)
        {
            SaveMauiAsset();
        }
        else
        {
            BtnMent.IsVisible = false;
            await DisplayAlert("Alert", "NU UHH, LÉPJ BE", "OK");
        }
    }
    private async void BtnBetolt_Clicked(object sender, EventArgs e)
    {
        if (MainPage.sikereslogin == true)
        {
            LoadMauiAsset();
            LwAdatok.ItemsSource = list;
        }
        else
        {
            BtnMent.IsVisible = false;
            await DisplayAlert("Alert", "NU UHH, LÉPJ BE", "OK");
        }
    }
    private async void BtnKijeloltTorol_Clicked(object sender, EventArgs e)
    {
        string torolhetoitem = LwAdatok.SelectedItem.ToString();
        list.Remove(torolhetoitem);
        LwAdatok.ItemsSource = list;
    }
    private async void BtnTeljesTorol_Clicked(object sender, EventArgs e)
    {
        list.Clear();
        LwAdatok.ItemsSource = list;
    }
    private async void BtnBeszur_Clicked(object sender, EventArgs e)
    {
        string kivalitem = LwAdatok.SelectedItem.ToString();
        int poz = list.IndexOf(kivalitem);
        list.Insert(poz, EtrBe.Text);
        LwAdatok.ItemsSource = list;
    }
}