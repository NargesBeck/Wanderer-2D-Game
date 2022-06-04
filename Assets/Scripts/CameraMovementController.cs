using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    private Transform playerTransform;
    private Transform PlayerTransform
    {
        get
        {
            if (playerTransform == null)
                playerTransform = Player.Instance.transform;
            return playerTransform;
        }
    }

    private Vector3 myPosition
    {
        get
        {
            return new Vector3 (transform.position.x, transform.position.y, 0);
        }
    }

    private Vector3 currentPosition = new Vector3();
    private const float maxDistanceAllowed = 0.2f;

    private void Update()
    {
        if (Vector3.Distance(myPosition, PlayerTransform.position) <= maxDistanceAllowed)
            return;

        Vector3 dir = PlayerTransform.position - myPosition;
        transform.Translate(dir * 0.25f * Time.deltaTime);
    }
}
