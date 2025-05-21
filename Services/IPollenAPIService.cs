using System.Threading.Tasks;

namespace Eksamen2025Gruppe5.Services
{
    public interface IPollenAPIService
    {
        Task<string?> HentPollenDataAsync();
    }
}
