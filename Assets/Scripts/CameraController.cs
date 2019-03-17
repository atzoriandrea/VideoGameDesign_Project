using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    public Vector3 offsetPosition;
    public float cameraTargetHeight;
    public float cameraTargetHorizontal;

    [SerializeField]
    private Space SpaceType = Space.Self;
    Vector3 LoockAtPoint;

    public enum UpdateType { Update, FixedUpdate, LateUpdate };
    public UpdateType updateSystem = UpdateType.LateUpdate;

    [Range(1, 5)]
    public float smoothMovement = 1;


    //Nel caso si debba aggiornare in Update
    private void Update()
    {
        if (updateSystem.Equals(UpdateType.Update))
            Refresh(Time.deltaTime);
    }

    //Nel caso si debba aggiornare in FixedUpdate
    private void FixedUpdate()
    {
        if (updateSystem.Equals(UpdateType.FixedUpdate))
            Refresh(Time.fixedDeltaTime);
    }
    //Nel caso si debba aggiornare in LateUpdate
    private void LateUpdate()
    {
        if (updateSystem.Equals(UpdateType.LateUpdate))
            Refresh(Time.deltaTime);
    }

    //Il metod che aggiorna le posizioni della telecamera
    public void Refresh(float updateDelta)
    {
        if (target == null)
        {
            Debug.LogWarning("Ops, No Target !", this);

            return;
        }



        //Se ruota insieme al target
        if (SpaceType == Space.Self)
        {
            transform.position = Vector3.Lerp(transform.position, target.TransformPoint(offsetPosition), smoothMovement * updateDelta);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offsetPosition, smoothMovement * updateDelta);
        }

        LoockAtPoint = Vector3.Lerp(LoockAtPoint, (target.position + (target.up * cameraTargetHeight) + (target.right * cameraTargetHorizontal)), (smoothMovement * updateDelta));

        transform.LookAt(LoockAtPoint);


    }
}
