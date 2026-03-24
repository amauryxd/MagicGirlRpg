using System.Collections.Generic;
using UnityEngine;

public class RotacionSelect : MonoBehaviour
{
    public GameObject toRotacion;
    public float duracion = 5f; 
    public float anguloMaximo;
    public float exponente = 3f; 
    public bool canRotate = true;
    private float tiempo = 0f;
    public SpriteRenderer actualSprite;
    public List<Sprite> sprites;
    public delegate void OnAttackAnimFinished(int id);
    public static event OnAttackAnimFinished attackAnimFinished;

    void FixedUpdate()
    {
        if(canRotate)
        RotateCosa();
    }

    public void RotateCosa()
    {
        tiempo += Time.deltaTime;
        float t = tiempo / duracion;
        float factor = Mathf.Pow(t, exponente);
        float angulo = factor * anguloMaximo;
        
        toRotacion.transform.rotation = Quaternion.Euler(0, angulo, 0);

        if (tiempo >= duracion)
        {
            tiempo = 0f;
            canRotate = false;
        }
    }
    public void ChangeSprite(SpriteType type)
    {
        if(sprites.Count <= 0) return;

        switch (type)
        {
            case SpriteType.Idle:
                actualSprite.sprite = sprites[0];
                break;
            case SpriteType.Select:
                actualSprite.sprite = sprites[1];
                break;
            case SpriteType.Attack:
                actualSprite.sprite = sprites[2];
                break;
        }
    }
    public void SHakeCameraAttack()
    {
        CameraShaker.Instance.ShakeThisCamera(0.2f, 0.1f);
    }
    public void animRotateRef()
    {
        canRotate = true;
    }
    public void OnAttackAnimFinishedRef()
    {
        attackAnimFinished?.Invoke(GetComponent<TurnLogic>().id);
    }
}
public enum SpriteType
{
    Idle,
    Select,
    Attack,
}