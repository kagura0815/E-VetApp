using EVet.Includes;
using EVet.Models;
using System.Collections.ObjectModel;
namespace EVet.Views;

public partial class ViewAllPets : ContentPage
{
    public static class SelectedPetHolder
    {
        public static Pets SelectedPet { get; set; }
    }
    string userId = GlobalVariables.IDD;
    Pets _petlist = new Pets();
    public ObservableCollection<Pets> PetsList { get; set; }
    public ViewAllPets(string userId)
    {
        InitializeComponent();
        PetsList = new ObservableCollection<Pets>();
        ListPets.ItemsSource = PetsList;
    }
    //private async void ListPets_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    if (e.CurrentSelection.Count > 0)
    //    {
    //        var selectedPet = e.CurrentSelection[0] as Pets; // Assuming Pets is your model
    //        if (selectedPet != null)
    //        {
    //            await Navigation.PushAsync(new PetProfile(selectedPet));
    //        }
    //    }
    //}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await FillList();
    }
    private async Task FillList()
    { string userId = GlobalVariables.IDD;
        var pets = await _petlist.GetPets(userId);
        PetsList.Clear(); // Clear existing item3
        foreach (var pet in pets)
        {
            PetsList.Add(pet); // Add each pet to the ObservableCollection
        }
    }
    private async void ListPets_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var selectedPet = e.CurrentSelection[0] as Pets; // Assuming Pets is your model
            if (selectedPet != null)
            {
                // Store the selected pet in the static holder
                SelectedPetHolder.SelectedPet = selectedPet;

                // Navigate to the PetProfile page
                await Navigation.PushAsync(new PageLabResults());
            }
        }


    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new AppShell();
    }

    //private async void ListPets_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    if (e.CurrentSelection.FirstOrDefault() is Pets.pets selectedPets)
    //    {
    //        // Create a new instance of the detail page
    //        var detailPage = new AppShell();

    //        // Set the BindingContext to the selected post
    //        detailPage.BindingContext = new Pets()
    //        {
    //            ID = selectedPets.ID,
    //            Name = selectedPets.Name,
    //            Breed = selectedPets.Breed,
    //            Gender = selectedPets.Gender,
    //            Weight = selectedPets.Weight
    //        };

    //        // Navigate to the detail page
    //        await Navigation.PushAsync(detailPage);

    //        // Optionally, deselect the item
    //        ListPets.SelectedItem = null;
    //    }
    //}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {

    }

    private async void addPet(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PetInfo());
    }

    private async void itemeditstudent_Invoked_1(object sender, EventArgs e)
    {
        var item = sender as SwipeItemView;
        if (item == null) return;
        if (item.BindingContext is Pets details)
        {
           
            await DisplayAlert("Test", "", "OK");
            await Navigation.PushAsync(new PageLabResults());

        }
    }
}