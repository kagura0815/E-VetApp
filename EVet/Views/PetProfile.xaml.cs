namespace EVet.Views;

public partial class PetProfile : ContentPage
{
	public PetProfile()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new PageSettings();
    }
}