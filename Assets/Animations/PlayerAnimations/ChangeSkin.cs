using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public AnimatorOverrideController set1w1,set2w1,set3w1,set4w1,set5w1,set1w2,set2w2,set3w2,set4w2,set5w2,set1w3,set2w3,set3w3,set4w3,set5w3,set1w4,set2w4,set3w4,set4w4,set5w4,
        set1w5,set2w5,set3w5,set4w5,set5w5;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon1)
        {
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin1)
            {
                GetComponent<Animator>().runtimeAnimatorController = set1w1 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin2)
            {
                GetComponent<Animator>().runtimeAnimatorController = set2w1 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin3)
            {
                GetComponent<Animator>().runtimeAnimatorController = set3w1 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin4)
            {
                GetComponent<Animator>().runtimeAnimatorController = set4w1 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin5)
            {
                GetComponent<Animator>().runtimeAnimatorController = set5w1 as RuntimeAnimatorController;
            }
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon2)
        {
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin1)
            {
                GetComponent<Animator>().runtimeAnimatorController = set1w2 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin2)
            {
                GetComponent<Animator>().runtimeAnimatorController = set2w2 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin3)
            {
                GetComponent<Animator>().runtimeAnimatorController = set3w2 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin4)
            {
                GetComponent<Animator>().runtimeAnimatorController = set4w2 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin5)
            {
                GetComponent<Animator>().runtimeAnimatorController = set5w2 as RuntimeAnimatorController;
            }
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon3)
        {
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin1)
            {
                GetComponent<Animator>().runtimeAnimatorController = set1w3 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin2)
            {
                GetComponent<Animator>().runtimeAnimatorController = set2w3 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin3)
            {
                GetComponent<Animator>().runtimeAnimatorController = set3w3 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin4)
            {
                GetComponent<Animator>().runtimeAnimatorController = set4w3 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin5)
            {
                GetComponent<Animator>().runtimeAnimatorController = set5w3 as RuntimeAnimatorController;
            }
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon4)
        {
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin1)
            {
                GetComponent<Animator>().runtimeAnimatorController = set1w4 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin2)
            {
                GetComponent<Animator>().runtimeAnimatorController = set2w4 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin3)
            {
                GetComponent<Animator>().runtimeAnimatorController = set3w4 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin4)
            {
                GetComponent<Animator>().runtimeAnimatorController = set4w4 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin5)
            {
                GetComponent<Animator>().runtimeAnimatorController = set5w4 as RuntimeAnimatorController;
            }
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon5)
        {
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin1)
            {
                GetComponent<Animator>().runtimeAnimatorController = set1w5 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin2)
            {
                GetComponent<Animator>().runtimeAnimatorController = set2w5 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin3)
            {
                GetComponent<Animator>().runtimeAnimatorController = set3w5 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin4)
            {
                GetComponent<Animator>().runtimeAnimatorController = set4w5 as RuntimeAnimatorController;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin5)
            {
                GetComponent<Animator>().runtimeAnimatorController = set5w5 as RuntimeAnimatorController;
            }
        }
    }
    public void set()
    {

    }
}
