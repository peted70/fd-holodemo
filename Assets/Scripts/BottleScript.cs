using HoloToolkit.Unity;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BottleScript : MonoBehaviour
{
    private Vector3 _position;
    private Quaternion _rotation;
    private AudioSource _audio;
    private Rigidbody _rb;

    public void Start()
    {
        // 5-SPATIAL-SOUND - Retrieve Audio Source on the bottle
        //_audio = GetComponent<AudioSource>();
    }

    public void Awake()
    {
        // 6-WORLD-COORDS - disable physics until we have placed the stage
        // (otherwise they will all just fall over!)
        //_rb = GetComponent<Rigidbody>();
        //_rb.isKinematic = true;
        //_rb.detectCollisions = false;

        _position = gameObject.transform.localPosition;
        _rotation = gameObject.transform.localRotation;
    }

    public void Placed()
    {
        _rb.isKinematic = false;
        _rb.detectCollisions = true;
    }

    public void OnSelect()
    {
        // 2-GESTURE When the bottle is selected apply a force in opposit direction to 
        // the normal at the hit location
        var rayHit = GazeManager.Instance.HitInfo;
        GetComponent<Rigidbody>().AddForceAtPosition(rayHit.normal * -5, rayHit.point, ForceMode.Impulse);

        // 5-SPATIAL-SOUND - Play audio when we tap
        //_audio.pitch = Random.Range(0.5f, 2.0f);
        //_audio.Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 5-SPATIAL-SOUND - Play audio when we have a collision
        //if (collision.relativeVelocity.magnitude > 2)
        //{
        //    _audio.pitch = Random.Range(0.5f, 2.0f);
        //    _audio.Play();
        //}
    }

    public void Reset()
    {
        // 3-VOICE - reset to initial positions
        GetComponent<Rigidbody>().Sleep();
        gameObject.transform.localPosition = _position;
        gameObject.transform.localRotation = _rotation;
    }
}
