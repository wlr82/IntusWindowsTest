using DE = DAL.Entities;

namespace DTO.Window
{
    public class WindowDTO
    {
        public DE.Window Window { get; set; } = new DE.Window();
        public int SubElementsCount { get; set; }
    }
}
