using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{

    public CharacterSystem Reply_CS;

    public List<Character> CharacterList;

    public void SelectCharacter(int ID)
    {
        Reply_CS.NewCharacterSelected(CharacterList[ID]);
    }

}
