

List<Hand> Listofhands = new();
Listofhands = LoadHand.LoadHands();


foreach (var hand in Listofhands)
{

    HandCalculations.DefinePlayersAction(hand);
    
    
}


float minstack = 29f;
float maxstack = 41f;
int bigblindmorethan = 0;

RFI.Calculate_RFI(Listofhands, minstack, maxstack, bigblindmorethan,false);
//CalculateSpecific.Fold_to_sb_pot_bet_after_XX(Listofhands);
System.Console.WriteLine($"Loaded {Listofhands.Count} hands");







