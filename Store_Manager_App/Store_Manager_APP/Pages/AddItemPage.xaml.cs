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
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
        }

        private async void AddNewItem(object sender, EventArgs e)
        {
            Inventory item = (Inventory) BindingContext;
            InventoryClient inventoryClient = new InventoryClient();
            await inventoryClient.PostItemAsync(item);
            await Navigation.PopAsync();
        }
    }
}