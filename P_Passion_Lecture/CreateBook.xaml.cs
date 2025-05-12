using Microsoft.Maui.Media;
using P_Passion_Lecture.ViewModels;

namespace P_Passion_Lecture;

public partial class CreateBook : ContentPage
{
    private CrudViewModel ViewModel => (CrudViewModel)BindingContext;


    public CreateBook()
    {
        InitializeComponent();
        
    }

    private async void OnPickImageClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await MediaPicker.PickPhotoAsync();
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                myImage.Source = ImageSource.FromStream(() => stream);

                // Salva o caminho da imagem no ViewModel
                ViewModel.ImageURLEntry = result.FullPath;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Impossible de choisir l'image: {ex.Message}", "OK");
        }
    }

    private void OnRemoveImageClicked(object sender, EventArgs e)
    {
        myImage.Source = null;

        // Também apaga o caminho da imagem do ViewModel
        ViewModel.ImageURLEntry = string.Empty;
    }




}
