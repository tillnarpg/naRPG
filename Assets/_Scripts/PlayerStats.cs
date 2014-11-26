public class PlayerStats : BaseCharacter
{
    private int _class;

	public int Class 
	{ 
		get { return _class; } 
		set { _class = value; } 
	}
}

public enum PlayerClass
{
    Warrior,
    Mage
}