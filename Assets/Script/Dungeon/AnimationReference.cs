using UnityEngine;

public class AnimationReference : MonoBehaviour
{
    public Movement mov;
    public Animator anim;
    public GameObject NozSprite;

    private void Update()
    {
        if(mov.controllerInput != Vector2.zero && mov.speed != 0)
        {
            anim.SetBool("IsWalking",true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
        if(mov.controllerInput.x > 0 && mov.speed != 0)
        {
            NozSprite.transform.localEulerAngles = new Vector2(0,180f);
        }
        if (mov.controllerInput.x < 0 && mov.speed != 0)
        {
            NozSprite.transform.localEulerAngles = new Vector2(0, 0f);
        }
    }
    public void animsInteract()
    {
        anim.SetTrigger("Interacted");
    }
}
