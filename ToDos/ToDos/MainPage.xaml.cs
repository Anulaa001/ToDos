using System;
using System.IO;
using ToDos.Data;
using Xamarin.Forms;

namespace ToDos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            var toDos = await App.DB.getTodosAsync();

            foreach (var toDo in toDos)
            {
                toDo.Image = Device.RuntimePlatform == Device.Android ?
                    "xamarin.png" :
                    Path.Combine("Assets", "xamarin.png");
            }

            BindingContext = toDos;
            base.OnAppearing();
        }

        private async void ToolbarAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDoPage()
            {
                BindingContext = new ToDo() { }
            });
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as ToDo;

            await Navigation.PushAsync(new ToDoPage()
            {
                BindingContext = item
            });
        }
    }
}
