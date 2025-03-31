

List<Hand> Listofhands = new();
Listofhands = LoadHand.LoadHands();

int eightmax = 0;
foreach (var hand in Listofhands)
{

    HandCalculations.DefinePlayersAction(hand);

    if (hand.table_limit == 8) eightmax++;
}


float minstack = 0f;
float maxstack = 15f;
int bigblindmorethan = 0;

RFI.Calculate_RFI(Listofhands,minstack,maxstack,bigblindmorethan);
System.Console.WriteLine($"Loaded {Listofhands.Count} hands");







