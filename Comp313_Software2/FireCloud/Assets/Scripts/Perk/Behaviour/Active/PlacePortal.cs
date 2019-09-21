using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FireCloud.Perk.Behaviour
{
    [CreateAssetMenu(fileName = "Perk Behaviour", menuName = "Perk/Behaviours/Place Portal", order = 1)]
    public class PlacePortal : PerkBehaviour
    {
        public GameObject PortalController;

        public override void OnCast(GameObject sender, CastEventArgs args)
        {
            GameObject portalController = Instantiate(PortalController, sender.transform.position, Quaternion.identity);
            portalController.GetComponent<PortalController>().KeyCode = args.KeyCode;
        }
    }
}
