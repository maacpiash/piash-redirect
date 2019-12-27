using System.Threading.Tasks;

namespace Redirect
{
    public interface IShortcutService
    {
        public void InitiateList();
        public Task<Shortcut> GetOneShortcut(string key);
    }
}
