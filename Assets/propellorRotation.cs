namespace VRTK.Examples
{
    using UnityEngine;
    public class propellorRotation : MonoBehaviour
    {
        [Tooltip("Angular velocity in degrees per seconds")]
        public float degPerSec = 60.0f;

        // Use this for initialization

        // Update is called once per frame
        private void Update()
        {
            transform.RotateAround(transform.parent.transform.position, Vector3.up, degPerSec * Time.deltaTime);
        }
    }
}