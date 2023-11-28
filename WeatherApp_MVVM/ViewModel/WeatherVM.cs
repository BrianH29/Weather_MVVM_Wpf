using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp_MVVM.Model;

namespace WeatherApp_MVVM.ViewModel
{
    class WeatherVM : INotifyPropertyChanged
    {

        private string query;

        public string Query
        {
            get => query;
            set { 
                query = value; 
                OnPropertyChanged("Query");
            }
        }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get => currentConditions; 
            set 
            { 
                currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get =>selectedCity;
            set
            {  
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        // this is just to check if the binding is working correctly
        public WeatherVM()
        {
            SelectedCity = new City
            {
                LocalizedName = "New York"
            };

            CurrentConditions = new CurrentConditions
            {
                WeatherText = "Partly Cloudy",
                Temperature = new Temperature
                {
                    Metric = new Units
                    {
                        Value = 21
                    }
                }
            };
        }

        //Interface
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
