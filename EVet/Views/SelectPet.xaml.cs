using EVet.Models;

namespace EVet.Views;

public partial class SelectPet : ContentPage
{ Pets _petlist = new Pets();
	public SelectPet()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await FillList();
    }
    private async Task FillList()
    {
        ListPets.ItemsSource = await _petlist.GetPet();
    }
  

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new AppShell();
    }

    private async void ListPets_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Pets.pets selectedPets)
        {
            // Create a new instance of the detail page
            var detailPage = new PetProfile();

            // Set the BindingContext to the selected post
            detailPage.BindingContext = new Pets()
            {
                                ID = selectedPets.ID,
                Name = selectedPets.Name,
                Breed = selectedPets.Breed,
                Gender = selectedPets.Gender,
                Weight = selectedPets.Weight
            };

            // Navigate to the detail page
            await Navigation.PushAsync(detailPage);

            // Optionally, deselect the item
            ListPets.SelectedItem = null;
        }
    }
}