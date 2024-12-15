using System.Collections.ObjectModel;
using System.Diagnostics;

namespace noteApp;

public partial class DeletedNotesPages : ContentPage
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
    public DeletedNotesPages()
	{
		InitializeComponent();
        LoadNotes();
        DeletedNotesCollectionView.ItemsSource = Notes;
    }
    private void restoreButton_Clicked(object sender, EventArgs e)
    {
        var selectedNotes = Notes.Where(n => n.IsChecked).ToList(); // Collect checked notes

        foreach (var note in selectedNotes)
        {
            try
            {
                new DatabaseService().RestoreNote(note.Id); // Restore the note in the DB
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error restoring note {note.Id}: {ex.Message}");
            }
        }

        foreach (var note in selectedNotes)
        {
            Notes.Remove(note); 
        }
    }
    private void deleteButton_Clicked(object sender, EventArgs e)
    {
        var selectedNotes = Notes.Where(n => n.IsChecked).ToList(); 

        foreach (var note in selectedNotes)
        {
            try
            {
                new DatabaseService().PermanentlyDeleteNote(note.Id); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting note {note.Id}: {ex.Message}");
            }
        }

        foreach (var note in selectedNotes)
        {
            Notes.Remove(note);
        }
    }
    private void LoadNotes()
    {
        var deletedNotes = new DatabaseService().GetDeletedNotes();
        foreach (var note in deletedNotes)
        {
            note.IsChecked = false;
            Notes.Add(note);
        }
    }                   
    private void DeletedNotesCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}