using System.Net;
using System.Reflection;
using EVet.Models;
using static EVet.Includes.GlobalVariables;
namespace EVet.Views;

public partial class EditAppointment : ContentPage
{
   Appointment _appt = new();
    public EditAppointment()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        PetNameEntry.Text = petName;
        OwnerNameEntry.Text = name;
        servicePicker.SelectedItem = service;
        if (TimeSpan.TryParse(appointmentTime, out TimeSpan parsedTime))
        {
            AppointmentTimePicker.Time = parsedTime; // Set the Time property
        }
        else
        {
            // Handle the case where parsing fails (e.g., set to default time)
            AppointmentTimePicker.Time = TimeSpan.FromHours(9); // or some default value
        }
        if (DateTime.TryParse(appointmentDate, out DateTime parsedDate))
        {
            AppointmentDatePicker.Date = parsedDate; // Set the Date property
        }
        else
        {
            // Handle the case where parsing fails (e.g., set to default date)
            AppointmentDatePicker.Date = DateTime.Now; // or some default value

        }
        StatusLabel.Text = "Pending";

    }

    private async void OnBookAppointmentClicked(object sender, EventArgs e)
    {
        StatusLabel.Text = "Confirmed";
        await DisplayAlert("Confirmation", "Your appointment has been confirmed.", "OK");
        await _appt.EditAppointments(PetNameEntry.Text, OwnerNameEntry.Text, AppointmentTimePicker.Time.ToString(), AppointmentDatePicker.Date.ToString(),servicePicker.SelectedItem.ToString(), StatusLabel.Text);
        await DisplayAlert("Update Successfully!!!", " ", "OK");
        await Navigation.PushAsync(new PageAdmin());
    }
    private async void OnCancelClicked(object sender, EventArgs e)
    {
        // Logic to cancel the appointment
        StatusLabel.Text = "Canceled";
        await DisplayAlert("Cancellation", "Your appointment has been canceled.", "OK");
    }
}

