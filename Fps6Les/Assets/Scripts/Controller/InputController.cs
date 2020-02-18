using UnityEngine;

namespace Geekbrains
{
	public class InputController : BaseController, IOnUpdate
	{

		private KeyCode _activeFlashLight = KeyCode.F;
		private KeyCode _cancel = KeyCode.Escape;
		private KeyCode _reloadClip = KeyCode.R;
        private KeyCode _savePlayer = KeyCode.C;
        private KeyCode _loadPlayer = KeyCode.V;
        //private KeyCode _screenshot = KeyCode.Q;

        public InputController()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		
		public void OnUpdate()
		{
			if (!IsActive) return;
			if (Input.GetKeyDown(_activeFlashLight))
			{
				Main.Instance.FlashLightController.Switch();
			}

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                SelectWeapon(0);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                SelectWeapon(1);
            }

            if (Input.GetKeyDown(_cancel))
			{
				Main.Instance.WeaponController.Off();
				Main.Instance.FlashLightController.Off();
			}

			if (Input.GetKeyDown(_reloadClip))
			{
				Main.Instance.WeaponController.ReloadClip();
			}
            if (Input.GetKeyDown(_savePlayer))
            {
                Main.Instance.SaveDataRepository.Save();
            }

            if (Input.GetKeyDown(_loadPlayer))
            {
                Main.Instance.SaveDataRepository.Load();
            }

            //if (Input.GetKeyDown(_screenshot))
            //{
            //    Main.Instance.PhotoController.FirstMethod();
            //}
        }


		/// <summary>
		/// Выбор оружия
		/// </summary>
		/// <param name="i">Номер оружия</param>
		private void SelectWeapon(int i)
		{
			Main.Instance.WeaponController.Off();
			var tempWeapon = Main.Instance.Inventory.Weapons[i]; // инкапсулировать
			if (tempWeapon != null)
			{
				Main.Instance.WeaponController.On(tempWeapon);
			}
		}
	}
}