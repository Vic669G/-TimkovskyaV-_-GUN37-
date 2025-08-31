using UnityEngine;

namespace DefaultNamespace
{
	
	[RequireComponent(typeof(PositionSaver))]
	public class EditorMover : MonoBehaviour
	{
		private PositionSaver _save;
		private float _currentDelay;
		
		//todo comment: Что произойдёт, если _delay > _duration?
		//Эффект может не успеть начаться, поэтому мы его не увидим.
		private float _delay = 0.5f;
		private float _duration = 5f;

		private void Start()
		{
            //todo comment: Почему этот поиск производится здесь, а не в начале метода Update?
            //Поиск _save и очистака его данных делаются в Start, потому что это инициализация объекта. В Update это бы затрудняло производительность и нарушало работу логики. 
            _save = GetComponent<PositionSaver>();
			_save.Records.Clear();
		}

		private void Update()
		{
			_duration -= Time.deltaTime;
			if (_duration <= 0f)
			{
				enabled = false;
				Debug.Log($"<b>{name}</b> finished", this);
				return;
			}
			
			//todo comment: Почему не написать (_delay -= Time.deltaTime;) по аналогии с полем _duration?
			//Может возникнуть путаница: эффект начнётся раньше или позже, или _delay уйдёт в минус и будет мешать вычислениям.
			_currentDelay -= Time.deltaTime;
			if (_currentDelay <= 0f)
			{
				_currentDelay = _delay;
				_save.Records.Add(new PositionSaver.Data
				{
					Position = transform.position,
					//todo comment: Для чего сохраняется значение игрового времени?
					//Чтобы отсчитывать задержки или сроки действия, сохранения момента событий, синхронизации процессов и управление эффектами.
					Time = Time.time,
				});
			}
		}
	}
}