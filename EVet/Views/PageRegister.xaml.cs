using EVet.Models;
namespace EVet.Views;

public partial class PageRegister : ContentPage
{
    Users _Users = new();
    public PageRegister()
	{
		InitializeComponent();
	}
    private async void btnadd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtfname.Text))
        {
            await DisplayAlert("Data validation", "Please Enter  Firstname!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtlname.Text))
        {
            await DisplayAlert("Data validation", "Please Enter Lastname!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtuser.Text))
        {
            await DisplayAlert("Data validation", "Please Enter  Username!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtpword.Text))
        {
            await DisplayAlert("Data validation", "Please Enter  Password!", "Got it");
            return;
        }

        bool a;
        a = await _Users.GetUsers(txtuser.Text);
        if (!a)
        {
            await DisplayAlert("User Name validation", "The User Name. you`ve entered is already in the record or you may have lost your internet connection! Please try again", "Got it");
        }
        else
        {
            await _Users._Users(txtfname.Text, txtlname.Text, txtuser.Text, txtpword.Text);

            txtfname.Text = string.Empty;
            txtlname.Text = string.Empty;
            txtuser.Text = string.Empty;
            txtpword.Text = string.Empty;
            await DisplayAlert("Added Successfully!!!", " ", "OK");
            return;
        }

    }



    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new PageLogin();
    }
}