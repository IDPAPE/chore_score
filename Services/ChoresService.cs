

namespace chore_score.Services;
public class ChoresService
{
    private readonly ChoresRespository _choresRepository;

    public ChoresService(ChoresRespository choresRespository)
    {
        _choresRepository = choresRespository;
    }

    public List<Chore> GetAllChores()
    {
        List<Chore> chores = _choresRepository.GetAllChores();
        return chores;
    }

    internal Chore CreateChore(Chore choreData)
    {
        Chore chore = _choresRepository.CreateChore(choreData);
        return chore;
    }


    internal Chore GetChoreById(int choreId)
    {
        Chore chore = _choresRepository.GetChoreById(choreId);

        if (chore == null)
        {
            throw new Exception($"Could not find chore with id: {choreId}");
        }

        return chore;
    }
    internal string DestroyChore(int choreId)
    {
        Chore choreToDestroy = GetChoreById(choreId);

        _choresRepository.DestroyChore(choreId);

        return $"{choreToDestroy.name} has been removed from the list";
    }
}