using EVet.Models;
using EVet.Views;
using static EVet.Includes.GlobalVariables;
namespace EVet.Views;
    
public partial class PageHome : ContentPage
{
  

    public PageHome()
	{
		InitializeComponent();
      
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new PageSettings();

        //await Navigation.PopAsync();

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookAppointment());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PetInfo());

    }
   

    private async void OnAppointmentsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookAppointment());
    }
    private Pets GetSelectedPet()
    {
        // Logic to retrieve the selected pet
        // This is just a placeholder; implement your logic here
        return new Pets
        {
            Name = name,
            ImageSource = images,
            PetType = petType,
            Gender = gender,
            Weight =weight,
            Breed = breed
        };
    }
    private async void OnPetProfileClicked(object sender, EventArgs e)
    {
        Pets selectedPet = GetSelectedPet();
        if (selectedPet != null)
        {
            await Navigation.PushAsync(new PetProfile(selectedPet));
        }
        else
        {
            // Handle the case where no pet is selected (optional)
            await DisplayAlert("Error", "No pet selected.", "OK");
        }

    }
}