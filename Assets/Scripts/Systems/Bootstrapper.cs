using UnityEngine;

public static class Bootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Exec() => Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("GameSystems")));
}
