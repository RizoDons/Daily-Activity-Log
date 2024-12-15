namespace noteApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnSignInClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "nat" && password == "nat")
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password. Please try again.", "OK");
            }
        }

    }

}
