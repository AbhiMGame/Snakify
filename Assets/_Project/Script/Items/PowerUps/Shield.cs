using SnakeGame.Snake;
using UnityEngine;

namespace SnakeGame.Item.PowerUp
{
    public class Shield : PowerUp
    {
		public SpriteRenderer shieldsprite;
		public override void UsePowerup(SnakeController snake)
		{
			snake.isShieldActive = true;
			Debug.Log("Shield Active");
		}

		public override void ResetPowerUp(SnakeController snake)
		{
			snake.isShieldActive = false;
			Debug.Log("Shield Ended");
		}
	}
}
