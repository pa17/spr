using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigateToFixedHandler : MonoBehaviour
{

    public bool isActive = false;
    public Text navigateToFixedText;

    public bool skipForDemo = false;

    // Start is called before the first frame update
    void Start()
    {
        navigateToFixedText.text = "";
    }

    // Update is called once per frame
    public void SetText()
    {
        if (!skipForDemo)
        {
            navigateToFixedText.text = "The next trains are coming from the left. Navigate to where you think you can spot them the earliest (using the arrow keys). Press down arrow to stop and then tell your supervisor to confirm.";
            isActive = true;
        }
    }
}


