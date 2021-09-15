using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Manager_APP.Data;
using Store_Manager_APP.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Store_Manager_APP.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillsTabPage : ContentPage
    {
        public BillsTabPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            BillsClient billsClient = new BillsClient();
            List<Bills> bills = await billsClient.GetBillsAsync();
            var trends = new ObservableCollection<Bills>(bills);
            BillsList.ItemsSource = trends;
        }

        private async void OnListViewBillSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new BillDetailsPage
                {
                    BindingContext = e.SelectedItem as Bills
                });
            }
        }

        private async void OnBillCreateClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new CreateBillPage
           {
               BindingContext = new Bills()
           });
        }
    }
}