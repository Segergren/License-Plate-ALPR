using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registreringsskylt_Polis
{
    public partial class Regskylt : Form
    {

        public Regskylt()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Needed DLLs to move the UI.
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        // End of needed DLLs

        string imagePath = null;
        ArrayList cacheLicensePlate = new ArrayList();
        ArrayList cacheModel = new ArrayList();
        ArrayList cacheAIModel = new ArrayList();
        ArrayList cachePolice = new ArrayList();
        ArrayList cacheName = new ArrayList();
        JArray items;

        int foundCars = 0;
        int currentCar = 0;

        int[] width = new int[10];
        int[] height = new int[10];

        int[] startY = new int[10];
        int[] startX = new int[10];

        /// <summary>
        /// Resets the cache.
        /// </summary>
        private void ResetCache()
        {
            cacheLicensePlate.Clear();
            cacheModel.Clear();
            cachePolice.Clear();
            cacheAIModel.Clear();
            cacheName.Clear();
        }

        /// <summary>
        /// Resets the UI text.
        /// </summary>
        private void IResetText()
        {
            IOwner.Font = new Font(IOwner.Font.FontFamily, 36, IOwner.Font.Style);
            IModel.Font = new Font(IOwner.Font.FontFamily, 36, IOwner.Font.Style);

            ILicensePlate.Text = "";
            IModel.Text = "";
            IPolice.Text = "";
            IOwner.Text = "";
            ICurrentCar.Text = "";
        }

        Point[] Zoompoint = new Point[10];
        Size[] Zoomsize = new Size[10];

        /// <summary>
        /// Processes the information from the JSON text.
        /// </summary>
        string task_result;
        private async void GetInfo()
        {
            try
            {
                //Gets the license plate and model.
                Task<string> recognizeTask = Task.Run(() => ProcessImage(imagePath));
                recognizeTask.Wait();
                task_result = recognizeTask.Result;
                var CarInfo = Newtonsoft.Json.JsonConvert.DeserializeObject(task_result);
                JObject o = JObject.Parse(task_result);
                items = (JArray)o["results"];
                int length = items.Count;
                Console.WriteLine(o.ToString());
                foundCars = (items.Count - 1);

                int mostLeft = 0;
                //Loads the license plate and model to the cache strings.
                for (int i = 0; i < items.Count; i++)
                {

                    //var item = (JObject)items[i];
                    cacheLicensePlate.Insert(i, Convert.ToString(o["results"][i]["plate"]));

                    string[] modelArray = Convert.ToString(o["results"][i]["vehicle"]["make_model"][0]["name"]).Replace("_", " ").Split(' ');
                    string tempModel = "";
                    foreach (string model in modelArray)
                    {
                        tempModel += model.Substring(0, 1).ToUpper() + model.Substring(1).ToLower() + " ";
                    }
                    cacheAIModel.Insert(i, tempModel.ToString().Trim());

                    //Gets the height, width, and X,Y possitions of the license plate.
                    width[i] = Convert.ToInt32(o["results"][i]["coordinates"][1]["x"]) - Convert.ToInt32(o["results"][i]["coordinates"][0]["x"]);
                    height[i] = Convert.ToInt32(o["results"][i]["coordinates"][2]["y"]) - Convert.ToInt32(o["results"][i]["coordinates"][0]["y"]);

                    startY[i] = Convert.ToInt32(o["results"][i]["coordinates"][0]["y"]);
                    startX[i] = Convert.ToInt32(o["results"][i]["coordinates"][0]["x"]);
                    if (Convert.ToInt32(o["results"][i]["coordinates"][2]["y"]) < Convert.ToInt32(o["results"][i]["coordinates"][0]["y"]))
                    {
                        startY[i] = Convert.ToInt32(o["results"][i]["coordinates"][0]["y"]);
                        height[i] = Convert.ToInt32(o["results"][i]["coordinates"][0]["y"]) - Convert.ToInt32(o["results"][i]["coordinates"][2]["y"]);
                    }
                    if (Convert.ToInt32(o["results"][i]["coordinates"][2]["y"]) - Convert.ToInt32(o["results"][i]["coordinates"][1]["y"]) > height[i])
                    {
                        height[i] = Convert.ToInt32(o["results"][i]["coordinates"][3]["y"]) - Convert.ToInt32(o["results"][i]["coordinates"][1]["y"]);
                        startY[i] = Convert.ToInt32(o["results"][i]["coordinates"][1]["y"]);
                    }
                    if (startX[i] < startX[mostLeft])
                    {
                        mostLeft = i;
                    }
                }
                currentCar = mostLeft;
                LicensePlateDraw();
                //Gets more information about the car.
                using (var httpClient = new HttpClient())
                {
                    try
                    {

                        for (int i = 0; i < items.Count; i++)
                        {
                            var json = await httpClient.GetStringAsync("https://o11.se/Fordonsinfo/bilinfo.php?q=all&reg=" + o["results"][i]["plate"]);
                            dynamic results = JsonConvert.DeserializeObject<dynamic>(json);
                            var model = results.model;
                            var police = results.police;
                            var name = results.owner;
                            cacheName.Insert(i, name);
                            //byte[] bytes = Encoding.GetEncoding(1252).GetBytes(name);
                            //cacheName.Insert(i, Encoding.UTF8.GetString(bytes));
                            if (model != null)
                            {
                                cacheModel.Insert(i, model);
                            }
                            else
                            {
                                cacheModel.Insert(i, cacheAIModel[i]);
                            }
                            if (police == "true")
                            {
                                cachePolice.Insert(i, "Yes");
                            }
                            else
                            {
                                cachePolice.Insert(i, "No");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There is no available information about the car!" + ex.StackTrace, "No information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No license plate found in the picture\n" + ex.StackTrace, "No car found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LicensePlateDraw()
        {

            //Loads the image.
            ICarImageInput.Load(imagePath);
            Bitmap bitmap = (Bitmap)ICarImageInput.Image;

            //Writes the rectangle around the license plate.
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Pen pen = new Pen(Color.Red, 5);
                float[] dashValues = { 1f, 1f };
                pen.DashPattern = dashValues;
                pen.Alignment = PenAlignment.Inset;
                graphics.DrawRectangle(pen, startX[currentCar], startY[currentCar], width[currentCar], height[currentCar]);
                Zoompoint[currentCar] = new Point(startX[currentCar], startY[currentCar]);
                Zoomsize[currentCar] = new Size(width[currentCar], height[currentCar]);
            }
        }


        /// <summary>
        /// Processes the image and sends the image to the API.
        /// </summary>
        /// <param name="image_path">Path of the image.</param>
        /// <returns>Returns the JSON.</returns>
        public static async Task<string> ProcessImage(string image_path)
        {
            var client = new HttpClient(new HttpClientHandler
            {
                UseProxy = false
            });
            APIKeys apiKey = new APIKeys();
            string SECRET_KEY = apiKey.API_KEY;
            Byte[] bytes = File.ReadAllBytes(image_path);
            string imagebase64 = Convert.ToBase64String(bytes);
            var content = new StringContent(imagebase64);
            var response = await client.PostAsync("https://api.openalpr.com/v2/recognize_bytes?recognize_vehicle=1&country=eu&secret_key=" + SECRET_KEY, content).ConfigureAwait(false);
            var buffer = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            var byteArray = buffer.ToArray();
            var responseString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);

            return responseString;
        }

        /// <summary>
        /// Makes it possible to move the UI.
        /// </summary>
        private void Regskylt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        bool LicenseplateAnalyzed = false;
        bool ModelAnalyzed = false;
        bool PoliceAnalyzed = false;
        bool NameAnalyzed = false;

        /// <summary>
        /// Checks if the application has receved the information about the car.
        /// </summary>
        private void AsyncTimer_Tick(object sender, EventArgs e)
        {
            if (cachePolice.Count > currentCar)
            {
                if (cachePolice[0].ToString().Length != 0 && PoliceAnalyzed == false)
                {
                    PoliceAnalyzed = true;
                    policeTextAnimation.Start();
                }
            }
            if (cacheLicensePlate.Count > currentCar)
            {
                if (cacheLicensePlate[0].ToString().Length != 0 && LicenseplateAnalyzed == false)
                {
                    LicenseplateAnalyzed = true;
                    licenseplateTextAnimation.Start();
                }
            }
            if (cacheName.Count > currentCar)
            {
                if (cacheName[0] != null && NameAnalyzed == false)
                {
                    NameAnalyzed = true;
                    ownerTextAnimation.Start();
                }
            }


            if (items != null && cacheModel.Count == items.Count)
            {
                if (cacheModel[currentCar] != null && ModelAnalyzed == false)
                {
                    ModelAnalyzed = true;
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (cacheModel[i].ToString().Length == 0)
                        {
                            cacheModel[i] = cacheAIModel[i];
                        }
                    }
                    modelTextAnimation.Start();
                    IModel.Font = new Font(IModel.Font.FontFamily, 36f, IModel.Font.Style);

                    while (IModel.Width < System.Windows.Forms.TextRenderer.MeasureText(IModel.Text,
                        new Font(IModel.Font.FontFamily, IModel.Font.Size, IModel.Font.Style)).Width)
                    {
                        IModel.Font = new Font(IModel.Font.FontFamily, IModel.Font.Size - 0.5f, IModel.Font.Style);
                    }
                }
            }


            if (ModelAnalyzed == true && LicenseplateAnalyzed == true && PoliceAnalyzed == true)
            {
                //Clipboard.SetText(task_result);
                asyncTimer.Stop();
                LicenseplateAnalyzed = false;
                ModelAnalyzed = false;
                PoliceAnalyzed = false;
                NameAnalyzed = false;
                Rectangle regge = new Rectangle(Zoompoint[currentCar], Zoomsize[currentCar]);
                Bitmap bmpImage = new Bitmap(imagePath);
                IEnlagedLicenseplate.Show();
                IEnlagedLicenseplate.Image = (Image)bmpImage.Clone(regge, bmpImage.PixelFormat);
                ICurrentCar.Text = (currentCar+1) + "/" + (foundCars+1);
                ICurrentCar.Visible = true;
                UpdateNav();
            }
        }

        private void UpdateNav()
        {
            if (foundCars > currentCar)
            {
                IGoNext.Visible = true;
                if (currentCar == 0)
                {
                    IGoPrev.Visible = false;
                }
            }
            else if (currentCar > 0)
            {
                IGoPrev.Visible = true;
                IGoNext.Visible = false;
            }
            else
            {
                IGoNext.Visible = false;
                IGoPrev.Visible = false;
            }          
        }

        /// <summary>
        /// Encodes and Decodes text.
        /// </summary>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Opens a file dialog where the user can choose picture.
        /// </summary>
        private void ICarImageInput_Click(object sender, EventArgs e)
        {
            StopTimers();
            ResetCache();
            OpenFileDialog Open = new OpenFileDialog();
            Open.Filter = "Image files (*.jpg, *.jpeg, *.gif, *.png) | *.jpg; *.jpeg; *.gif; *.png";

            if (Open.ShowDialog(this) == DialogResult.OK)
            {
                imagePath = Open.InitialDirectory + Open.FileName;
                ICarImageInput.Load(imagePath);
                IEnlagedLicenseplate.Hide();

                IResetText();
                Task.Factory.StartNew(() => GetInfo());
                asyncTimer.Start();
            }
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        private void IClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Makes round corners on the enlarge image of the license plate.
        /// </summary>
        private void IEnlargedLicenseplate_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, IEnlagedLicenseplate.Width, IEnlagedLicenseplate.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            int d = 10;
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            IEnlagedLicenseplate.Region = new Region(gp);
        }


        /// <summary>
        /// Methods under this is for UI animation only.
        /// </summary>

        int index_Numreg = 0;
        int index_Nummod = 0;
        int index_Numpol = 0;
        int index_Numown = 0;

        private void licenseplateTextAnimation_Tick(object sender, EventArgs e)
        {
            try
            {
                if (index_Numreg == cacheLicensePlate[currentCar].ToString().Length)
                {
                    ILicensePlate.Text = cacheLicensePlate[currentCar].ToString().Substring(0, index_Numreg);
                    index_Numreg++;
                    licenseplateTextAnimation.Stop();
                    index_Numreg = 0;
                }
                else
                {
                    ILicensePlate.Text = cacheLicensePlate[currentCar].ToString().Substring(0, index_Numreg);
                    index_Numreg++;
                }
            }
            catch { }
        }

        private void modelTextAnimation_Tick(object sender, EventArgs e)
        {
            try
            {
                if (index_Nummod == cacheModel[currentCar].ToString().Length)
                {
                    IModel.Text = cacheModel[currentCar].ToString().Substring(0, index_Nummod);
                    index_Nummod++;
                    modelTextAnimation.Stop();
                    index_Nummod = 0;
                }
                else
                {
                    IModel.Text = cacheModel[currentCar].ToString().Substring(0, index_Nummod);
                    index_Nummod++;
                }
                while (IModel.Width < System.Windows.Forms.TextRenderer.MeasureText(IModel.Text,
                new Font(IModel.Font.FontFamily, IModel.Font.Size, IModel.Font.Style)).Width)
                {
                    IModel.Font = new Font(IModel.Font.FontFamily, IModel.Font.Size - 0.5f, IModel.Font.Style);
                }
            }
            catch { }
        }

        private void policeTextAnimation_Tick(object sender, EventArgs e)
        {
            try
            {
                if (index_Numpol == cachePolice[currentCar].ToString().Length)
                {
                    IPolice.Text = cachePolice[currentCar].ToString().Substring(0, index_Numpol);
                    index_Numpol++;
                    policeTextAnimation.Stop();
                    index_Numpol = 0;
                    if (!cachePolice[currentCar].Equals("Yes"))
                    {
                        IPolice.ForeColor = Color.Lime;
                    }
                    else
                    {
                        IPolice.ForeColor = Color.Red;
                    }
                }
                else
                {
                    IPolice.Text = cachePolice[currentCar].ToString().Substring(0, index_Numpol);
                    index_Numpol++;
                }
            }
            catch { }
        }

        private void ownerTextAnimation_Tick(object sender, EventArgs e)
        {
            try
            {
                if (index_Numown == cacheName[currentCar].ToString().Length)
                {
                    IOwner.Text = cacheName[currentCar].ToString().Substring(0, index_Numown);
                    index_Numown++;
                    ownerTextAnimation.Stop();
                    index_Numown = 0;
                }
                else
                {
                    IOwner.Text = cacheName[currentCar].ToString().Substring(0, index_Numown);
                    index_Numown++;
                }
                while (IOwner.Width < System.Windows.Forms.TextRenderer.MeasureText(IOwner.Text,
                new Font(IOwner.Font.FontFamily, IOwner.Font.Size, IOwner.Font.Style)).Width)
                {
                    IOwner.Font = new Font(IOwner.Font.FontFamily, IOwner.Font.Size - 0.5f, IOwner.Font.Style);
                }
            }
            catch { }
        }

        //Move to previous vehicle
        private void IGoPrev_Click(object sender, EventArgs e)
        {
            StopTimers();
            currentCar--;
            IResetText();
            asyncTimer.Start();
            UpdateNav();
            LicensePlateDraw();
        }

        //Move to next vehicle
        private void IGoNext_Click(object sender, EventArgs e)
        {
            StopTimers();
            currentCar++;
            IResetText();
            asyncTimer.Start();
            UpdateNav();
            LicensePlateDraw();
        }

        private void StopTimers()
        {
            modelTextAnimation.Stop();
            ownerTextAnimation.Stop();
            policeTextAnimation.Stop();
            licenseplateTextAnimation.Stop();
        }
    }
}
