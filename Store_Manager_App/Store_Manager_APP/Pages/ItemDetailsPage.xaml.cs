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
    public partial class ItemDetailsPage : ContentPage
    {
        public ItemDetailsPage()
        {
            InitializeComponent();
        }

        public async void DeleteClicked(object sender, EventArgs e)
        {
            var confirm = await DisplayAlert("Confirm", "Are you sure you Want to Delete this Item?", "Yes", "No");
            if (confirm)
            {
                InventoryClient inventoryClient = new InventoryClient();
                Inventory inventory = (Inventory)BindingContext;
                await inventoryClient.DeleteItemAsync(inventory.Id);
                await Navigation.PopAsync();
            }

            await Navigation.PopAsync();

        }

        public async void UpdateClicked(object sender, EventArgs e)
        {
            InventoryClient inventoryClient = new InventoryClient();
            Inventory inventory = (Inventory) BindingContext;
            await inventoryClient.PutItemAsync(inventory.Id, inventory);
            await Navigation.PopAsync();
        }
    }
}