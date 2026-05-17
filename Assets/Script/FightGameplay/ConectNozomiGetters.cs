using UnityEngine;

public class ConectNozomiGetters : MonoBehaviour
{
    [Header("Nozomi Ref")]
    public NozomiTurn nozTurn;
    [Header("Rotate Variables")]
    public GameObject toRotacion;
    public float duracion = 5f; 
    public float anguloMaximo;
    public float exponente = 3f; 
    public bool canRotate = true;
    private float tiempo = 0f;
    public void DoTheDamageFromNozomi()
    {
        nozTurn.doDamageNozomi();
    }
    public void DoTheThingFromNozomi()
    {
        nozTurn.doThing();
    }
    public void ShakeCameraNozomi()
    {
        CameraShaker.Instance.ShakeThisCamera(0.2f, 0.1f);
    }
    public void ExagerateShakeCameraNozomi()
    {
        CameraShaker.Instance.ShakeThisCamera(0.5f, 0.3f);
    }

    public void animRotateRef()
    {
        canRotate = true;
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
    void FixedUpdate()
    {
        if(canRotate)
        RotateCosa();
    }

}
