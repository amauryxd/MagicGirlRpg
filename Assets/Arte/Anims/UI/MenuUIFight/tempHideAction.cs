using System.Collections;
using UnityEngine;

public class tempHideAction : MonoBehaviour
{
    public Animator animator;
    public void HideAction()
    {
        animator.SetTrigger("Hide");
    }
}
