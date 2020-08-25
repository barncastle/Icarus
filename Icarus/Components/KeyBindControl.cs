using Icarus.Logic.Game.Enums;
using Icarus.Logic.Hooks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Icarus.Components
{
    using Keys = Logic.Hooks.Enums.Keys;

    internal class KeyBindControl : UserControl
    {
        private readonly Dictionary<ComboBox, InputMask> ComboBoxes;
        private readonly Dictionary<string, Keys> Items;
        private bool Suspended = true;

        public KeyBindControl()
        {
            DoubleBuffered = true;
            ComboBoxes = new Dictionary<ComboBox, InputMask>(0x10);

            Items = new Dictionary<string, Keys>(0xFF);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                Items[key.ToString()] = key;

            InitializeComponent();
        }

        public void InitializeComponent()
        {
            var items = Items.ToList();
            var masks = (InputMask[])Enum.GetValues(typeof(InputMask));

            // skip None
            for (int i = 1; i < masks.Length; i++)
                ComboBoxes.Add(CreateComboBox(masks[i], i - 1, items), masks[i]);

            CreateResetButton();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetValues();
        }

        protected override void Dispose(bool disposing)
        {
            KeyBinding.Save();
            base.Dispose(disposing);
        }

        private void SetValues()
        {
            Suspended = true;

            foreach (var kvp in ComboBoxes)
            {
                KeyBinding.TryGet(kvp.Value, out var key);
                kvp.Key.SelectedValue = key;
            }

            Suspended = false;
        }

        #region Controls

        private ComboBox CreateComboBox(InputMask mask, int i, IList data)
        {
            var comboBox = new ComboBox
            {
                Tag = mask,
                Name = "cb" + mask,
                Left = 85,
                Top = 25 * i,
                BindingContext = new BindingContext(),
                DisplayMember = "Key",
                ValueMember = "Value",
                DataSource = data
            };

            var label = new Label
            {
                Text = mask.ToString(),
                Top = comboBox.Top + 3,
                Width = 60
            };

            Controls.Add(label);
            Controls.Add(comboBox);

            comboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;

            return comboBox;
        }

        private Button CreateResetButton()
        {
            var button = new Button()
            {
                Top = ComboBoxes.Count * 25,
                Left = 85,
                Size = new System.Drawing.Size(75, 23),
                Text = "Reset"
            };

            button.Click += ResetButton_Click;

            Controls.Add(button);

            return button;
        }

        #endregion Controls

        #region Events

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;

            if (!Suspended && ComboBoxes.TryGetValue(comboBox, out var mask))
            {
                KeyBinding.BindKey(mask, (Keys)comboBox.SelectedValue);
                SetValues();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            KeyBinding.Reset();
            SetValues();
        }

        #endregion Events
    }
}