namespace EVet.Views;

public partial class PageLoginAdmin : ContentPage
{
	public PageLoginAdmin()
	{
		InitializeComponent();
	}
    private void showPasswordCheckBox1_CheckChanged(object sender, EventArgs e)
    {
        txtpsword.IsPassword = !showPasswordCheckBox1.IsChecked;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new PageFront();
    }

  
}