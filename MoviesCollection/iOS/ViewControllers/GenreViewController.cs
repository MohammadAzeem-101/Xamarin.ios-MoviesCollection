using System;
using System.Collections.Specialized;
using System.ComponentModel;
using Foundation;
using MoviesCollection.ViewModels;
using UIKit;

namespace MoviesCollection.iOS.ViewControllers
{
    public partial class GenreViewController : UITableViewController
    {
        UIRefreshControl refreshControl;

        public GenreListViewModel ViewModel { get; set; }

        public GenreViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            ViewModel = new GenreListViewModel();
            // Setup UITableView.
            refreshControl = new UIRefreshControl();
            refreshControl.ValueChanged += RefreshControl_ValueChanged;
            TableView.Add(refreshControl);
            TableView.Source = new GenreDataSource(ViewModel);

            Title = ViewModel.Title;

            ViewModel.PropertyChanged += IsBusy_PropertyChanged;
            ViewModel.Genres.CollectionChanged += Items_CollectionChanged;
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            InvokeOnMainThread(() => TableView.ReloadData());
        }

        private void IsBusy_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            switch (propertyName)
            {
                case nameof(ViewModel.IsBusy):
                    {
                        InvokeOnMainThread(() =>
                        {
                            if (ViewModel.IsBusy && !refreshControl.Refreshing)
                                refreshControl.BeginRefreshing();
                            else if (!ViewModel.IsBusy)
                                refreshControl.EndRefreshing();
                        });
                    }
                    break;
            }
        }

        private void RefreshControl_ValueChanged(object sender, EventArgs e)
        {
            if (!ViewModel.IsBusy && refreshControl.Refreshing)
                ViewModel.LoadItemsCommand.Execute(null);
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (ViewModel.Genres.Count == 0)
                ViewModel.LoadItemsCommand.Execute(null);
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    class GenreDataSource : UITableViewSource
    {
        static readonly NSString CELL_IDENTIFIER = new NSString("ITEM_CELL");

        GenreListViewModel viewModel;

        public GenreDataSource(GenreListViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => viewModel.Genres.Count;
        public override nint NumberOfSections(UITableView tableView) => 1;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CELL_IDENTIFIER, indexPath);

            var item = viewModel.Genres[indexPath.Row];
            cell.TextLabel.Text = item.Name;
            //cell.DetailTextLabel.Text = item.Name;
            cell.LayoutMargins = UIEdgeInsets.Zero;
            return cell;
        }
    }
}

