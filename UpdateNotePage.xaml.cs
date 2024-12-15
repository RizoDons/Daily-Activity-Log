namespace noteApp;

public partial class UpdateNotePage : ContentPage
{
    private int _noteId;
    public UpdateNotePage(int noteId)
	{
		InitializeComponent();
        _noteId = noteId;
        LoadNoteDetails();
    }

    private void saveButton_Clicked(object sender, EventArgs e)
    {
        var updatedNote = new Note
        {
            Id = _noteId,
            Title = TitleEntry.Text,
            Date = DateEntry.Text,
            Content = ContentEditor.Text,
            IsDeleted = false
        };

        new DatabaseService().UpdateNote(updatedNote);
        Navigation.PopAsync();
    }

    private void deleteButton_Clicked(object sender, EventArgs e)
    {
        new DatabaseService().DeleteNote(_noteId);
        Navigation.PopAsync();
    }
    private void LoadNoteDetails()
    {
        var note = new DatabaseService().GetNoteById(_noteId);

        if (note != null)
        {
            TitleEntry.Text = note.Title;
            DateEntry.Text = note.Date;
            ContentEditor.Text = note.Content;
        }
    }
}