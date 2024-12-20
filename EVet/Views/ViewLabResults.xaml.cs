using CommunityToolkit.Maui.Alerts;
using EVet.Models;

namespace EVet.Views;

public partial class ViewLabResults : ContentPage
{ LabResults _labresults = new LabResults();
	public ViewLabResults()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await FillList();
    }
    private async Task FillList()
    {
        ListAppointments.ItemsSource = await _labresults.GetLabResults();

    }
    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        ListAppointments.ItemsSource = await _labresults.FindAppointment(txtsearch.Text);
    }
    private async void txtsearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        ListAppointments.ItemsSource = await _labresults.GetAllLabResults();
    }
    private async void itemeditstudent_Invoked_1(object sender, EventArgs e)
    {
        //var item = sender as SwipeItemView;
        //if (item == null) return;
        //if (item.BindingContext is Appointment details)
        //{
        //    apptkey = await _apptlist.GetAppointmentKey(details.BId);
        //    await DisplayAlert("Test", apptkey, "OK");
        //    await Navigation.PushAsync(page: new EditAppointment());

        }
    }



   