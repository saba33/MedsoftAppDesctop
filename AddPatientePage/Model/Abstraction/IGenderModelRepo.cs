using MedSoftAppRepo.Model;

namespace MedsofAppMVP.Model.Abstraction
{
    public interface IGenderModelRepo
    {
        Task<Gender> GetBygenderId(int id);
    }
}
