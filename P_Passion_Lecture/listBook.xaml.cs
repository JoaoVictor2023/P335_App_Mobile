using P_Passion_Lecture.ViewModels;

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

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = (CrudViewModel)BindingContext;
        vm.ReloadBooks();
    }

}