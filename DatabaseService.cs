using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace noteApp
{
    public class DatabaseService
    {
        private readonly SQLiteConnection _connection;
        public DatabaseService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.db");

            _connection = new SQLiteConnection(dbPath);
  
            _connection.CreateTable<Note>();
        }
        public Note GetNoteById(int id)
        {
            return _connection.Table<Note>().FirstOrDefault(n => n.Id == id);
        }

        public List<Note> GetNotes()
        {
            return _connection.Table<Note>().Where(n => !n.IsDeleted).ToList();
        }


        public void AddNote(Note note)
        {
            _connection.Insert(note);
        }


        public void UpdateNote(Note note)
        {
            _connection.Update(note);
        }


        public void DeleteNote(int id)
        {
            var note = _connection.Get<Note>(id);
            if (note != null)
            {
                note.IsDeleted = true;
                _connection.Update(note);
            }
        }


        public List<Note> GetDeletedNotes()
        {
            return _connection.Table<Note>().Where(n => n.IsDeleted).ToList();
        }


        public void RestoreNote(int id)
        {
            var note = _connection.Get<Note>(id);
            if (note != null)
            {
                note.IsDeleted = false;
                _connection.Update(note);
            }
        }

        public void PermanentlyDeleteNote(int id)
        {
            _connection.Delete<Note>(id);
        }
    }
}
