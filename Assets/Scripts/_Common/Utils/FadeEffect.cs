using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    private static int fadeValueChangeFactor = 10;
    public static IEnumerator FadeIn(GameObject Fade)
    {
        int alpha = 255, i = 0;
        while (i < alpha)
        {
            Fade.GetComponent<Image>().color = new Color32(0, 0, 0, (byte)i);
            i += fadeValueChangeFactor;
            yield return null;
        }
        Fade.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
    }

    public static IEnumerator FadeOut(GameObject Fade)
    {
        int alpha = 0, i = 255;
        while (i > alpha)
        {
            Fade.GetComponent<Image>().color = new Color32(0, 0, 0, (byte)i);
            i -= fadeValueChangeFactor;
            yield return null;
        }
        Fade.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
    }
}
