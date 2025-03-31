using Personas.ViewModels;

namespace Personas.Pages;

public partial class PeoplePage : ContentPage
{
    public PeoplePage(PeopleViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}