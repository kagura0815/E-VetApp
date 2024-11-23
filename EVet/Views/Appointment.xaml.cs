using EVet.Includes;
using static EVet.Includes.GlobalVariables;
using EVet.Models;
using Font = Microsoft.Maui.Font;
using Color = Microsoft.Maui.Graphics.Color;
using IImage = Microsoft.Maui.IImage;
using static EVet.App;
using System.Collections.ObjectModel;
namespace EVet.Views;

public partial class Appointment : ContentPage
{

    Pets _pets = new Pets();

    public ObservableCollection<string> Gender { get; set; } = new ObservableCollection<string>();

    public ObservableCollection<string> Neutered { get; set; } = new ObservableCollection<string>();


    string srcs = "f_camera_b.png";
    public Appointment()
    {
        InitializeComponent();

        Gender.Add("Male");
        Gender.Add("Female");
        txtgender.ItemsSource = Gender;


    }
    private async void btnadd_Clicked(object sender, EventArgs e)
    {
        var flename = fullNameUser;
        var selectedgen = txtgender.SelectedItem.ToString();
        //var selectedneut = txtneutered.SelectedItem.ToString();

        //var selecteddate = txtbirthday.Date.ToString();
        //var selectedml = txtmeal.SelectedItem.ToString();
        var id = Guid.NewGuid().ToString();
        if (string.IsNullOrEmpty(txtname.Text))
        {
            await DisplayAlert("Data validation", "Please Fill up Name!", "Got it");
            return;
        }

        else if (string.IsNullOrEmpty(txtbreed.Text))
        {
            await DisplayAlert("Data validation", "Please Fill up Gender!", "Got it");
            return;
        }
        else if (txtgender.SelectedItem == null)
        {
            await DisplayAlert("Data validation", "Please Enter Category Type!", "Got it");
            return;
        }
        //else if (txtbirthday.SelectedItem == null)
        //{
        //    await DisplayAlert("Data validation", "Please Enter Cooking Duration!", "Got it");
        //    return;
        //}

        else if (string.IsNullOrEmpty(txtweight.Text))
        {
            await DisplayAlert("Data validation", "Please Enter Weight!", "Got it");
            return;
        }
        else if (_mainimgResult == null)
        {
            await DisplayAlert("Data validation", "Please Choose a Photo!", "Got it");
            return;
        }


        var adss = await _pets.AddPet(id,
            txtname.Text,
            txtbreed.Text,
            selectedgen,


            txtweight.Text,
            _mainimgResult, id
           );
        if (!adss)
        {
            await DisplayAlert("Warning!", "Data has been failed to add.", "Okay");

        }
        else
        {
            await DisplayAlert("Got it!", "Data has been successfully added.", "Okay");
            txtname.Text = string.Empty;
            txtbreed.Text = string.Empty;
            txtgender.SelectedItem = null;
            txtweight.Text = string.Empty;
            mainimage.Source = srcs;
            Application.Current!.MainPage = new AppShell();

        }
    }


    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Select main image",
            FileTypes = FilePickerFileType.Images
        });
        if (result == null) return;

        FileInfo fi = new(result.FullPath);
        var size = fi.Length;

        if (size > 524288)
        {
            await DisplayAlert("Message", "The image you have selected is more than 0.50MB please ensure that the size of the image is less than the maximum size. Thank you!", "Got It.");
            return;
        }
        var stream = await result.OpenReadAsync();
        _mainimgResult = result;
        mainimage.Source = ImageSource.FromStream(() => stream);
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        //Application.Current!.MainPage = new DisplayRecipe();
    }
}