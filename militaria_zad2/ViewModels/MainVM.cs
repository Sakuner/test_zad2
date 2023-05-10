using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm;
using CommunityToolkit;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices;

namespace militaria_zad2.ViewModels;

public class MainVM : ObservableObject
{
    private readonly ApiService _apiService;
    private ObservableCollection<ObjectModel> _areas;

    public ObservableCollection<ObjectModel> Areas
    {
        get => _areas;
        set => SetProperty(ref _areas, value);
    }

    public MainVM(ApiService apiService)
    {
        _apiService = apiService;
        LoadAreas();
    }
    
    public async void LoadAreas()
    {
        await LoadAreasAsync();
    }
    public async Task LoadAreasAsync()
    {
        var areas = await _apiService.GetAreas();
        
        foreach (var area in areas)
        {
            switch (area.LevelName)
            {
                case "Temat":
                    area.LevelColor = "Green";
                    break;
                case "Zakres informacyjny":
                    area.LevelColor = "Red";
                    break;
                case "Dziedzina":
                    area.LevelColor = "Yellow";
                    break;
            }
           
        }
        Areas = new ObservableCollection<ObjectModel>(areas);
    }
}
