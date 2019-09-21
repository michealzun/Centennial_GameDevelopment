using UnityEngine;

namespace FireCloud.Perk
{
    public class PortalController : MonoBehaviour
    {
        public GameObject portalPrefab;
        public Vector3 portalAPosition;
        public Vector3 portalBPosition;

        public GameObject owner;

        public GameObject portalA;
        public GameObject portalB;

        [HideInInspector]
        public LineRenderer line;

        public bool secondPortalPlaced = false;

        public KeyCode KeyCode;

        private void Start()
        {
            owner = GameObject.FindGameObjectWithTag("Player");
            portalAPosition = owner.transform.position;
            portalA = Instantiate(portalPrefab, portalAPosition, Quaternion.identity);
            line = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            if (!secondPortalPlaced)
            {
                if (Input.GetKeyUp(KeyCode))
                {
                    portalBPosition = owner.transform.position;
                    portalB = Instantiate(portalPrefab, portalBPosition, Quaternion.identity);
                    Portal pA = portalA.GetComponent<Portal>();
                    Portal pB = portalB.GetComponent<Portal>();
                    pA.Exit = pB;
                    pB.Exit = pA;
                    pB.EnableEnter = false;
                    pB.StartEnterCooldown();
                    line.SetPosition(0, pA.transform.position);
                    line.SetPosition(1, pB.transform.position);
                    secondPortalPlaced = true;
                }
            }
            
        }
    }
}
