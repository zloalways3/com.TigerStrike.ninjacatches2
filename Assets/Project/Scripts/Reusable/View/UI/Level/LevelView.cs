public class LevelView : TextView<int>
{
    private void Start()
    {
        if (!Level.TryGetValue(out var value)) return;

        UpdateText(value);
    }
}