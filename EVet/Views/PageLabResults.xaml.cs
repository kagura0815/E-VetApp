using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System.Reflection;
using System.Xml.Linq;
using EVet.Includes;
using EVet.Models;
using static EVet.Includes.GlobalVariables;
using Firebase.Database;
using Firebase.Database.Query;

namespace EVet.Views;

public partial class PageLabResults : ContentPage
{
    public PageLabResults()
    {
        InitializeComponent();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var currentDate = DateTime.Now;
        var currentTime = DateTime.Now.TimeOfDay;

        // Create a new LabResult object
        var labResult = new LabResults()
        {
            PetName = PetNameEntry.Text, // Get the pet name from the Entry
            OwnerName = OwnerNameEntry.Text, // Get the owner name from the Entry
            Date = currentDate, // Set the current date
            Time = currentTime.ToString(@"hh\:mm"), // Format the time
            TestName = TestNamePicker.SelectedItem?.ToString(), // Get the selected test name
            Result = ResultEntry.Text, // Get the result from the Entry
            Range = RangeEntry.Text // Get the range from the Entry
        };

        // Validate input
        if (string.IsNullOrWhiteSpace(labResult.PetName) ||
            string.IsNullOrWhiteSpace(labResult.OwnerName) ||
            string.IsNullOrWhiteSpace(labResult.TestName) ||
            string.IsNullOrWhiteSpace(labResult.Result) ||
            string.IsNullOrWhiteSpace(labResult.Range))
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        // Call the AddLabResultAsync method to save the lab result
        bool isSuccess = await labResult.AddLabResultAsync();

        if (isSuccess)
        {
            // Show a confirmation message
            await DisplayAlert("Success", "Lab results submitted successfully!", "OK");

            // Clear the form fields
            PetNameEntry.Text = string.Empty;
            OwnerNameEntry.Text = string.Empty;
            ResultEntry.Text = string.Empty;
            RangeEntry.Text = string.Empty;
            TestNamePicker.SelectedItem = null;
        }
        else
        {
            await DisplayAlert("Error", "Failed to submit results. Please try again.", "OK");
        }
    }

    private void OnPetProfileClicked(object sender, EventArgs e)
    {
        // Navigate to the pet profile page
        Navigation.PushAsync(new Views.PageLabResults()); // Ensure this is the correct page
    }

    private void OnAppointmentsClicked(object sender, EventArgs e)
    {
        // Navigate to the appointments page
        Navigation.PushAsync(new PageAdminViewAppointment()); // Ensure this is the correct page
    }
}