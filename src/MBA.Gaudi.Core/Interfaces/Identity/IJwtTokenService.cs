using System.Security.Claims;

namespace MBA.Gaudi.Core.Interfaces.Identity
{
    public interface IJwtTokenService
    {
        string GerarToken(Guid usuarioId, string email, string nome);
        string GerarToken(IEnumerable<Claim> claims);
    }
}
