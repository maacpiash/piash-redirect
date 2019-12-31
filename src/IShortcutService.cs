using System.Collections.Generic;

namespace Redirect
{
    public interface IShortcutService
    {
        public Shortcut Get(string key);
        public List<Shortcut> GetAll();
        public Shortcut Create(Shortcut Shortcut);
        public void Update(string key, Shortcut ShortcutIn);
        public void Remove(Shortcut ShortcutIn);
        public void Remove(string key);
    }
}
