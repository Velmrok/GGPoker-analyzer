public class Player
{
    public Player(int _chips, string _name, string _position, float _blind)
    {
        chips = _chips;
        name = _name;
        position = _position;
        bb_stack = chips / _blind;
        
        
    }
    public string position;
    public Action action;
    public int chips;
    public float bb_stack;
    public string name;
}