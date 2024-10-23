namespace EVet.Views;
using static EVet.Includes.GlobalVariables;
using EVet.Models;
using Microsoft.Maui.Controls;
public partial class PageLogin : ContentPage
{
    Users _login = new();
    public PageLogin()
	{
		InitializeComponent();
	}

    private async void btnadd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtuname.Text))
        {
            await DisplayAlert("Data validation", "Please Enter User Name!", "Got it");
            return;
        }
        bool a;
        a = await _login.Getuser(txtuname.Text, txtpword.Text);
        if (a)
        {
            await DisplayAlert("Username Validation", "Access Granted", " OK!!!");
            Application.Current!.MainPage = new AppShell();

        }
        else
        {


            await DisplayAlert("Username Validation", "Access Denied", " OK!!!");
            txtuname.Text = string.Empty;
            txtpword.Text = string.Empty;
            return;
        }



    }

    private void showPasswordCheckBox_CheckChanged(object sender, EventArgs e)
    {
        txtpword.IsPassword = !showPasswordCheckBox.IsChecked;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new PageRegister();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new PageFront();
    }
}