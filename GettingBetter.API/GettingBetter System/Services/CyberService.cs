using LearningCenter.API.GettingBetter_System.Domain.Repositories;
using LearningCenter.API.GettingBetter_System.Domain.Services;
using LearningCenter.API.GettingBetter_System.Domain.Services.Communication;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;
using LearningCenter.API.Shared.Domain.Repositories;

namespace LearningCenter.API.GettingBetter_System.Services;

public class CyberService : ICyberService
{
  private readonly ICyberRepository _cyberRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CyberService(ICyberRepository cyberRepository, IUnitOfWork unitOfWork)
    {
        _cyberRepository = cyberRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Cyber>> ListAsync()
    {
        return await _cyberRepository.ListAsync();
    }

    public async Task<CyberResponse> SaveAsync(Cyber cyber)
    {
        try
        {
            await _cyberRepository.AddAsync(cyber);
            await _unitOfWork.CompleteAsync();
            return new CyberResponse(cyber);
        }
        catch (Exception e)
        {
            return new CyberResponse($"An error occurred while saving the cyber: {e.Message}");
        }
    }

    public async Task<CyberResponse> UpdateAsync(int id, Cyber cyber)
    {
        var existingCyber = await _cyberRepository.FindByIdAsync(id);

        if (existingCyber == null)
            return new CyberResponse("Cyber not found.");

        existingCyber.FirstName = cyber.FirstName;

        try
        {
            _cyberRepository.Update(existingCyber);
            await _unitOfWork.CompleteAsync();

            return new CyberResponse(existingCyber);
        }
        catch (Exception e)
        {
            return new CyberResponse($"An error occurred while updating the cyber: {e.Message}");
        }
    }

    public async Task<CyberResponse> DeleteAsync(int id)
    {
        var existingCyber = await _cyberRepository.FindByIdAsync(id);

        if (existingCyber == null)
            return new CyberResponse("Cyber not found.");

        try
        {
            _cyberRepository.Remove(existingCyber);
            await _unitOfWork.CompleteAsync();

            return new CyberResponse(existingCyber);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CyberResponse($"An error occurred while deleting the cyber: {e.Message}");
        }
    }
}