namespace EVet.Views;

public partial class PageHome : ContentPage
{
	public PageHome()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new PageSettings();
        //await Navigation.PopAsync();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new AppShell();
    }
}