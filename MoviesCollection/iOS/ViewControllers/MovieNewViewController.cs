using System;
using MoviesCollection.Models;
using UIKit;

namespace MoviesCollection.iOS
{
    public partial class MovieNewViewController : UIViewController
    {
        public MovieViewModel ViewModel { get; set; }

        public MovieNewViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnSaveItem.TouchUpInside += (sender, e) =>
            {
                var item = new Genre
                {
                    Name = txtTitle.Text
                };
                ViewModel.AddItemCommand.Execute(item);
                NavigationController.PopToRootViewController(true);
            };
        }
    }
}
