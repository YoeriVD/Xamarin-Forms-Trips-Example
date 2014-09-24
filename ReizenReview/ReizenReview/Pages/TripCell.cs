using Xamarin.Forms;

namespace ReizenReview.Pages
{
    public class TripCell : ViewCell
    {
        public TripCell()
        {
            
            var grid = new Grid()
            {
                Padding = new Thickness(5, 10, 0, 0),
                ColumnDefinitions =
                {
                    new ColumnDefinition() {Width = new GridLength(90, GridUnitType.Star)},
                    new ColumnDefinition() {Width = new GridLength(10, GridUnitType.Star)}
                },
                RowDefinitions =
                {
                    new RowDefinition(){Height = new GridLength(50, GridUnitType.Star)},
                    new RowDefinition(){Height = new GridLength(50, GridUnitType.Star)}
                }
            };
            Grid.SetColumnSpan(grid.RowDefinitions[1], 2);
            var location = new Label()
            {
                YAlign = TextAlignment.Center,
                XAlign = TextAlignment.Start,
                Font = Font.SystemFontOfSize( 18 , FontAttributes.Bold)
            };
            var score = new Label()
            {
                YAlign = TextAlignment.Center,
                XAlign = TextAlignment.End,
                Font = Font.SystemFontOfSize(26)
            };
            var description = new Label()
            {
                YAlign = TextAlignment.Start,
                XAlign = TextAlignment.Start
            };
            grid.Children.Add(location);
            grid.Children.Add(score, 1, 0);
            grid.Children.Add(description, 0, 1);

            location.SetBinding(Label.TextProperty, "Location");
            score.SetBinding(Label.TextProperty, "AverageScore");
            description.SetBinding(Label.TextProperty, "Description");
            grid.BackgroundColor = Constants.BackgroundColor;
            this.View = grid;
        }
    }
}