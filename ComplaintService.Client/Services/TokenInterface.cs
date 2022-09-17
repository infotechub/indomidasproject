using IdentityModel.Client;
using System.Threading.Tasks;

namespace ComplaintService.Client.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
