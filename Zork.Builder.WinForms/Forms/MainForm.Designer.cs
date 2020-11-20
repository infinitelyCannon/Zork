
namespace Zork.Builder.WinForms.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startingLabel = new System.Windows.Forms.Label();
            this.startingComboBox = new System.Windows.Forms.ComboBox();
            this.worldViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.welcomLabel = new System.Windows.Forms.Label();
            this.welcomeMessageBox = new System.Windows.Forms.TextBox();
            this.gameInfoBox = new System.Windows.Forms.GroupBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.roomGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteRoomButton = new System.Windows.Forms.Button();
            this.addRoomButton = new System.Windows.Forms.Button();
            this.roomsListBox = new System.Windows.Forms.ListBox();
            this.roomsInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomInfoBox = new System.Windows.Forms.GroupBox();
            this.southComboBox = new System.Windows.Forms.ComboBox();
            this.westComboBox = new System.Windows.Forms.ComboBox();
            this.eastComboBox = new System.Windows.Forms.ComboBox();
            this.northComboBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.roomNametextBox = new System.Windows.Forms.TextBox();
            this.eastNeighborLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.westNeighborLabel = new System.Windows.Forms.Label();
            this.southNeighborLabel = new System.Windows.Forms.Label();
            this.northNeighborLabel = new System.Windows.Forms.Label();
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).BeginInit();
            this.gameInfoBox.SuspendLayout();
            this.roomGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsInfoBindingSource)).BeginInit();
            this.roomInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(579, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openFileToolStripMenuItem.Text = "&Open File...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveFileToolStripMenuItem.Text = "&Save File";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.SaveFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // startingLabel
            // 
            this.startingLabel.AutoSize = true;
            this.startingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingLabel.Location = new System.Drawing.Point(21, 29);
            this.startingLabel.Name = "startingLabel";
            this.startingLabel.Size = new System.Drawing.Size(115, 17);
            this.startingLabel.TabIndex = 2;
            this.startingLabel.Text = "Starting Location";
            // 
            // startingComboBox
            // 
            this.startingComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.worldViewModelBindingSource, "StartingLocation", true));
            this.startingComboBox.DataSource = this.roomsBindingSource;
            this.startingComboBox.DisplayMember = "Name";
            this.startingComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingComboBox.FormattingEnabled = true;
            this.startingComboBox.Location = new System.Drawing.Point(24, 57);
            this.startingComboBox.Name = "startingComboBox";
            this.startingComboBox.Size = new System.Drawing.Size(206, 24);
            this.startingComboBox.TabIndex = 3;
            this.startingComboBox.ValueMember = "Description";
            // 
            // worldViewModelBindingSource
            // 
            this.worldViewModelBindingSource.DataSource = typeof(Zork.Builder.WinForms.ViewModel.WorldViewModel);
            // 
            // roomsBindingSource
            // 
            this.roomsBindingSource.DataMember = "Rooms";
            this.roomsBindingSource.DataSource = this.worldViewModelBindingSource;
            // 
            // welcomLabel
            // 
            this.welcomLabel.AutoSize = true;
            this.welcomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomLabel.Location = new System.Drawing.Point(21, 110);
            this.welcomLabel.Name = "welcomLabel";
            this.welcomLabel.Size = new System.Drawing.Size(127, 17);
            this.welcomLabel.TabIndex = 4;
            this.welcomLabel.Text = "Welcome Message";
            // 
            // welcomeMessageBox
            // 
            this.welcomeMessageBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.worldViewModelBindingSource, "WelcomeMessage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.welcomeMessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeMessageBox.Location = new System.Drawing.Point(24, 130);
            this.welcomeMessageBox.Name = "welcomeMessageBox";
            this.welcomeMessageBox.Size = new System.Drawing.Size(206, 23);
            this.welcomeMessageBox.TabIndex = 5;
            // 
            // gameInfoBox
            // 
            this.gameInfoBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.gameInfoBox.Controls.Add(this.startingComboBox);
            this.gameInfoBox.Controls.Add(this.welcomeMessageBox);
            this.gameInfoBox.Controls.Add(this.startingLabel);
            this.gameInfoBox.Controls.Add(this.welcomLabel);
            this.gameInfoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoBox.Location = new System.Drawing.Point(12, 27);
            this.gameInfoBox.Name = "gameInfoBox";
            this.gameInfoBox.Size = new System.Drawing.Size(264, 181);
            this.gameInfoBox.TabIndex = 6;
            this.gameInfoBox.TabStop = false;
            this.gameInfoBox.Text = "Game Info";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "World Files (.json)|*.json";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "World Files (*json)|*.json";
            this.saveFileDialog.Title = "Save World as";
            // 
            // roomGroupBox
            // 
            this.roomGroupBox.Controls.Add(this.deleteRoomButton);
            this.roomGroupBox.Controls.Add(this.addRoomButton);
            this.roomGroupBox.Controls.Add(this.roomsListBox);
            this.roomGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomGroupBox.Location = new System.Drawing.Point(282, 27);
            this.roomGroupBox.Name = "roomGroupBox";
            this.roomGroupBox.Size = new System.Drawing.Size(279, 181);
            this.roomGroupBox.TabIndex = 7;
            this.roomGroupBox.TabStop = false;
            this.roomGroupBox.Text = "Rooms";
            // 
            // deleteRoomButton
            // 
            this.deleteRoomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteRoomButton.Location = new System.Drawing.Point(87, 152);
            this.deleteRoomButton.Name = "deleteRoomButton";
            this.deleteRoomButton.Size = new System.Drawing.Size(75, 23);
            this.deleteRoomButton.TabIndex = 2;
            this.deleteRoomButton.Text = "&Delete";
            this.deleteRoomButton.UseVisualStyleBackColor = true;
            this.deleteRoomButton.Click += new System.EventHandler(this.DeleteRoomButton_Click);
            // 
            // addRoomButton
            // 
            this.addRoomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRoomButton.Location = new System.Drawing.Point(6, 152);
            this.addRoomButton.Name = "addRoomButton";
            this.addRoomButton.Size = new System.Drawing.Size(75, 23);
            this.addRoomButton.TabIndex = 1;
            this.addRoomButton.Text = "&Add...";
            this.addRoomButton.UseVisualStyleBackColor = true;
            this.addRoomButton.Click += new System.EventHandler(this.AddRoomButton_Click);
            // 
            // roomsListBox
            // 
            this.roomsListBox.DataSource = this.roomsInfoBindingSource;
            this.roomsListBox.DisplayMember = "Name";
            this.roomsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomsListBox.FormattingEnabled = true;
            this.roomsListBox.ItemHeight = 16;
            this.roomsListBox.Location = new System.Drawing.Point(6, 29);
            this.roomsListBox.Name = "roomsListBox";
            this.roomsListBox.Size = new System.Drawing.Size(267, 116);
            this.roomsListBox.TabIndex = 0;
            this.roomsListBox.ValueMember = "Description";
            this.roomsListBox.SelectedIndexChanged += new System.EventHandler(this.RoomsListBox_SelectedIndexChanged);
            // 
            // roomsInfoBindingSource
            // 
            this.roomsInfoBindingSource.DataMember = "Rooms";
            this.roomsInfoBindingSource.DataSource = this.worldViewModelBindingSource;
            // 
            // roomInfoBox
            // 
            this.roomInfoBox.Controls.Add(this.southComboBox);
            this.roomInfoBox.Controls.Add(this.westComboBox);
            this.roomInfoBox.Controls.Add(this.eastComboBox);
            this.roomInfoBox.Controls.Add(this.northComboBox);
            this.roomInfoBox.Controls.Add(this.textBox1);
            this.roomInfoBox.Controls.Add(this.roomNametextBox);
            this.roomInfoBox.Controls.Add(this.eastNeighborLabel);
            this.roomInfoBox.Controls.Add(this.descriptionLabel);
            this.roomInfoBox.Controls.Add(this.westNeighborLabel);
            this.roomInfoBox.Controls.Add(this.southNeighborLabel);
            this.roomInfoBox.Controls.Add(this.northNeighborLabel);
            this.roomInfoBox.Controls.Add(this.roomNameLabel);
            this.roomInfoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomInfoBox.Location = new System.Drawing.Point(12, 214);
            this.roomInfoBox.Name = "roomInfoBox";
            this.roomInfoBox.Size = new System.Drawing.Size(549, 224);
            this.roomInfoBox.TabIndex = 8;
            this.roomInfoBox.TabStop = false;
            this.roomInfoBox.Text = "Room Info";
            // 
            // southComboBox
            // 
            this.southComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.southComboBox.FormattingEnabled = true;
            this.southComboBox.Location = new System.Drawing.Point(55, 120);
            this.southComboBox.Name = "southComboBox";
            this.southComboBox.Size = new System.Drawing.Size(192, 24);
            this.southComboBox.TabIndex = 11;
            this.southComboBox.SelectionChangeCommitted += new System.EventHandler(this.SouthComboBox_SelectedIndexChanged);
            // 
            // westComboBox
            // 
            this.westComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.westComboBox.FormattingEnabled = true;
            this.westComboBox.Location = new System.Drawing.Point(55, 194);
            this.westComboBox.Name = "westComboBox";
            this.westComboBox.Size = new System.Drawing.Size(192, 24);
            this.westComboBox.TabIndex = 10;
            this.westComboBox.SelectionChangeCommitted += new System.EventHandler(this.WestComboBox_SelectedIndexChanged);
            // 
            // eastComboBox
            // 
            this.eastComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eastComboBox.FormattingEnabled = true;
            this.eastComboBox.Location = new System.Drawing.Point(55, 157);
            this.eastComboBox.Name = "eastComboBox";
            this.eastComboBox.Size = new System.Drawing.Size(192, 24);
            this.eastComboBox.TabIndex = 9;
            this.eastComboBox.SelectionChangeCommitted += new System.EventHandler(this.EastComboBox_SelectedIndexChanged);
            // 
            // northComboBox
            // 
            this.northComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.northComboBox.FormattingEnabled = true;
            this.northComboBox.Location = new System.Drawing.Point(55, 83);
            this.northComboBox.Name = "northComboBox";
            this.northComboBox.Size = new System.Drawing.Size(192, 24);
            this.northComboBox.TabIndex = 8;
            this.northComboBox.SelectionChangeCommitted += new System.EventHandler(this.NorthComboBox_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsInfoBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(270, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(255, 98);
            this.textBox1.TabIndex = 7;
            // 
            // roomNametextBox
            // 
            this.roomNametextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsInfoBindingSource, "Name", true));
            this.roomNametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNametextBox.Location = new System.Drawing.Point(9, 46);
            this.roomNametextBox.Name = "roomNametextBox";
            this.roomNametextBox.Size = new System.Drawing.Size(238, 23);
            this.roomNametextBox.TabIndex = 6;
            // 
            // eastNeighborLabel
            // 
            this.eastNeighborLabel.AutoSize = true;
            this.eastNeighborLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eastNeighborLabel.Location = new System.Drawing.Point(8, 157);
            this.eastNeighborLabel.Name = "eastNeighborLabel";
            this.eastNeighborLabel.Size = new System.Drawing.Size(36, 17);
            this.eastNeighborLabel.TabIndex = 5;
            this.eastNeighborLabel.Text = "East";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(273, 26);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(79, 17);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Text = "Description";
            // 
            // westNeighborLabel
            // 
            this.westNeighborLabel.AutoSize = true;
            this.westNeighborLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.westNeighborLabel.Location = new System.Drawing.Point(6, 193);
            this.westNeighborLabel.Name = "westNeighborLabel";
            this.westNeighborLabel.Size = new System.Drawing.Size(40, 17);
            this.westNeighborLabel.TabIndex = 3;
            this.westNeighborLabel.Text = "West";
            // 
            // southNeighborLabel
            // 
            this.southNeighborLabel.AutoSize = true;
            this.southNeighborLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.southNeighborLabel.Location = new System.Drawing.Point(6, 120);
            this.southNeighborLabel.Name = "southNeighborLabel";
            this.southNeighborLabel.Size = new System.Drawing.Size(45, 17);
            this.southNeighborLabel.TabIndex = 2;
            this.southNeighborLabel.Text = "South";
            // 
            // northNeighborLabel
            // 
            this.northNeighborLabel.AutoSize = true;
            this.northNeighborLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.northNeighborLabel.Location = new System.Drawing.Point(8, 86);
            this.northNeighborLabel.Name = "northNeighborLabel";
            this.northNeighborLabel.Size = new System.Drawing.Size(43, 17);
            this.northNeighborLabel.TabIndex = 1;
            this.northNeighborLabel.Text = "North";
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.AutoSize = true;
            this.roomNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNameLabel.Location = new System.Drawing.Point(6, 26);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(45, 17);
            this.roomNameLabel.TabIndex = 0;
            this.roomNameLabel.Text = "Name";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 458);
            this.Controls.Add(this.roomInfoBox);
            this.Controls.Add(this.roomGroupBox);
            this.Controls.Add(this.gameInfoBox);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Zork Builder";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).EndInit();
            this.gameInfoBox.ResumeLayout(false);
            this.gameInfoBox.PerformLayout();
            this.roomGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roomsInfoBindingSource)).EndInit();
            this.roomInfoBox.ResumeLayout(false);
            this.roomInfoBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label startingLabel;
        private System.Windows.Forms.ComboBox startingComboBox;
        private System.Windows.Forms.Label welcomLabel;
        private System.Windows.Forms.TextBox welcomeMessageBox;
        private System.Windows.Forms.GroupBox gameInfoBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.GroupBox roomGroupBox;
        private System.Windows.Forms.Button deleteRoomButton;
        private System.Windows.Forms.Button addRoomButton;
        private System.Windows.Forms.ListBox roomsListBox;
        private System.Windows.Forms.GroupBox roomInfoBox;
        private System.Windows.Forms.Label eastNeighborLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label westNeighborLabel;
        private System.Windows.Forms.Label southNeighborLabel;
        private System.Windows.Forms.Label northNeighborLabel;
        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.ComboBox southComboBox;
        private System.Windows.Forms.ComboBox westComboBox;
        private System.Windows.Forms.ComboBox eastComboBox;
        private System.Windows.Forms.ComboBox northComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox roomNametextBox;
        private System.Windows.Forms.BindingSource worldViewModelBindingSource;
        private System.Windows.Forms.BindingSource roomsBindingSource;
        private System.Windows.Forms.BindingSource roomsInfoBindingSource;
    }
}

