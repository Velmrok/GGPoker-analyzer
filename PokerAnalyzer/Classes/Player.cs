public class Player
{
    public Player(int _chips, string _name, string _position)
    {
        chips = _chips;
        name = _name;
        position = _position;
       
    }
    public string position;
    public Action action;
    public int chips;

    public string name;
}