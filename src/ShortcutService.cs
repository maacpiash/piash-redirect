using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using static System.Environment;

namespace Redirect
{
    public class ShortcutService : IShortcutService
    {
      private readonly IMongoCollection<Shortcut> Shortcuts;

        public ShortcutService()
        {
            var client = new MongoClient(GetEnvironmentVariable("CONNECTIONSTRING"));
            var database = client.GetDatabase(GetEnvironmentVariable("DBNAME"));

            Shortcuts = database.GetCollection<Shortcut>(GetEnvironmentVariable("COLLECTIONNAME"));
        }

        public List<Shortcut> GetAll() => Shortcuts.Find(Shortcut => true).ToList();

        public Shortcut Get(string key) =>
            Shortcuts.Find<Shortcut>(Shortcut => Shortcut.ShortKey == key).FirstOrDefault();

        public Shortcut Create(Shortcut Shortcut)
        {
            Shortcuts.InsertOne(Shortcut);
            return Shortcut;
        }

        public void Update(string key, Shortcut ShortcutIn) =>
            Shortcuts.ReplaceOne(Shortcut => Shortcut.ShortKey == key, ShortcutIn);

        public void Remove(Shortcut ShortcutIn) =>
            Shortcuts.DeleteOne(Shortcut => Shortcut.Id == ShortcutIn.Id);

        public void Remove(string key) => 
            Shortcuts.DeleteOne(Shortcut => Shortcut.ShortKey == key);
    }
}
