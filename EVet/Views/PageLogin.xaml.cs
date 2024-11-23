namespace EVet.Views;
using static EVet.Includes.GlobalVariables;
using EVet.Models;
using Microsoft.Maui.Controls;
using Firebase.Database.Query;
using Firebase.Database;
using EVet.Includes;

public partial class PageLogin : ContentPage
{
    Users _login = new();
    public PageLogin()
	{
		InitializeComponent();
	}

    private async void btnadd_Clicked(object sender, EventArgs e)
    {
        Console.WriteLine($"Username: {txtuname.Text}, Password: {txtpword.Text}");

        if (string.IsNullOrEmpty(txtuname.Text))
        {
            await DisplayAlert("Data validation", "Please Enter User Name!", "Got it");
            return;
        }
        if (string.IsNullOrEmpty(txtpword.Text))
        {
            await DisplayAlert("Data Validation", "Please enter the Password", "Got It");
            return;
        }
        try
        {

            bool a;
            a = await _login.Getuser(txtuname.Text, txtpword.Text);
          
            if (!a)
            {
                await DisplayAlert("Access Denied", "Please try again!", "Okay");
                return;

            }
            string iD = await GetUserByFirstNameAndLastName(txtuname.Text);

        if (string.IsNullOrEmpty(iD))

        {
            await DisplayAlert("Error", "User  not found 1", "Okay");
            return;
        }
                var user = await client.Child("Users").Child(iD).OnceSingleAsync<Users>();
                if (user == null)
                {
                    await DisplayAlert("Error", "User  not found 2", "Okay");
                    return;
                }
             
              
                    string userFullName = $"{user.FirstName} {user.LastName}";
                GlobalVariables.IDD = iD;
                GlobalVariables.Fullname = userFullName;
                    await DisplayAlert("Access Granted", userFullName , "Okay");
                    await DisplayAlert("Access Granted", iD, "Okay");
                    Application.Current.MainPage = new AppShell(iD, userFullName);
                
            
        }
        catch (FirebaseException ex)
        {
            await DisplayAlert("Firebase Error", $"An error occurred: {ex.Message}", "Okay");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An unexpected error occurred: {ex.Message}", "Okay");
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

    private async Task<string> GetUserByFirstNameAndLastName(string Username)
    {
        var users = await client.Child("Users").OnceAsync<Users>();

        var userWithKey = users.FirstOrDefault(u => u.Object.User.Equals(Username, StringComparison.OrdinalIgnoreCase));

        return userWithKey?.Key;
    }



}