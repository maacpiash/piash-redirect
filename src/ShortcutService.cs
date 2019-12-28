using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;

namespace Redirect
{
    public class ShortcutService
    {
      private readonly IMongoCollection<Shortcut> _Shortcuts;

        public ShortcutService(IShortcutDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Shortcuts = database.GetCollection<Shortcut>(settings.CollectionName);
        }

        public List<Shortcut> Get() =>
            _Shortcuts.Find(Shortcut => true).ToList();

        public Shortcut Get(string key) =>
            _Shortcuts.Find<Shortcut>(Shortcut => Shortcut.ShortKey == key).FirstOrDefault();

        public Shortcut Create(Shortcut Shortcut)
        {
            _Shortcuts.InsertOne(Shortcut);
            return Shortcut;
        }

        public void Update(string id, Shortcut ShortcutIn) =>
            _Shortcuts.ReplaceOne(Shortcut => Shortcut.Id == id, ShortcutIn);

        public void Remove(Shortcut ShortcutIn) =>
            _Shortcuts.DeleteOne(Shortcut => Shortcut.Id == ShortcutIn.Id);

        public void Remove(string id) => 
            _Shortcuts.DeleteOne(Shortcut => Shortcut.Id == id);
    }
}
