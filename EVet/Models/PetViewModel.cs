using EVet.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace EVet.Models
{
    public class PetViewModel : INotifyPropertyChanged
    {
        private Pets _selectedPet;
        public ObservableCollection<Pets> Pet { get; set; }

        public Pets SelectedPet
        {
            get => _selectedPet;
            set
            {
                _selectedPet = value;
                OnPropertyChanged(nameof(SelectedPet));
            }
        }

        public PetViewModel()
        {
            // Load your pets here
            Pet = new ObservableCollection<Pets>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
