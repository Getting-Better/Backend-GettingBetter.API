using LearningCenter.API.GettingBetter_System.Domain.Repositories;
using LearningCenter.API.GettingBetter_System.Domain.Services;
using LearningCenter.API.GettingBetter_System.Domain.Services.Communication;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Repositories;

namespace LearningCenter.API.GettingBetter_System.Services;

public class TournamentService : ITournamentService
{
    private readonly ITournamentRepository _tournamentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TournamentService(ITournamentRepository tournamentRepository, IUnitOfWork unitOfWork)
    {
        _tournamentRepository = tournamentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Tournament>> ListAsync()
    {
        return await _tournamentRepository.ListAsync();
    }

    public async Task<TournamentResponse> SaveAsync(Tournament tournament)
    {
        try
        {
            await _tournamentRepository.AddAsync(tournament);
            await _unitOfWork.CompleteAsync();
            return new TournamentResponse(tournament);
        }
        catch (Exception e)
        {
            return new TournamentResponse($"An error occurred while saving the coach: {e.Message}");
        }
    }

    public async Task<TournamentResponse> UpdateAsync(int id, Tournament tournament)
    {
        var existingCoach = await _tournamentRepository.FindByIdAsync(id);

        if (existingCoach == null)
            return new TournamentResponse("Coach not found.");

        existingCoach.Title = tournament.Title;

        try
        {
            _tournamentRepository.Update(existingCoach);
            await _unitOfWork.CompleteAsync();

            return new TournamentResponse(existingCoach);
        }
        catch (Exception e)
        {
            return new TournamentResponse($"An error occurred while updating the coach: {e.Message}");
        }
    }

    public async Task<TournamentResponse> DeleteAsync(int id)
    {
        var existingCoach = await _tournamentRepository.FindByIdAsync(id);

        if (existingCoach == null)
            return new TournamentResponse("Coach not found.");

        try
        {
            _tournamentRepository.Remove(existingCoach);
            await _unitOfWork.CompleteAsync();

            return new TournamentResponse(existingCoach);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new TournamentResponse($"An error occurred while deleting the coach: {e.Message}");
        }
    }
}