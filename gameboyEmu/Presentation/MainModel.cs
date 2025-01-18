using System.Diagnostics;
using Windows.Storage.Pickers;
using gameboyEmu.Libs; 

namespace gameboyEmu.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "GameBoy Emulator"; 
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public async ValueTask LoadRom()
    {

        var picker = new FileOpenPicker();

        picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
        picker.FileTypeFilter.Add("*"); 

        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
        WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

        // picker.FileTypeFilter.Add(".gb"); 

        StorageFile selectedRom = await picker.PickSingleFileAsync();

        if (selectedRom != null)
        {
            gameBoy gb = gameBoy.GetInstance();
            gb.loadROM(selectedRom.Path); 
        }
        else
        {
            ContentDialog invalidSelection = new ContentDialog 
            {
                Title = "Invalid File Selection",
                Content = "Check your connection and try again.",
                CloseButtonText ="OK"
            };

            ContentDialogResult result = await invalidSelection.ShowAsync(); 

        }

    }

    /*
    public async Task GoToSecond()
    {
        var name = await Name;
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
    }
    */ 
    

}
