using EVet.Includes;
using System.Reflection;
using System.Xml.Linq;

namespace EVet.Views;

public partial class PageAdmin : ContentPage
{
	public PageAdmin()
	{
		InitializeComponent();
	}
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageSettings());
        //await Navigation.PopAsync();

    }

    private async void ViewAllAppointments(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageAdminViewAppointment());
    }

    private async void AddLabResults(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageLabResults());
        //string userId = GlobalVariables.IDD;
        //await Navigation.PushAsync(new ViewAllUsers(userId));

    }


    private async void OnAppointmentsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageAdminViewAppointment());
    }
   
    
   
}