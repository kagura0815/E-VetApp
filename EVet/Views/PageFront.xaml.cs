namespace EVet.Views;

public partial class PageFront : ContentPage
{
	public PageFront()
	{
		InitializeComponent();
	}
    private void btnadd_Clicked(object sender, EventArgs e)
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new PageLogin();
        }
    }

    private void btnadd_Clicked1(object sender, EventArgs e)
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new PageLoginAdmin();
        }
    }
}