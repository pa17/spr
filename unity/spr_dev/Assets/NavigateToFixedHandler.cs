using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigateToFixedHandler : MonoBehaviour
{

    public bool isActive = false;
    public Text navigateToFixedText;

    // Start is called before the first frame update
    void Start()
    {
        navigateToFixedText.text = "";
    }

    // Update is called once per frame
    public void SetText()
    {
        navigateToFixedText.text = "Navigate to wher you can see a train coming from the left the quickest (using the arrow keys). Press down arrow to stop and then tell your supervisor to confirm.";
        isActive = true;
    }
}


