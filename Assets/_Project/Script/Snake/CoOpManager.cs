using UnityEngine;
using SnakeGame.Snake;

namespace SnakeGame
{
	public class CoOpManager : MonoBehaviour
    {
        [Header("SnakePrefab")]
        [SerializeField] private SnakeController snakePrefab;
		[SerializeField] private Transform headCollection;
		[SerializeField] Transform bodyCollection;
		

		[Header("Team Properties")]
        public TeamProperties[] teams;
		

		[Header("Snake Properties")]
		[SerializeField] private float speed;
		[SerializeField] private int initialBodyCount;

        private SnakeController[] snakes;


		private SnakeController CreateSnake(TeamProperties team)
		{
            SnakeController newSnake = Instantiate(snakePrefab, team.spawnPoint.position,Quaternion.identity);
            Vector2 initalDirection = (team.spawnPoint.position.x > 0) ? Vector2.left : Vector2.right;
			newSnake.InitializeSnake(team.team, team.color, team.keyConfig,speed, initialBodyCount, initalDirection, bodyCollection);
            newSnake.transform.parent = headCollection;
            return newSnake;
		}

		internal void StartGame()
		{
			RemovePreviousSnakes();
			snakes = new SnakeController[teams.Length];
			for (int teamIndex = 0; teamIndex < teams.Length; teamIndex++)
			{
				snakes[teamIndex] = CreateSnake(teams[teamIndex]);
			}
		}

		private void RemovePreviousSnakes()
		{
			if (snakes == null)
				return;

			for (int i = 0; i < snakes.Length; i++)
			{
				Destroy(snakes[i].gameObject);
			}

			RemoveBodies();
		}

		private void RemoveBodies()
		{
			Transform[] childs = new Transform[bodyCollection.childCount];

			for (int i = 0; i < bodyCollection.childCount; i++)
			{
				childs[i] = bodyCollection.GetChild(i);
			}
			foreach (Transform child in childs)
			{
				Destroy(child.gameObject);
			}
		}
	}
}
