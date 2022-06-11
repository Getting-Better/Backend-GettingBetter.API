using LearningCenter.API.GettingBetter_System.Domain.Repositories;
using LearningCenter.API.GettingBetter_System.Domain.Services;
using LearningCenter.API.GettingBetter_System.Domain.Services.Communication;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Repositories;

namespace LearningCenter.API.GettingBetter_System.Services;

public class AdvisoryService : IAdvisoryService
{ private readonly IAdvisoryRepository _advisoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AdvisoryService(IAdvisoryRepository advisoryRepository, IUnitOfWork unitOfWork)
    {
        _advisoryRepository = advisoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Advisory>> ListAsync()
    {
        return await _advisoryRepository.ListAsync();
    }

    public async Task<AdvisoryResponse> SaveAsync(Advisory advisory)
    {
        try
        {
            await _advisoryRepository.AddAsync(advisory);
            await _unitOfWork.CompleteAsync();
            return new AdvisoryResponse(advisory);
        }
        catch (Exception e)
        {
            return new AdvisoryResponse($"An error occurred while saving the advisory: {e.Message}");
        }
    }

    public async Task<AdvisoryResponse> UpdateAsync(int id, Advisory advisory)
    {
        var existingAdvisory = await _advisoryRepository.FindByIdAsync(id);

        if (existingAdvisory == null)
            return new AdvisoryResponse("Advisory not found.");

        existingAdvisory.CoachId = advisory.CoachId; 

        try
        {
            _advisoryRepository.Update(existingAdvisory);
            await _unitOfWork.CompleteAsync();

            return new AdvisoryResponse(existingAdvisory);
        }
        catch (Exception e)
        {
            return new AdvisoryResponse($"An error occurred while updating the coach: {e.Message}");
        }
    }

    public async Task<AdvisoryResponse> DeleteAsync(int id)
    {
        var existingCoach = await _advisoryRepository.FindByIdAsync(id);

        if (existingCoach == null)
            return new AdvisoryResponse("Coach not found.");

        try
        {
            _advisoryRepository.Remove(existingCoach);
            await _unitOfWork.CompleteAsync();

            return new AdvisoryResponse(existingCoach);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new AdvisoryResponse($"An error occurred while deleting the coach: {e.Message}");
        }
    } 
}