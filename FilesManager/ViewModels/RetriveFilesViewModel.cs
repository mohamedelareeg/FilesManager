using FilesManager.Models;
using Microsoft.SqlServer.Server;

namespace FilesManager.ViewModels
{
    public class RetriveFilesViewModel : EntityBase
    {
        public long Id { get; set; }
        public static implicit operator RetriveFilesViewModel(Papers _item)
        {
            return new RetriveFilesViewModel
            {
                Id = _item.Id,
                CreatedDate = _item.CreatedDate,
                ModifiedDate = _item.ModifiedDate,
               
            };
        }

        public static implicit operator Papers(RetriveFilesViewModel vm)
        {
            return new Papers
            {
                Id = vm.Id,
                CreatedDate = vm.CreatedDate,
                ModifiedDate = vm.ModifiedDate,
              

            };
        }

    }
}
