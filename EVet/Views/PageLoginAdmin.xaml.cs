namespace EVet.Views;
using static EVet.Includes.GlobalVariables;
using EVet.Models;
using Microsoft.Maui.Controls;

public partial class PageLoginAdmin : ContentPage
{
    Users _login = new();
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

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtusname.Text))
        {
            await DisplayAlert("Data validation", "Please Enter User Name!", "Got it");
            return;
        }
        bool a;
        a = await _login.Getuser(txtusname.Text, txtpsword.Text);
        if (a)
        {
            await DisplayAlert("Username Validation", "Access Granted", " OK!!!");
            Application.Current!.MainPage = new PageAdmin();

        }
        else
        {


            await DisplayAlert("Username Validation", "Access Denied", " OK!!!");
            txtusname.Text = string.Empty;
            txtpsword.Text = string.Empty;
            return;
        }

    }
}