using System;
using System.Collections.Generic;
using Store_Manager_APP.Data;
using Store_Manager_APP.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Store_Manager_APP.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateBillPage : ContentPage
    {
        public CreateBillPage()
        {
            InitializeComponent();
        }

        private Bills _bill = new Bills();

        private List<Inventory> Inventory { get; set; }

        protected  override async void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = _bill;
            InventoryClient inventoryClient = new InventoryClient();
            Inventory = await inventoryClient.GetInventoryAsync();
            List<string> names = new List<string>();
            foreach (var item in Inventory)
            {
                string format = item.Name +" , " +item.Size;
                names.Add(format);
            }
            ItemsPicker.ItemsSource = names;
        }

        private async void CreateNewBill(object sender, EventArgs e)
        {
            BillsClient billsClient = new BillsClient();
            _bill = (Bills) BindingContext;
            await billsClient.PostBillAsync(_bill);
            await Navigation.PopAsync();
        }

        private void ItemSelected(object sender, EventArgs e)
        {
            string format = ItemsPicker.SelectedItem.ToString();
            string[] split = format.Split(',');
            _bill = (Bills)BindingContext;
            string name = split[0];
            name = name.Replace(" ", String.Empty);
            string size = split[1];
            size = size.Replace(" ", String.Empty);
            foreach (var item in Inventory)
            {
                if (item.Name.Equals(name) && item.Size.Equals(size))
                {
                    _bill.Items.Add(new Item
                    {
                        BillId = _bill.Id,
                        ItemId = item.Id,
                        Name = item.Name,
                        Type = item.Type,
                        Price = item.Price,
                        Size = item.Size,
                        Quantity = 1
                    });
                }
            }
            BillItemsList.ItemsSource = null;
            BillItemsList.ItemsSource = _bill.Items;
        }

        private void QuantityChanged(object sender, TextChangedEventArgs e)
        {
            _bill = (Bills) BindingContext;
        }
    }
}