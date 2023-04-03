using InventoryBeginners.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace InventoryBeginners
{
    public class DataHelper
    {
        public static async Task ManageDataAsync(IServiceProvider serviceProvider)
        {
            //service: an instance of DbContext
            var dbContextServiceProv = serviceProvider.GetRequiredService<InventoryContext>();

            //This is programmatically equivalent to update database.
            await dbContextServiceProv.Database.MigrateAsync();
        } 
    }
}
