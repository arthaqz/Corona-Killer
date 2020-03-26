using UnityEngine;


public class Character : MonoBehaviour
{
    public GameObject playerDiedEffect;

    protected void DeadEffect()
    {
        Instantiate(playerDiedEffect, transform.position, Quaternion.identity, TempParent.Instance.transform);
    }
}
