using System;
using System.Diagnostics;
using UIKit;

namespace MoviesCollection.iOS
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        public MovieDetailViewModel ViewModel { get; set; }
        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            try
            {
                Title = ViewModel.Title;
                ItemNameLabel.Text = ViewModel.Item.Title;
                ItemDescriptionLabel.Text = ViewModel.Item.Overview;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
        }
    }
}
