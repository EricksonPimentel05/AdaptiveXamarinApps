using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MasterDetailContentViews
{
    public partial class MyMasterDetailPage : MasterDetailPage
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
            if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
            {
                masterPageItems.Add(new MasterPageItem
                {
                    Title = "Page 3",
                    TargetType = typeof(Page3Tabbed)
                });
            }
            else
            {
                masterPageItems.Add(new MasterPageItem
                {
                    Title = "Page 3",
                    TargetType = typeof(Page3Single)
                });
            }
                
            listView.ItemsSource = masterPageItems;
            listView.ItemSelected += ListView_ItemSelected;
			Detail = new NavigationPage(new Page1());
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                if(item.Title.Equals("Page 1"))
                {
					Detail = new NavigationPage(new Page1());
                }
                else if(item.Title.Equals("Page 2"))
                {
					Detail = new NavigationPage(new Page2());
                }
                else if(item.Title.Equals("Page 3"))
                {
                    if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
                    {
						Detail = new Page3Tabbed();
                    }
                    else
                    {
						Detail = new NavigationPage(new Page3Single());
                    }
                }
                
                listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }

    public class MasterPageItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}
