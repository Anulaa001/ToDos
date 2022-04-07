
using ToDos.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage : ContentPage
    {
        public ToDoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var toDo = (ToDo)BindingContext;
            BindingContext = new ToDoAction() { ToDo = toDo, Action = toDo.ID == 0 ? "Add" : "Modify" };
            base.OnAppearing();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            App.DB.addOrUpdateToDoAsync(((ToDoAction)BindingContext).ToDo); //dodanie do bazy
            Navigation.PopAsync(); // powtót do listy
        }
    }

    class ToDoAction
    {
        public string Action { get; set; }
        public ToDo ToDo { get; set; }
    }
}