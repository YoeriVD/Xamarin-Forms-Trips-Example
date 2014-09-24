using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ReizenReview.Annotations;

namespace ReizenReview.Models
{
    public class Trip : INotifyPropertyChanged
    {
        public string Location { get; set; }
        public string Description { get; set; }

        public int AverageScore
        {
            get {
                return Reviews.Count > 0
                    ? (int)Math.Round((double)(Reviews.Sum(review => review.Score)/Reviews.Count))
                    : 5; }
        }

        public ObservableCollection<Review> Reviews { get; set; }

        public Trip()
        {
            Reviews = new ObservableCollection<Review>();
            Reviews.CollectionChanged += (sender, args) => OnPropertyChanged("AverageScore");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
