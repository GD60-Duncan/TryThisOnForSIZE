using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplayEffect : MonoBehaviour
{
      [SerializeField] private TMP_Text _tmp;

      [SerializeField] private TMP_InputField _inputF;

      [SerializeField] private bool _useInputField;

      [SerializeField] private bool _useEvent;

      private int currentChar;

      private string hiddenString;

      private StringBuilder stringBuilder;

      void Start()
      {
            hiddenString = _tmp.text;

            _tmp.text = "";

            stringBuilder = new StringBuilder();

            DisplayTextManual();
      }

      public void DisplayTextManual()
      {
        _tmp.text.Replace(hiddenString, "" );

        if(_useInputField)
        {
            _inputF.ActivateInputField();
            //_inputF.Select();

            _inputF.SetTextWithoutNotify("");
        }
      }

      public void AddKey()
      {
        stringBuilder.Append(hiddenString.ToCharArray()[currentChar]);

        _inputF.text = stringBuilder.ToString();

        //_inputF.asteriskChar = hiddenString.ToCharArray()[currentChar];

        //_inputF.MoveTextEnd(true);

        currentChar++;

        Debug.Log(stringBuilder.ToString());

        //_inputF.

         _inputF.MoveTextEnd(true);

         if(currentChar == hiddenString.Length && _useEvent)
         {
            Debug.Log("The Nuts");
            
            GameData.GameOver = false;
            Time.timeScale = 1;
         }

        //_inputF.text = stringBuilder.ToString();

        //_inputF.MoveTextStart(true);

      }
}
