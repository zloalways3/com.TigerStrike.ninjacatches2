public class ScoreView : TextView<int>
{
    private void OnEnable()
    {
        UpdateText(Score.Value, LevelTarget.Value);

        Score.Updated += (BalanceValue) => UpdateText(BalanceValue, LevelTarget.Value);
    }

    private void HandleDisabled()
    {
        Score.Updated -= (BalanceValue) => UpdateText(BalanceValue, LevelTarget.Value);
    }
}