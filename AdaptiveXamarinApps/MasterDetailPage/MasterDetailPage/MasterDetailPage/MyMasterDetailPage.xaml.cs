using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MasterDetailPage
{
    public partial class MyMasterDetailPage : Xamarin.Forms.MasterDetailPage
    {
        public MyMasterDetailPage()
        {
            InitializeComponent();
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Page 1",
                TargetType = typeof(Page1)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Page 2",
                TargetType = typeof(Page2)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Page 3",
                TargetType = typeof(Page3)
            });
            listView.ItemsSource = masterPageItems;
            listView.ItemSelected += ListView_ItemSelected;
			Detail = new NavigationPage(new Page1());
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                listView.SelectedItem = null;
                //IsPresented = false;
            }

        }
    }

    public class MasterPageItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; } 
    }
}
