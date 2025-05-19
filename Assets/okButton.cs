using UnityEngine;

public class okButton : MonoBehaviour
{
    public transitionGameplay transition;

    public void OnOkPressed()
    {
        if (transition != null)
        {
            transition.BeginFadeAndLoad();
        }
    }
}
