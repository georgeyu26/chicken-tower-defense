using UnityEngine;

public class Typing : MonoBehaviour
{
    public ObjectType type;
    
    public static float multiplier(ObjectType attack, ObjectType victim)
    {
        // Row corresponds to type of attack, column corresponds to type of victim
        float[,] multiplierSheet =
        {
            //               Nat   Med   Kit   Mil   Fut
            /* Nature   */ { 1.0f, 1.0f, 0.5f, 0.0f, 0.0f },
            /* Medieval */ { 2.0f, 0.0f, 1.0f, 1.5f, 1.0f },
            /* Kitchen  */ { 0.5f, 1.5f, 1.0f, 1.0f, 0.0f },
            /* Military */ { 1.0f, 0.5f, 1.5f, 1.0f, 1.0f },
            /* Future   */ { 1.5f, 0.5f, 1.5f, 0.5f, 1.5f },
        };

        return multiplierSheet[(int)attack, (int)victim];
    }
}