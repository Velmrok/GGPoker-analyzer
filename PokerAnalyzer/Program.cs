

List<Hand> Listofhands = new();
Listofhands = LoadHand.LoadHands();

int eightmax = 0;
foreach (var hand in Listofhands)
{

    HandCalculations.DefinePlayersAction(hand);

    if (hand.table_limit == 8) eightmax++;
}
System.Console.WriteLine("8 MAX : " +eightmax);
 float minstack = 0;
float maxstack = 500f;


RFItwo.Calculate_RFI(Listofhands,minstack,maxstack);
System.Console.WriteLine($"Loaded {Listofhands.Count} hands");







