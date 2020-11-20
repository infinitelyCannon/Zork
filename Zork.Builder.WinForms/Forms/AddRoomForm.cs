using System.Windows.Forms;

namespace Zork.Builder.WinForms.Forms
{
    public partial class AddRoomForm : Form
    {
        public string RoomName
        {
            get => nameTextBox.Text;
            set => nameTextBox.Text = value;
        }

        public AddRoomForm()
        {
            InitializeComponent();
        }

        private void NameTextBox_TextChanged(object sender, System.EventArgs e)
        {
            okButton.Enabled = !string.IsNullOrEmpty(RoomName);
        }
    }
}
