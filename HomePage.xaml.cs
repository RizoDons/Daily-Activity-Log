namespace noteApp;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        LoadNotes();
    }
    private async void addNote_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddNotePage());
    }
    private void LoadNotes()
    {
        var notes = new DatabaseService().GetNotes();
        NotesCollectionView.ItemsSource = notes;
    }

    private async void settingsButton_Clicked(object sender, EventArgs e)
    {

    }
    private async void OnNoteSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Note selectedNote)
        {
            int noteId = selectedNote.Id;
            await Navigation.PushAsync(new UpdateNotePage(noteId));
        }
        NotesCollectionView.SelectedItem = null;
    }
}