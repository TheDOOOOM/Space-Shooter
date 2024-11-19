using System.Collections.Generic;

namespace Boootstrapp.Services
{
    public class DisposeService : IService
    {
        private List<IDisposibleItem> _disposibleItems = new List<IDisposibleItem>();

        public void AddItem(IDisposibleItem disposibleItem)
        {
            _disposibleItems.Add(disposibleItem);
        }

        public void DisposeActive()
        {
            foreach (var item in _disposibleItems)
            {
                item.DisposeActivate();
                _disposibleItems.Remove(item);
            }
        }
    }
}