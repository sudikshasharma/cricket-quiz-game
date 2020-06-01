using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BlipEffect : MonoBehaviour
{
    private int fadeValueChanger = 20;
    public static IEnumerator Blipper(GameObject colorOrig, Color32 blipColor)
    {
        int i = 0, alpha = 1600;
        var originalColor = colorOrig.GetComponent<RawImage>().color;
        //////For normal colour change
        colorOrig.GetComponent<RawImage>().color = blipColor;
        while (i < alpha)
        {
            i += 20;
            yield return null;
        }
        colorOrig.GetComponent<RawImage>().color = originalColor;
        //////For blip effect
        // int alpha = 1600, i = 0;
        // bool isOriginal = true;
        // while (i < alpha)
        // {
        //     if (isOriginal)
        //     {
        //         colorOrig.GetComponent<RawImage>().color = blipColor;
        //     }
        //     else
        //     {
        //         colorOrig.GetComponent<RawImage>().color = originalColor;
        //     }
        //     isOriginal = !isOriginal;
        //     i += 20;
        //     yield return null;
        // }
    }
}
