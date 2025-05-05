using Microsoft.Maui.Media;

namespace P_Passion_Lecture;

public partial class CreateBook : ContentPage
{

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
    }


}
