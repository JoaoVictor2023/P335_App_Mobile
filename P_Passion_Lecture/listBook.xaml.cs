namespace P_Passion_Lecture;

public partial class listBook : ContentPage
{
	public listBook()
	{
		InitializeComponent();
	}
    private async void CreateBook(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateBook());
    }
}