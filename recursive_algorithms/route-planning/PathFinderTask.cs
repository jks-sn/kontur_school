using System;
using System.Drawing;

namespace RoutePlanning;

public static class PathFinderTask
{
	public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
	{
		var visited = new bool[checkpoints.Length];
		visited[0] = true;

		var bestOrder = new int[checkpoints.Length];
		double bestDistance = double.MaxValue;
		
		var currentOrder = new int[checkpoints.Length];
		currentOrder[0] = 0;
		
		var distances = PrecalculateDistances(checkpoints);
		
		FindBestPath(checkpoints, distances, visited, currentOrder, 1, 0, ref bestDistance, bestOrder);
		return bestOrder;
	}

	private static void FindBestPath(Point[] checkpoints, double[,] distances, bool[] visited, int[] currentOrder, int orderIndex, double currentDistance, ref double bestDistance, int[] bestOrder)
	{
		if (orderIndex == checkpoints.Length)
		{
			if (currentDistance < bestDistance)
			{
				bestDistance = currentDistance;
				Array.Copy(currentOrder, bestOrder, currentOrder.Length);
			}
			return;
		}

		for (int i = 1; i < checkpoints.Length; i++)
		{
			if (!visited[i])
			{
				visited[i] = true;
				currentOrder[orderIndex] = i;
				
				var distanceToNext = distances[currentOrder[orderIndex - 1], i];
				var newDistance = currentDistance + distanceToNext;
				
				if (newDistance < bestDistance)
				{
					FindBestPath(checkpoints, distances, visited, currentOrder, orderIndex + 1, newDistance, ref bestDistance, bestOrder);
				}

				visited[i] = false;
			}
		}
	}
	private static double Distance(Point p1, Point p2)
	{
		return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
	}

	public static double[,] PrecalculateDistances(Point[] checkpoints)
	{
		var length = checkpoints.Length;
		var distances = new double[length, length];
		for (int i = 0; i < length; i++)
		{
			for (int j = i + 1; j < length; j++)
			{
				var distance = Distance(checkpoints[i], checkpoints[j]);
				distances[i, j] = distance;
				distances[j, i] = distance;
			}
		}
		return distances;
	}
}