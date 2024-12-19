using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System.Reflection;
using System.Xml.Linq;
using static EVet.Includes.GlobalVariables;

namespace EVet.Views;
public partial class PageLabResults : ContentPage
{
    public PageLabResults()
    {
        InitializeComponent();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        // Validate input
        if (string.IsNullOrWhiteSpace(PetNameEntry.Text) ||
            string.IsNullOrWhiteSpace(OwnerNameEntry.Text) ||
            TestNamePicker.SelectedIndex == -1 || // Check if a test is selected
            string.IsNullOrWhiteSpace(ResultEntry.Text) ||
            string.IsNullOrWhiteSpace(NormalRangeEntry.Text))
        {
            await DisplayAlert("Validation Error", "Please fill in all fields.", "OK");
            return;
        }

        // Here you would typically save the results to a database or perform some action
        // For demonstration, we'll just show a success message
        await DisplayAlert("Success", "Lab results submitted successfully!", "OK");

        // Optionally, clear the entries after submission
        PetNameEntry.Text = string.Empty;
        OwnerNameEntry.Text = string.Empty;
        TestNamePicker.SelectedIndex = -1; // Reset the picker
        ResultEntry.Text = string.Empty;
        NormalRangeEntry.Text = string.Empty;
        DatePicker.Date = DateTime.Now;
        TimePicker.Time = TimeSpan.FromHours(12);
    }

    private async void OnPetProfileClicked(object sender, EventArgs e)
    {
        // Navigate to the pet profile page
        await Navigation.PushAsync(new PageAdmin());
    }

    private async void OnAppointmentsClicked(object sender, EventArgs e)
    {
        // Navigate to the appointments page
        await Navigation.PushAsync(new PageAdminViewAppointment());
    }
}



