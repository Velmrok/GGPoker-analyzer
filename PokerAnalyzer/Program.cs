

List<Hand> Listofhands = new();
Listofhands = LoadHand.LoadHands();


foreach (var hand in Listofhands)
{

    HandCalculations.DefinePlayersAction(hand);
    
    
}


float minstack = 0f;
float maxstack = 15f;
int bigblindmorethan = 0;

RFI.Calculate_RFI(Listofhands, minstack, maxstack, bigblindmorethan);
CalculateSpecific.Fold_to_sb_pot_bet_after_XX(Listofhands);
System.Console.WriteLine($"Loaded {Listofhands.Count} hands");







