using System;
using System.Collections.Generic;
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
    public partial class DashTabPage : ContentPage
    {
        public DashTabPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            DashboardClient dashboardClient = new DashboardClient();
            Dashboard dashboard = await dashboardClient.GetDashboardAsync();
            BindingContext =dashboard;
        }

        private async void OnItemAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage
            {
                BindingContext = new Inventory()
            });
        }

        private async void OnBillCreate(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateBillPage
            {
                BindingContext = new Bills()
            });
        }
    }
}