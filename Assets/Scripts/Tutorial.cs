using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject orangeBox;
    [SerializeField] private GameObject quickTip2;
    [SerializeField] private GameObject quickTip3;

    private void Update()
    {
        if (orangeBox == null)
        {
            if (!quickTip2.activeSelf)
            {
                quickTip2.SetActive(true);
                quickTip3.SetActive(true);
            }
        }
    }
}
