namespace EVet.Views;

public partial class PageFront : ContentPage
{
	public PageFront()
	{
		InitializeComponent();
	}
    private async void btnadd_Clicked(object sender, EventArgs e)
    {
        if (Application.Current != null)
        {
            await Navigation.PushAsync(new PageLogin());
        }
    }

    private async void btnadd_Clicked1(object sender, EventArgs e)
    {
        if (Application.Current != null)
        {
            await Navigation.PushAsync(new PageLoginAdmin());
        }
    }
   
}