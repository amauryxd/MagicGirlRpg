using System;
using UnityEngine;

public class TurnLogic : MonoBehaviour
{
    public enum TurnType { Attack, Defense, Item, Escape }
    public TurnType Type;
    public int id;
    public delegate void OnTurnFinished();
    public static event OnTurnFinished turnFinished;
    //public  player health
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MakeTurn()
    {
        switch (Type)
        {
            case TurnType.Attack:
                OnAttackTurn();
                break;
            case TurnType.Defense:
                OnDefenseTurn();
                break;
            case TurnType.Item:
                OnItemTurn();
                break;
            case TurnType.Escape:
                OnEscapeTurn();
                break;
            default:
                break;
        }
    }
    public void OnAttackTurn()
    {
        Debug.Log("Atacando al enemigo con id " + id);
        turnFinished?.Invoke();
        //conseguir el enemigo a atacar
        //lamar las animaciones del ataque
        //restar la vida del enemigo
        //mandar el evento de turno terminado
    }
    public void OnDefenseTurn()
    {
        Debug.Log("Defendiendo");
        turnFinished?.Invoke();
        //aumentar las estadisticas del personaje
        //observar a cuando termine el turno enemigo
    }
    public void OnItemTurn()
    {
        Debug.Log("Item usado en el personaje/enemigo con id" + id);
        turnFinished?.Invoke();
        //conseguir la referencia necesaria (vida, enemigo, defensa, etc)
        //hacer la animacion de uso de item
        //hacer la logica del item usado
        //mandar el evento de turno terminado
    }
    private void OnEscapeTurn()
    {
        Debug.Log("Escapa");
        turnFinished?.Invoke();
        //lanzar el evento de intento de escape
    }
}
