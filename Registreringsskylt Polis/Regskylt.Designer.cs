namespace Registreringsskylt_Polis
{
    partial class Regskylt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Regskylt));
            this.ICarImageInput = new System.Windows.Forms.PictureBox();
            this.IClose = new System.Windows.Forms.PictureBox();
            this.ILicensePlatePlaceholder = new System.Windows.Forms.Label();
            this.IModelPlaceholder = new System.Windows.Forms.Label();
            this.IPolicePlaceholder = new System.Windows.Forms.Label();
            this.IPolice = new System.Windows.Forms.Label();
            this.asyncTimer = new System.Windows.Forms.Timer(this.components);
            this.IModel = new System.Windows.Forms.Label();
            this.IPoliceLogo = new System.Windows.Forms.PictureBox();
            this.IEnlagedLicenseplate = new System.Windows.Forms.PictureBox();
            this.ILicensePlate = new System.Windows.Forms.Label();
            this.licenseplateTextAnimation = new System.Windows.Forms.Timer(this.components);
            this.modelTextAnimation = new System.Windows.Forms.Timer(this.components);
            this.policeTextAnimation = new System.Windows.Forms.Timer(this.components);
            this.IOwner = new System.Windows.Forms.Label();
            this.IOwnerPlaceholder = new System.Windows.Forms.Label();
            this.ownerTextAnimation = new System.Windows.Forms.Timer(this.components);
            this.IGoNext = new System.Windows.Forms.PictureBox();
            this.IGoPrev = new System.Windows.Forms.PictureBox();
            this.ICurrentCar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ICarImageInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPoliceLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IEnlagedLicenseplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IGoNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IGoPrev)).BeginInit();
            this.SuspendLayout();
            // 
            // ICarImageInput
            // 
            this.ICarImageInput.BackColor = System.Drawing.Color.Transparent;
            this.ICarImageInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ICarImageInput.Image = ((System.Drawing.Image)(resources.GetObject("ICarImageInput.Image")));
            this.ICarImageInput.Location = new System.Drawing.Point(148, 11);
            this.ICarImageInput.Name = "ICarImageInput";
            this.ICarImageInput.Size = new System.Drawing.Size(464, 257);
            this.ICarImageInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ICarImageInput.TabIndex = 1;
            this.ICarImageInput.TabStop = false;
            this.ICarImageInput.Click += new System.EventHandler(this.ICarImageInput_Click);
            // 
            // IClose
            // 
            this.IClose.BackColor = System.Drawing.Color.Transparent;
            this.IClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IClose.Image = ((System.Drawing.Image)(resources.GetObject("IClose.Image")));
            this.IClose.Location = new System.Drawing.Point(729, 0);
            this.IClose.Name = "IClose";
            this.IClose.Size = new System.Drawing.Size(32, 32);
            this.IClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IClose.TabIndex = 3;
            this.IClose.TabStop = false;
            this.IClose.Click += new System.EventHandler(this.IClose_Click);
            // 
            // ILicensePlatePlaceholder
            // 
            this.ILicensePlatePlaceholder.BackColor = System.Drawing.Color.Transparent;
            this.ILicensePlatePlaceholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ILicensePlatePlaceholder.ForeColor = System.Drawing.Color.White;
            this.ILicensePlatePlaceholder.Location = new System.Drawing.Point(12, 317);
            this.ILicensePlatePlaceholder.Name = "ILicensePlatePlaceholder";
            this.ILicensePlatePlaceholder.Size = new System.Drawing.Size(320, 69);
            this.ILicensePlatePlaceholder.TabIndex = 4;
            this.ILicensePlatePlaceholder.Text = "License plate:";
            this.ILicensePlatePlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IModelPlaceholder
            // 
            this.IModelPlaceholder.BackColor = System.Drawing.Color.Transparent;
            this.IModelPlaceholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IModelPlaceholder.ForeColor = System.Drawing.Color.White;
            this.IModelPlaceholder.Location = new System.Drawing.Point(165, 385);
            this.IModelPlaceholder.Name = "IModelPlaceholder";
            this.IModelPlaceholder.Size = new System.Drawing.Size(176, 54);
            this.IModelPlaceholder.TabIndex = 5;
            this.IModelPlaceholder.Text = "Model:";
            this.IModelPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IPolicePlaceholder
            // 
            this.IPolicePlaceholder.BackColor = System.Drawing.Color.Transparent;
            this.IPolicePlaceholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPolicePlaceholder.ForeColor = System.Drawing.Color.White;
            this.IPolicePlaceholder.Location = new System.Drawing.Point(165, 440);
            this.IPolicePlaceholder.Name = "IPolicePlaceholder";
            this.IPolicePlaceholder.Size = new System.Drawing.Size(400, 55);
            this.IPolicePlaceholder.TabIndex = 7;
            this.IPolicePlaceholder.Text = "Police:";
            this.IPolicePlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IPolice
            // 
            this.IPolice.BackColor = System.Drawing.Color.Transparent;
            this.IPolice.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPolice.ForeColor = System.Drawing.Color.Red;
            this.IPolice.Location = new System.Drawing.Point(323, 439);
            this.IPolice.Name = "IPolice";
            this.IPolice.Size = new System.Drawing.Size(197, 56);
            this.IPolice.TabIndex = 8;
            this.IPolice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // asyncTimer
            // 
            this.asyncTimer.Interval = 10;
            this.asyncTimer.Tick += new System.EventHandler(this.AsyncTimer_Tick);
            // 
            // IModel
            // 
            this.IModel.BackColor = System.Drawing.Color.Transparent;
            this.IModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IModel.ForeColor = System.Drawing.Color.White;
            this.IModel.Location = new System.Drawing.Point(322, 385);
            this.IModel.Name = "IModel";
            this.IModel.Size = new System.Drawing.Size(427, 54);
            this.IModel.TabIndex = 10;
            this.IModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IPoliceLogo
            // 
            this.IPoliceLogo.BackColor = System.Drawing.Color.Transparent;
            this.IPoliceLogo.Image = ((System.Drawing.Image)(resources.GetObject("IPoliceLogo.Image")));
            this.IPoliceLogo.Location = new System.Drawing.Point(1, 11);
            this.IPoliceLogo.Name = "IPoliceLogo";
            this.IPoliceLogo.Size = new System.Drawing.Size(100, 100);
            this.IPoliceLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IPoliceLogo.TabIndex = 11;
            this.IPoliceLogo.TabStop = false;
            // 
            // IEnlagedLicenseplate
            // 
            this.IEnlagedLicenseplate.BackColor = System.Drawing.Color.Transparent;
            this.IEnlagedLicenseplate.Location = new System.Drawing.Point(1, 117);
            this.IEnlagedLicenseplate.Name = "IEnlagedLicenseplate";
            this.IEnlagedLicenseplate.Size = new System.Drawing.Size(100, 52);
            this.IEnlagedLicenseplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IEnlagedLicenseplate.TabIndex = 12;
            this.IEnlagedLicenseplate.TabStop = false;
            this.IEnlagedLicenseplate.Paint += new System.Windows.Forms.PaintEventHandler(this.IEnlargedLicenseplate_Paint);
            // 
            // ILicensePlate
            // 
            this.ILicensePlate.BackColor = System.Drawing.Color.Transparent;
            this.ILicensePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ILicensePlate.ForeColor = System.Drawing.Color.White;
            this.ILicensePlate.Location = new System.Drawing.Point(322, 317);
            this.ILicensePlate.Name = "ILicensePlate";
            this.ILicensePlate.Size = new System.Drawing.Size(427, 69);
            this.ILicensePlate.TabIndex = 13;
            this.ILicensePlate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // licenseplateTextAnimation
            // 
            this.licenseplateTextAnimation.Tick += new System.EventHandler(this.licenseplateTextAnimation_Tick);
            // 
            // modelTextAnimation
            // 
            this.modelTextAnimation.Tick += new System.EventHandler(this.modelTextAnimation_Tick);
            // 
            // policeTextAnimation
            // 
            this.policeTextAnimation.Tick += new System.EventHandler(this.policeTextAnimation_Tick);
            // 
            // IOwner
            // 
            this.IOwner.BackColor = System.Drawing.Color.Transparent;
            this.IOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IOwner.ForeColor = System.Drawing.Color.Lime;
            this.IOwner.Location = new System.Drawing.Point(323, 496);
            this.IOwner.Name = "IOwner";
            this.IOwner.Size = new System.Drawing.Size(426, 56);
            this.IOwner.TabIndex = 15;
            this.IOwner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IOwnerPlaceholder
            // 
            this.IOwnerPlaceholder.BackColor = System.Drawing.Color.Transparent;
            this.IOwnerPlaceholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IOwnerPlaceholder.ForeColor = System.Drawing.Color.White;
            this.IOwnerPlaceholder.Location = new System.Drawing.Point(154, 495);
            this.IOwnerPlaceholder.Name = "IOwnerPlaceholder";
            this.IOwnerPlaceholder.Size = new System.Drawing.Size(400, 55);
            this.IOwnerPlaceholder.TabIndex = 14;
            this.IOwnerPlaceholder.Text = "Owner:";
            this.IOwnerPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ownerTextAnimation
            // 
            this.ownerTextAnimation.Tick += new System.EventHandler(this.ownerTextAnimation_Tick);
            // 
            // IGoNext
            // 
            this.IGoNext.BackColor = System.Drawing.Color.Transparent;
            this.IGoNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IGoNext.Image = ((System.Drawing.Image)(resources.GetObject("IGoNext.Image")));
            this.IGoNext.Location = new System.Drawing.Point(559, 274);
            this.IGoNext.Name = "IGoNext";
            this.IGoNext.Size = new System.Drawing.Size(53, 52);
            this.IGoNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IGoNext.TabIndex = 16;
            this.IGoNext.TabStop = false;
            this.IGoNext.Visible = false;
            this.IGoNext.Click += new System.EventHandler(this.IGoNext_Click);
            // 
            // IGoPrev
            // 
            this.IGoPrev.BackColor = System.Drawing.Color.Transparent;
            this.IGoPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IGoPrev.Image = ((System.Drawing.Image)(resources.GetObject("IGoPrev.Image")));
            this.IGoPrev.Location = new System.Drawing.Point(148, 274);
            this.IGoPrev.Name = "IGoPrev";
            this.IGoPrev.Size = new System.Drawing.Size(53, 52);
            this.IGoPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IGoPrev.TabIndex = 17;
            this.IGoPrev.TabStop = false;
            this.IGoPrev.Visible = false;
            this.IGoPrev.Click += new System.EventHandler(this.IGoPrev_Click);
            // 
            // ICurrentCar
            // 
            this.ICurrentCar.BackColor = System.Drawing.Color.Transparent;
            this.ICurrentCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ICurrentCar.ForeColor = System.Drawing.Color.White;
            this.ICurrentCar.Location = new System.Drawing.Point(207, 274);
            this.ICurrentCar.Name = "ICurrentCar";
            this.ICurrentCar.Size = new System.Drawing.Size(346, 52);
            this.ICurrentCar.TabIndex = 18;
            this.ICurrentCar.Text = "1/3";
            this.ICurrentCar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ICurrentCar.Visible = false;
            // 
            // Regskylt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(761, 556);
            this.Controls.Add(this.ICurrentCar);
            this.Controls.Add(this.IGoPrev);
            this.Controls.Add(this.IGoNext);
            this.Controls.Add(this.IOwner);
            this.Controls.Add(this.IOwnerPlaceholder);
            this.Controls.Add(this.ILicensePlate);
            this.Controls.Add(this.IEnlagedLicenseplate);
            this.Controls.Add(this.IPoliceLogo);
            this.Controls.Add(this.IModel);
            this.Controls.Add(this.IPolice);
            this.Controls.Add(this.IPolicePlaceholder);
            this.Controls.Add(this.IModelPlaceholder);
            this.Controls.Add(this.ILicensePlatePlaceholder);
            this.Controls.Add(this.IClose);
            this.Controls.Add(this.ICarImageInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Regskylt";
            this.Text = "Yeee";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Regskylt_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.ICarImageInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPoliceLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IEnlagedLicenseplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IGoNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IGoPrev)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox ICarImageInput;
        private System.Windows.Forms.PictureBox IClose;
        private System.Windows.Forms.Label ILicensePlatePlaceholder;
        private System.Windows.Forms.Label IModelPlaceholder;
        private System.Windows.Forms.Label IPolicePlaceholder;
        private System.Windows.Forms.Label IPolice;
        private System.Windows.Forms.Timer asyncTimer;
        private System.Windows.Forms.Label IModel;
        private System.Windows.Forms.PictureBox IPoliceLogo;
        private System.Windows.Forms.PictureBox IEnlagedLicenseplate;
        private System.Windows.Forms.Label ILicensePlate;
        private System.Windows.Forms.Timer licenseplateTextAnimation;
        private System.Windows.Forms.Timer modelTextAnimation;
        private System.Windows.Forms.Timer policeTextAnimation;
        private System.Windows.Forms.Label IOwner;
        private System.Windows.Forms.Label IOwnerPlaceholder;
        private System.Windows.Forms.Timer ownerTextAnimation;
        private System.Windows.Forms.PictureBox IGoNext;
        private System.Windows.Forms.PictureBox IGoPrev;
        private System.Windows.Forms.Label ICurrentCar;
    }
}

