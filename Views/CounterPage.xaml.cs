using System.Threading.Tasks;

namespace counter.Views;


[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class CounterPage : ContentPage
{
    public string ItemId
    {
        set {  LoadCounter(value); }
    }
	public CounterPage()
	{
		InitializeComponent();
	}

    private void LoadCounter(string fileName)
    {
        Models.Counter counterModel = new Models.Counter();
        counterModel.filename = fileName;

        if (File.Exists(fileName))
        {
            counterModel.date = File.GetCreationTime(fileName);
            counterModel.title = File.ReadAllLines(fileName)[0];
            counterModel.baseSetNumber = int.Parse(File.ReadAllLines(fileName)[1]);
            counterModel.currentNumber = int.Parse(File.ReadAllLines(fileName)[2]);
        }

        BindingContext = counterModel;
    }

    private void AddButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Counter counter)
        {
            counter.currentNumber++;
            SaveCounter(counter);
            CounterValueLabel.Text = counter.currentNumber.ToString();
        }
    }

    private void SubtractButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Counter counter)
        {
            counter.currentNumber--;
            SaveCounter(counter);
            CounterValueLabel.Text = counter.currentNumber.ToString();
        }
    }

    private void ResetButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Counter counter)
        {
            counter.currentNumber = counter.baseSetNumber;
            SaveCounter(counter);
            CounterValueLabel.Text = counter.currentNumber.ToString();
        }
    }

    private async void DeleteButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Counter counter)
        {
            if (File.Exists(counter.filename))
                File.Delete(counter.filename);
        }
        await Shell.Current.GoToAsync("..");
    }

    private void SaveCounter(Models.Counter counter)
    {
        File.WriteAllText(counter.filename, counter.title + "\n" + counter.baseSetNumber + "\n" + counter.currentNumber);
    }
}