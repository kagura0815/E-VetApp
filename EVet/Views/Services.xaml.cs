namespace EVet.Views;

public partial class Services : ContentPage
{
	public Services()
	{
		InitializeComponent();
	}
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AppShell());
    }
}