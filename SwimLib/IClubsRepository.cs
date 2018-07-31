namespace SwimLib
{
    public interface IClubsRepository
    {
        int Number { get; set; }

        void Add(Club aClub);
        Club GetByRegNum(uint regNumber);
        Club[] Load(string filename, string delimiter);
        void Save(string filename, string delimiter);
    }
}