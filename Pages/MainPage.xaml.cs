using Personas.Pages;

namespace Personas.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnNavigateToPeoplePage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//PeoplePage");
    }
}
