namespace noteApp;

public partial class AddNotePage : ContentPage
{
	public AddNotePage()
	{
		InitializeComponent();
	}

    private void saveButton_Clicked(object sender, EventArgs e)
    {
        var newNote = new Note
        {
            Title = TitleEntry.Text,
            Date = DateEntry.Text,
            Content = ContentEditor.Text,
            IsDeleted = false
        };

        new DatabaseService().AddNote(newNote);
        Navigation.PopAsync();
    }

    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}