using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleNearFarInteractor : MonoBehaviour
{
    [Tooltip("Switch even if an object is selected")]
    public bool forceToggle = false;

    [Tooltip("The direct interactor that's switched to")]
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor directInteractor = null;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor rayInteractor = null;
    private bool isSwitched = false;

    private void Awake()
    {
        rayInteractor = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor>();
        SwitchInteractors(false);
    }

    public void ActivateRay()
    {
        if (!TouchingObject() || forceToggle)
            SwitchInteractors(true);
    }

    public void DeactivateRay()
    {
        if (isSwitched)
            SwitchInteractors(false);
     
    }

    private bool TouchingObject()
    {
        List<UnityEngine.XR.Interaction.Toolkit.Interactables.IXRInteractable> targets = new List<UnityEngine.XR.Interaction.Toolkit.Interactables.IXRInteractable>();
        directInteractor.GetValidTargets(targets);
        return (targets.Count > 0);
    }

    private void SwitchInteractors(bool value)
    {
        isSwitched = value;
        rayInteractor.enabled = value;
        directInteractor.enabled = !value;
    }
}
