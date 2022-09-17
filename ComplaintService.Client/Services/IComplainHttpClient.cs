using System.Net.Http;
using System.Threading.Tasks;

namespace ComplaintService.Client.Services
{
    public interface IComplainHttpClient
    {
        Task<HttpClient> GetClient();
    }
}
