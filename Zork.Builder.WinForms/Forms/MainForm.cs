using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Zork.Builder.WinForms.ViewModel;
using Zork.Builder.WinForms.Data;
using Newtonsoft.Json;

namespace Zork.Builder.WinForms.Forms
{
    public partial class MainForm : Form
    {
        public static string AssemblyTitle = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;

        private WorldViewModel mViewModel;
        private bool mIsWorldLoaded;
        private bool IsWorldLoaded
        {
            get => mIsWorldLoaded;
            set
            {
                mIsWorldLoaded = value;
                gameInfoBox.Enabled = mIsWorldLoaded;
                roomGroupBox.Enabled = mIsWorldLoaded;
                roomInfoBox.Enabled = mIsWorldLoaded && roomsListBox.SelectedItem != null;
                saveFileToolStripMenuItem.Enabled = mIsWorldLoaded;
                saveAsToolStripMenuItem.Enabled = mIsWorldLoaded;
                UpdateDirectionBoxes();
            }
        }

        private WorldViewModel ViewModel
        {
            get => mViewModel;
            set
            {
               if(mViewModel != value)
                {
                    mViewModel = value;
                    worldViewModelBindingSource.DataSource = mViewModel;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            ViewModel = new WorldViewModel();
            IsWorldLoaded = false;
        }

        private void OpenFileToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(openFileDialog.FileName));
                ViewModel.Filename = openFileDialog.FileName;
                IsWorldLoaded = true;
                deleteRoomButton.Enabled = mIsWorldLoaded && roomsListBox.SelectedItem != null;
            }
        }

        private void SaveFileToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(ViewModel.Filename))
            {
                SaveAsToolStripMenuItem_Click(null, null);
                return;
            }
            ViewModel.SaveWorld();
        }

        private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Filename = saveFileDialog.FileName;
                ViewModel.SaveWorld();
            }
        }

        private void AddRoomButton_Click(object sender, System.EventArgs e)
        {
            using (AddRoomForm addRoomForm = new AddRoomForm())
            {
                if(addRoomForm.ShowDialog() == DialogResult.OK)
                {
                    if (ViewModel.Rooms.FirstOrDefault(r =>  r.Name == addRoomForm.RoomName) != null)
                        MessageBox.Show("No duplicate rooms allowed.", AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        Room room = new Room(addRoomForm.RoomName);
                        if (ViewModel.Rooms.Count == 0)
                            ViewModel.Rooms = new BindingList<Room>() { room };
                        else
                            ViewModel.Rooms.Add(room);
                        ViewModel.RoomNeighbors.Add(addRoomForm.RoomName);
                        UpdateDirectionBoxes();
                    }
                }
            }
        }

        private void DeleteRoomButton_Click(object sender, System.EventArgs e)
        {
            if(MessageBox.Show("Delete this room?", AssemblyTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ViewModel.Rooms.Remove((Room)roomsListBox.SelectedItem);
                ViewModel.RoomNeighbors.Remove(((Room)roomsListBox.SelectedItem).Name);
                roomsListBox.SelectedItem = ViewModel.Rooms.FirstOrDefault();
                deleteRoomButton.Enabled = mIsWorldLoaded && roomsListBox.SelectedItem != null;
                UpdateDirectionBoxes();
            }
        }

        private void RoomsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            roomInfoBox.Enabled = mIsWorldLoaded && roomsListBox.SelectedItem != null;
            deleteRoomButton.Enabled = mIsWorldLoaded && roomsListBox.SelectedItem != null;

            UpdateDirectionBoxes();
        }

        private void UpdateDirectionBoxes()
        {
            if (roomsListBox.SelectedItem != null)
            {
                northComboBox.DataSource = new List<string>(ViewModel.RoomNeighbors);
                northComboBox.SelectedItem = ((Room)roomsListBox.SelectedItem).North;

                southComboBox.DataSource = new List<string>(ViewModel.RoomNeighbors);
                southComboBox.SelectedItem = ((Room)roomsListBox.SelectedItem).South;

                eastComboBox.DataSource = new List<string>(ViewModel.RoomNeighbors);
                eastComboBox.SelectedItem = ((Room)roomsListBox.SelectedItem).East;

                westComboBox.DataSource = new List<string>(ViewModel.RoomNeighbors);
                westComboBox.SelectedItem = ((Room)roomsListBox.SelectedItem).West;
            }
        }

        private void NorthComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            ((Room)roomsListBox.SelectedItem).North = (string)box.SelectedItem;
        }

        private void SouthComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            ((Room)roomsListBox.SelectedItem).South = (string)box.SelectedItem;
        }

        private void EastComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            ((Room)roomsListBox.SelectedItem).East = (string)box.SelectedItem;
        }

        private void WestComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            ((Room)roomsListBox.SelectedItem).West = (string)box.SelectedItem;
        }
    }
}
