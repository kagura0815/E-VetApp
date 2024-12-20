using EVet.Models;
using System.Collections.ObjectModel;

namespace EVet.Views;

public partial class ViewAllUsers : ContentPage
{ public ObservableCollection<Users> UsersList{ get; set; }
Users _user = new Users();
    private string _userId;

    public ViewAllUsers(string idd)
	{
		InitializeComponent();
        _userId = idd; // Store the user ID
        UsersList = new ObservableCollection<Users>();
        ListPets.ItemsSource = UsersList;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await FillList();
    }
    private async Task FillList()
    {
        var users = await _user.GetUser();
        foreach (var user in users)
        {
            UsersList.Add(user); // Add each pet to the ObservableCollection
        }
    }
    private async Task<List<Pet>> GetPetsByUser(string idd)
    {
        // Implement your logic to fetch pets by user ID
        // This is just a placeholder
        return await Task.FromResult(new List<Pet>());
    }
    private async void itemeditstudent_Invoked_1(object sender, EventArgs e)
    {
        var item = sender as SwipeItemView;
        if (item == null) return;
        if (item.BindingContext is Users details)
        {
            string userId = details.UID;

            await DisplayAlert("Test", "", "OK");
            await Navigation.PushAsync(new ViewAllPets(userId));

        }
    }
}