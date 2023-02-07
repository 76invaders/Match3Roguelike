using UnityEngine;

public static class TilesBank
{
    public static Gem[] gems { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] private static void Initialize() => gems = Resources.LoadAll<Gem>("Gems/");
}