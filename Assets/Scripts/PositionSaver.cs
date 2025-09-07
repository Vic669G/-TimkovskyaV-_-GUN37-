using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class PositionSaver : MonoBehaviour
	{
        [System.Serializable]
        public struct Data
		{
			public Vector3 Position;
			public float Time;
		}

        [ReadOnly]
        [SerializeField]
        [Tooltip("Чтобы заполнить это поле, используйте контекстное меню в инспекторе 'Create File'.")]
        private TextAsset _json;

        [SerializeField, HideInInspector]
        private List<Data> _records = new List<Data>();
        
        public List<Data> Records
        {
            get => _records;
            private set => _records = value;
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            [SerializeField]
            public List<T> Items = new List<T>();
        }


        private void Awake()
		{
			//todo comment: Что будет, если в теле этого условия не сделать выход из метода?
			//Игра может упасть или скрипт перестанет работать.
			if (_json == null)
			{
				gameObject.SetActive(false);
				Debug.LogError("Please, create TextAsset and add in field _json");
				return;
			}

            if (!string.IsNullOrEmpty(_json.text))
            {
                var wrapper = JsonUtility.FromJson<Wrapper<Data>>(_json.text);
                Records = wrapper != null ? wrapper.Items : new List<Data>();
            }
            else
            {
                Records = new List<Data>();
            }

            //todo comment: Для чего нужна эта проверка (что она позволяет избежать)?
            //Она гарантирует, что всегда будет рабочий список Records, и если он ещё не был создан, то создаётся новый список. И это помогает избежать NullReferenceException, лишней инициализации и неинцилиализированного состояния.
            if (Records == null)
                Records = new List<Data>(10);
		}

		private void OnDrawGizmos()
		{
			//todo comment: Зачем нужны эти проверки (что они позволляют избежать)?
			//Проверяет, что список создан, и он не пустой. Они помогают избежать падения программы и ситуаций, когда в инспекторе поле списка не заполнено, а скрипт всё-равно пытается работать.
			if (Records == null || Records.Count == 0) return;
			var data = Records;
			var prev = data[0].Position;
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(prev, 0.3f);
            //todo comment: Почему итерация начинается не с нулевого элемента?
            //Потому что уже есть prev = data[0].Position. Если начать с i = 0, то получилось бы лишнее действие
            for (int i = 1; i < data.Count; i++)
			{
				var curr = data[i].Position;
				Gizmos.DrawWireSphere(curr, 0.3f);
				Gizmos.DrawLine(prev, curr);
				prev = curr;
			}
		}
		
		[ContextMenu("Create File")]
		private void CreateFile()
		{
			//todo comment: Что происходит в этой строке?
			//Создаёт новый файл по указанному пути. Если файл существует, то он будет очищен.
			var stream = File.Create(Path.Combine(Application.dataPath, "Path.txt"));
			//todo comment: Подумайте для чего нужна эта строка? (а потом проверьте догадку, закомментировав) 
			//Закрывает поток к файлу, освобождая его для дальнейшей работы.
			stream.Dispose();
			UnityEditor.AssetDatabase.Refresh();
			//В Unity можно искать объекты по их типу, для этого используется префикс "t:"
			//После нахождения, Юнити возвращает массив гуидов (которые в мета-файлах задаются, например)
			var guids = UnityEditor.AssetDatabase.FindAssets("t:TextAsset");
			foreach (var guid in guids)
			{
				//Этой командой можно получить путь к ассету через его гуид
				var path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
				//Этой командой можно загрузить сам ассет
				var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<TextAsset>(path);
                //todo comment: Для чего нужны эти проверки?
                //asset != null - проверка на то, что LoadAssetArtPath нашёл ассет по указанному пути. asset.name == "Path" - гарантия, что _json присвоен тот ассет, который нужен.
                if (asset != null && asset.name == "Path")
				{
					_json = asset;
					UnityEditor.EditorUtility.SetDirty(this);
					UnityEditor.AssetDatabase.SaveAssets();
					UnityEditor.AssetDatabase.Refresh();
					//todo comment: Почему мы здесь выходим, а не продолжаем итерироваться?
					//Если бы цикл продолжался, то _json мог быть перезаписан другим ассетом, что сломало бы логику.
					return;
				}
			}
		}

        private void OnDestroy()
		{
#if UNITY_EDITOR
            if (_json == null || Records == null) return;

            var w = new Wrapper<Data> { Items = Records };
            string json = JsonUtility.ToJson(w, true);

            string assetPath = UnityEditor.AssetDatabase.GetAssetPath(_json);
            if (string.IsNullOrEmpty(assetPath)) return;

            System.IO.File.WriteAllText(assetPath, json);
            UnityEditor.AssetDatabase.ImportAsset(assetPath);
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();
#endif
        }
    }
}