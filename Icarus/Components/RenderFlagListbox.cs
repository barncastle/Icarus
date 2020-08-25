using Icarus.Logic.Game;
using Icarus.Logic.Game.Enums;
using System;
using System.Windows.Forms;

namespace Icarus.Components
{
    internal class RenderFlagListbox : CheckedListBox
    {
        public CameraManager CameraManager { get; set; }

        private readonly Enables[] Flags;

        public RenderFlagListbox()
        {
            CheckOnClick = true;
            DoubleBuffered = true;

            Flags = (Enables[])Enum.GetValues(typeof(Enables));
            Array.Sort(Flags, (x, y) => x.ToString().CompareTo(y.ToString()));
        }

        public void Populate()
        {
            Items.Clear();
            for (int i = 0; i < Flags.Length; i++)
                Items.Add(Flags[i].ToString());
        }

        public void SetCurrentFlags()
        {
            if (CameraManager == null)
                return;

            var current = CameraManager.GetRenderFlags();
            for (int i = 0; i < Flags.Length; i++)
                SetItemChecked(i, (current & Flags[i]) == Flags[i]);
        }

        public void SetDefaultFlags()
        {
            CameraManager?.ResetRenderFlags();
            SetCurrentFlags();
        }

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            bool enabled = ice.NewValue == CheckState.Checked;

            if (CameraManager?.SetRenderFlags(Flags[ice.Index], enabled) == true)
                base.OnItemCheck(ice);
        }
    }
}