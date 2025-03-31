using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Personas.Models;
using Personas.Services;

namespace Personas.ViewModels;

public partial class PeopleViewModel : ObservableObject
{
    private readonly ApiService _apiService;

    [ObservableProperty]
    private ObservableCollection<Person> people = new();

    public PeopleViewModel(ApiService apiService)
    {
        _apiService = apiService;
        LoadPeopleCommand = new AsyncRelayCommand(LoadPeople);
    }

    public IAsyncRelayCommand LoadPeopleCommand { get; }

    private async Task LoadPeople()
    {
        var peopleFromApi = await _apiService.GetPeopleAsync();
        People = new ObservableCollection<Person>(peopleFromApi);
    }
}
