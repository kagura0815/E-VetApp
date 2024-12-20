using EVet.Models;

using static EVet.Includes.GlobalVariables;
using EVet.Models;
using Microsoft.Maui.Controls;
using EVet.Pages;
using CommunityToolkit.Maui.Views;
using System.Diagnostics;
using System.Xml;
namespace EVet.Views;

public partial class PetProfile : ContentPage
{
    private Pets _selectedPet;


    public PetProfile(Pets selectedPet)
	{
       
        InitializeComponent();
        _selectedPet = selectedPet;
        //_pets = pet;
        //BindPetData();
        BindingContext = selectedPet;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        DisplayPetDetails();
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
            Weight = weight,
            Breed = breed
        };
    }
    private void DisplayPetDetails()
    {
        if (_selectedPet != null)
        {
            // Assuming you have labels or other UI elements to display the pet's details
            name = _selectedPet.Name;
           petType = _selectedPet.PetType;
            breed = _selectedPet.Breed;
           gender = _selectedPet.Gender;
           weight = _selectedPet.Weight;
            birthday = _selectedPet.Birthday;
            neutered = _selectedPet.Neutered;
            allergies   = _selectedPet.Allergies;
            // Assuming you have an Image control to display the pet's image
            images = _selectedPet.Images; // Set the image source
        }
    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new SelectPet());
    }
        private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new PageSettings();
    }
    private async void OnHomePageClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageHome());
    }

    private async void OnAppointmentsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookAppointment());
    }

    private async void OnPetProfileClicked(object sender, EventArgs e)
    {
        Pets selectedPet = GetSelectedPet(); // Get the currently selected pet

        if (selectedPet != null) // Check if a pet is selected
        {
            // Navigate to the PetProfile page and pass the selected pet
            await Navigation.PushAsync(new PetProfile(selectedPet));
        }
        else
        {
            // Handle the case where no pet is selected
            await DisplayAlert("Error", "No pet selected.", "OK");
        }
    }

    private async void selectPet(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SelectPet());
    }

    private async void LabResultsView(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewLabResults());
    }

    private async void PrescriptionView(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PrescriptionView());
    }
}