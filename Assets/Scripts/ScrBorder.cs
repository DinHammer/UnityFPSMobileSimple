using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBorder : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<BaseBullet>(out BaseBullet baseBullet))
        {
            baseBullet.Deactivation();
        }
    }
}
