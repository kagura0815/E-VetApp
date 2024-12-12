using EVet.Models;

using static EVet.Includes.GlobalVariables;
using EVet.Models;
using Microsoft.Maui.Controls;
using EVet.Pages;
using CommunityToolkit.Maui.Views;
namespace EVet.Views;

public partial class PetProfile : ContentPage
{
    private Pets _pets;
   
	public PetProfile()
	{
		InitializeComponent();
   
       
    }
    public PetProfile(Pets pet) : this() // Call the parameterless constructor
    {
        _pets = pet;
        DisplayPetDetails();
    }
    private void DisplayPetDetails()
    {
        petName.Text = _pets.Name;
        petBreed.Text = $"Breed: {_pets.Breed}";
        petGender.Text = $"Gender: {_pets.Gender}";
        petWeight.Text = $"Weight: {_pets.Weight}";
        petImage.Source = _pets.Images; // Assuming you have a property for the image source
    }
   

    //protected override async void OnAppearing()
    //    {
    //        base.OnAppearing();
    //        //await FillList();
    //    }
    //    //private async Task FillList()
    //    //{
    //    //    ListsPets.ItemsSource = await _petslist.GetPet();
    //    //}
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current!.MainPage = new SelectPet();
    }
        private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new PageSettings();
    }

}