using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReizenReview.Models;
using Xamarin.Forms;

namespace ReizenReview.ViewModels
{
    public class TripViewModel : ViewModelBase
    {
        private Trip _trip;

        public Trip Trip
        {
            get { return _trip; }
            set
            {
                if (value == _trip) return;
                _trip = value;
                RaisePropertyChanged();
            }
        }

        public ICommand AddCommand { get; set; }
    }
}
