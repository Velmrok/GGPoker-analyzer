public class DefPlayerSeat
{
     public static string DefinePlayerSeat(int i, int table_limit, string[] hand)
    {
        Dictionary<int, string> Position = HandCalculations.PositionNumbersDictionary;
        int seat = i - 1;
        int button_seat = 0;

        for (int j = 1; j < hand[1].Length; j++)
        {
            if (hand[1][j - 1] == 'i' && hand[1][j] == 's')
            {
                button_seat = int.Parse(hand[1][j - 3].ToString());
                break;
            }
        }
        for (int j = 2; j < 12; j++)
        {
            if (hand[j].Contains($"Seat {button_seat}"))
            {
                button_seat = j-1;
                break;
            }
        }
        
        if (seat < button_seat) seat += table_limit;
        //System.Console.WriteLine(seat - button_seat);
        switch (seat - button_seat)
        {
            case 0:
                return "btn";
            case 1:
                return "sb";
            case 2:
                return "bb";
            case 3:
                return Position[9-table_limit];
            case 4:
               return Position[10-table_limit];
            case 5:
             return Position[11-table_limit];
            case 6:
               return Position[12-table_limit];
            case 7:
                return Position[13 - table_limit];
            case 8:
                return "co";
            default:
                break;
        }
        return "ERROR";
        
    }
}