using UnityEngine;

public class Typing : MonoBehaviour
{
    public ObjectType type;

    public static float multiplier(ObjectType attack, ObjectType victim)
    {
        return FindObjectOfType<GameManager>().CalculateDamageModifier(attack, victim);
    }
}