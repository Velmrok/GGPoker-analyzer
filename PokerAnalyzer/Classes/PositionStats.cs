public class PositionStats
{
    public int AllHands { get; set; } = 0;
    public int OpenShovedHands { get; set; } = 0;
    public int OpenLimpedHands { get; set; } = 0;
    public int OpenedHands { get; set; } = 0;

    public float RFI_Percentage => AllHands == 0 ? 0 : (float)OpenedHands / AllHands * 100f;
    public float OpenShove_Percentage => AllHands == 0 ? 0 : (float)OpenShovedHands / AllHands * 100f;
    public float OpenLimp_Percentage => AllHands == 0 ? 0 : (float)OpenLimpedHands / AllHands * 100f;

    public override string ToString()
    {
        return $"RFI: {Math.Round(RFI_Percentage, 1)}% | " +
               $"Shove: {Math.Round(OpenShove_Percentage, 1)}% | " +
               $"Limp: {Math.Round(OpenLimp_Percentage, 4)}% | " +
               $"Opened: {OpenedHands+OpenLimpedHands+OpenShovedHands} / All: {AllHands}";
    }
}