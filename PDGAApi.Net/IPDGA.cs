using PDGAApi.Net.Models;
using System.Threading.Tasks;

namespace PDGAApi.Net
{
    public interface IPDGA
    {
        Task<PlayerInformationResponse> GetPlayerInformation(int pdgaNumber);
        Task<LoginResponse> Login(string username, string password);
        Task<bool> Logout(string token);
    }
}