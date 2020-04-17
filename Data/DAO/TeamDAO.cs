namespace Data.DAO
{
    public class TeamDAO:ITeamDAO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
        public TeamType TeamType { get; set; }
        
    }
}
