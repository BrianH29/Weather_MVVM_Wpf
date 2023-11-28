using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp_MVVM.Model;
using WeatherApp_MVVM.ViewModel.Commands;
using WeatherApp_MVVM.ViewModel.Helpers;

namespace WeatherApp_MVVM.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
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

        public SearchCommand SearchCommand { get; set; }

        // this is just to check if the binding is working correctly
        public WeatherVM()
        {
            /*
             * if this is true, it means that we are currently not running the application and 
             * we're currently only designing the application
             * Then if this is false, then all of this won't be executed.
             */
            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
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

            SearchCommand = new SearchCommand(this);
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);
        }

        //Interface
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
