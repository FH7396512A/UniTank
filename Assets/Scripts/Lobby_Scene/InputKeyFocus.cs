using UnityEngine;
using UnityEngine.UI;

public class InputKeyFocus : MonoBehaviour
{
    InputField theInputField;

    void Start()
    {
        theInputField = GetComponent<InputField>();
        theInputField.onEndEdit.AddListener(delegate { MyOnEndEdit(theInputField); });
    }

    void MyOnEndEdit(InputField _inputFieldWeCareAbout)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //here we re activate the field, so the caret will be still visible after pressing enter
            _inputFieldWeCareAbout.ActivateInputField();
            //do something with the current _inputFieldWeCareAbout.text here, like sending it to the chat server
            _inputFieldWeCareAbout.text = "";
        }
    }
}