using System;
using UIKit;

namespace MoviesCollection.iOS
{
    public partial class TabBarController : UITabBarController
    {
        public TabBarController(IntPtr handle) : base(handle)
        {
            TabBar.Items[0].Title = "Movies";
            TabBar.Items[1].Title = "Favourites";
        }
    }
}
