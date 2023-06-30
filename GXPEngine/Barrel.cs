using GXPEngine;

class Barrel : Sprite
{
	private bool isForEnemy;

	public Barrel(bool isForEnemy = false) : base("assets/t34.png")
	{
		this.isForEnemy = isForEnemy;
	}
	float rotationSpeed = 100f;

	public void Update()
	{
        if (!isForEnemy)
        {
			RotateToMouse();
        }
        else
        {
			rotationSpeed = 1f;
			RotateToPlayer();
        }
	}

	void RotateToMouse() //follow mouse
	{
		Vec2 mousePos = new Vec2(Input.mouseX, Input.mouseY);
		Vec2 currentPos = new Vec2(parent.x, parent.y);
		Vec2 targetVector = currentPos - mousePos;
		float targetRotation = targetVector.GetAngleDegrees() - parent.rotation + 180;

		float deltaRotation = (targetRotation - rotation + 180) % 360; // value is now between -360 and 360 and opposite to the target angle
		deltaRotation -= 180; // now it;s between -540 and 180 and equivalent to the target angle

		if (deltaRotation < -180) deltaRotation += 360; // now it's between -180 and 180

		rotation += Mathf.Clamp(deltaRotation, -rotationSpeed, rotationSpeed);
	}

	void RotateToPlayer()
	{
		Player player = game.FindObjectOfType<Player>();
		if(player != null)
        {
			Vec2 mousePos = new Vec2(player.x, player.y);
			Vec2 currentPos = new Vec2(parent.x, parent.y);
			Vec2 targetVector = currentPos - mousePos;
			float targetRotation = targetVector.GetAngleDegrees() - parent.rotation + 180;


			float deltaRotation = (targetRotation - rotation + 180) % 360; // value is now between -360 and 360 and opposite to the target angle
			deltaRotation -= 180; // now it;s between -540 and 180 and equivalent to the target angle

			if (deltaRotation < -180) deltaRotation += 360; // now it's between -180 and 180


			//float deltaRotation = (targetRotation - rotation ) % 360; // value is now between -360 and 360 AND equivalent to the original angle
			//if (Mathf.Abs(deltaRotation) > 180) deltaRotation -= 360 * Mathf.Sign(deltaRotation); // now it's between -180 and 180



			rotation += Mathf.Clamp(deltaRotation, -rotationSpeed, rotationSpeed);
		}	
	}
}
