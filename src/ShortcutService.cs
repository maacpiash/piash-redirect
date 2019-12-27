using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;

namespace Redirect
{
    public class ShortcutService : IShortcutService
    {
      private List<Shortcut> allShortcuts { get; set; }

      private IMongoCollection<Shortcut> allShortcutsCollection { get; set; }

      public ShortcutService()
      {
        var client = new MongoClient("mongodb://username:password@ds056688.mlab.com:56688");
        var database = client.GetDatabase("piash-redirect");
        allShortcutsCollection = database.GetCollection<Shortcut>("shortcuts");
        InitiateList();
      }

      public async void InitiateList()
      {
        allShortcuts = await allShortcutsCollection.Find(x => true).ToListAsync();
      }

      public async Task<Shortcut> GetOneShortcut(string key)
      {
        var list = await allShortcutsCollection.Find(x => x.ShortKey == key).ToListAsync();
        return list.FirstOrDefault();
      }
    }
}
