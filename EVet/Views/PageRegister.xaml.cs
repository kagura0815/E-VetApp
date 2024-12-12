using EVet.Models;
using System.Text.RegularExpressions;
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
        var idd = Guid.NewGuid().ToString();
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
        else if (string.IsNullOrEmpty(txtcnum.Text) || txtcnum.Text.Length != 11 || !Regex.IsMatch(txtcnum.Text, @"^\d{11}$"))
        {
            await DisplayAlert("Data validation", "The number must contain exactly 11 digits.", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtaddress.Text))
        {
            await DisplayAlert("Data validation", "Please Enter Lastname!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtuser.Text))
        {
            await DisplayAlert("Data validation", "Please Enter  Username!", "Got it");
            return;
        }
       
        else if (string.IsNullOrEmpty(txtpword.Text) || txtpword.Text.Length < 6 || !Regex.IsMatch(txtpword.Text, @"^[a-zA-Z0-9]+$"))
        {
            await DisplayAlert("Data validation", "Please Enter a Password that is at least 8 characters long and contains both letters and numbers!", "Got it");
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
            await _Users._AddUser(idd,txtfname.Text, txtlname.Text, txtcnum.Text, txtaddress.Text, txtuser.Text, txtpword.Text);

            txtfname.Text = string.Empty;
            txtlname.Text = string.Empty;
            txtcnum.Text = string.Empty;
            txtaddress.Text = string.Empty;
            txtuser.Text = string.Empty;
            txtpword.Text = string.Empty;
            await DisplayAlert("Added Successfully!!!", " ", "OK");
            Application.Current!.MainPage = new PageLogin();
            return;
        }

    }



    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new PageLogin();
    }
}