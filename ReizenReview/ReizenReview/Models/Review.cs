using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReizenReview.Annotations;

namespace ReizenReview.Models
{
    public class Review : INotifyPropertyChanged
    {
        private int _score;
        public string Commentary { get; set; }

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged();
            }
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