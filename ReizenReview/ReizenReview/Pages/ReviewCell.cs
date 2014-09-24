using Xamarin.Forms;

namespace ReizenReview.Pages
{
    public class ReviewCell : ViewCell
    {
        public ReviewCell()
        {
            var grid = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition() {Width = GridLength.Auto},
                    new ColumnDefinition() {Width = new GridLength(10, GridUnitType.Absolute)}
                }
            };
            var commentary = new Label();
            commentary.SetBinding(Label.TextProperty, "Commentary");
            var score = new Label()
            {
                YAlign = TextAlignment.Center,
                XAlign = TextAlignment.Center
            };
            score.SetBinding(Label.TextProperty, "Score");
            grid.Children.Add(commentary);
            grid.Children.Add(score, 1, 0);

            grid.BackgroundColor = App.Constants.BackgroundColor;

            this.View = grid;
        }
    }
}