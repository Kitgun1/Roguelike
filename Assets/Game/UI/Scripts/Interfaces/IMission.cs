public interface IMission
{
    public void AddMission(string tagName, string description, int done, int need);
    public void ChangeMission(string tagName, string description = null, int? doneAdd = null, int? needAdd = null);
    public void RemoveMission(string tagName);
}