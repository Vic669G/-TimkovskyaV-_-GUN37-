using System;
using UnityEngine;

namespace DefaultNamespace
{
	[RequireComponent(typeof(PositionSaver))]
	public class ReplayMover : MonoBehaviour
	{
		private PositionSaver _save;
		private int _index;
		private PositionSaver.Data _prev;
		private float _duration;

		private void Start()
		{
			////todo comment: зачем нужны эти проверки?
			////!TryGetComponent(out _save) - проверяет есть ли на объекте компонент PositionSaver. _save.Records.Count == 0 - проверяет, что список записей не пустой.
			if (!TryGetComponent(out _save) || _save.Records.Count == 0)
			{
				Debug.LogError("Records incorrect value", this);
				//todo comment: Для чего выключается этот компонент?
				//Это предотвращает дальнейший вызов Update().
				enabled = false;
			}
		}

		private void Update()
		{
			var curr = _save.Records[_index];
			//todo comment: Что проверяет это условие (с какой целью)? 
			//Проверяет, наступило ли время, когда он должен перейти к следующей позиции из списка записей.
			if (Time.time > curr.Time)
			{
				_prev = curr;
				_index++;
				//todo comment: Для чего нужна эта проверка?
				//Проверяет, не вышли ли мы за границы списка записей.
				if (_index >= _save.Records.Count)
				{
					enabled = false;
					Debug.Log($"<b>{name}</b> finished", this);
				}
			}
			//todo comment: Для чего производятся эти вычисления (как в дальнейшем они применяются)?
			//Вычисляется нормализованная позиция между двумя временными точками. Используется для интерполяции позиции через Lerp.
			var delta = (Time.time - _prev.Time) / (curr.Time - _prev.Time);
			//todo comment: Зачем нужна эта проверка?
			//Защищает от деления на ноль.
			if (float.IsNaN(delta)) delta = 0f;
			//todo comment: Опишите, что происходит в этой строчке так подробно, насколько это возможно
			//Vector3.Lerp - линейная интерполяция между a и b. _prev.Position - предыдущая точка из записей. curr.Position - текущая точка из записей. delta - показывает как далеко объект должен находиться между двумя точками в данный момент времени. Этот механизм позволяет воспроизводить движение объекта точно так же, как оно было записано.
			transform.position = Vector3.Lerp(_prev.Position, curr.Position, delta);
		}
    }

}