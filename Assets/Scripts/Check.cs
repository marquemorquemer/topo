using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public static bool enSuelo;
    public static bool enMuralla;
    public bool muralla = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            if (muralla)
            {
                enMuralla = true;
            }
            else
            {
                enSuelo = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            if (muralla)
            {
                enMuralla = false;
            }
            else
            {
                enSuelo = false;
            }
        }
    }
}
