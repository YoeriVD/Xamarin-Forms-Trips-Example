using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReizenReview.Models;
using Xamarin.Forms;

namespace ReizenReview.ViewModels
{
    public class AddReviewViewModel : ViewModelBase
    {
        public ObservableCollection<Review> Reviews { get; set; }
        private Review _newReview;

        public Review NewReview
        {
            get { return _newReview; }
            set
            {
                if (value == _newReview) return;
                _newReview = value;
                RaisePropertyChanged();
            }
        }
        public Action OnFinished { get; set; }
        public ICommand AddCommand
        {
            get
            {
                return new Command(() =>
                    {
                        Reviews.Add(NewReview);
                        Clear();
                        OnFinished.Invoke();
                    });
            }
        }
        public void Clear()
        {
            NewReview = new Review() { Score = 5 };
        }

        public AddReviewViewModel()
        {
            Clear();
        }


    }
}
