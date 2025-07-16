using System.Threading.Tasks;

namespace NHC.Abp.Data;

public interface IAbpDbSchemaMigrator
{
    Task MigrateAsync();
}
