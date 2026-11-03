using System.Threading.Tasks;

namespace counter.Views;

public partial class CounterCreatorPage : ContentPage
{
    string fileName;

	public CounterCreatorPage()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.counter.txt";

        fileName = Path.Combine(appDataPath, randomFileName);
	}

    private async void SaveButtonClicked(object sender, EventArgs e)
    {
        if (CounterTitleEntry.Text == "")
        {
            await DisplayAlert("Error", "Enter the title of your counter", "OK");
            return;
        }

        int baseNumber = 0;
        if (BaseNumberEntry.Text != "" && !int.TryParse(BaseNumberEntry.Text, out baseNumber))
        {
            await DisplayAlert("Error", "Starting number must be a whole number", "OK");
            return;
        }

        File.WriteAllText(fileName, CounterTitleEntry.Text + "\n" + baseNumber + "\n" + baseNumber);
        await Shell.Current.GoToAsync("..");
    }

    private async void CancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}