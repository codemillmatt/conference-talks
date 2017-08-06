using System;

using UIKit;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Media.Abstractions;
using Plugin.Media;
using Microsoft.ProjectOxford.Vision;
using Foundation;
using Plugin.TextToSpeech;
using Microsoft.ProjectOxford.Vision.Contract;
using CoreGraphics;
using System.Linq;
using System.Collections.Generic;

namespace describe
{
    public partial class ViewController : UIViewController
    {
        UIAlertController overallSheet = null;
        LoadingView loading;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            BuildActionSheetOptions();

            theButton.TouchUpInside += (sender, e) => PresentViewController(overallSheet, true, null);
            thePhoto.ContentMode = UIViewContentMode.ScaleAspectFit;
            thePhoto.BackgroundColor = UIColor.Black;

            theText.Text = "No photo yet";
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void BuildActionSheetOptions()
        {
            overallSheet = UIAlertController.Create("Pick", "Pick your poison", UIAlertControllerStyle.ActionSheet);

            var photo = UIAlertAction.Create("Take Photo", UIAlertActionStyle.Default, async (obj) => await PerformRecognition(true));
            var library = UIAlertAction.Create("Pick Photo", UIAlertActionStyle.Default, async (obj) => await PerformRecognition(false));

            var cancel = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null);

            overallSheet.AddAction(library);
            overallSheet.AddAction(photo);
            overallSheet.AddAction(cancel);
        }

        async Task PerformRecognition(bool takePhoto)
        {
			thePhoto.Image = null;
			theText.Text = "";
            thePhoto.BackgroundColor = UIColor.Black;

			loading = new LoadingView(UIScreen.MainScreen.Bounds);

			MediaFile photo = null;

            if (takePhoto)
                photo = await TakePhoto();
            else
                photo = await PickPhoto();

            if (photo == null)
                return;

            View.Add(loading);

            var vision = new VisionServiceClient("YOUR API KEY GOES HERE", "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0");

            using (var photoStream = photo.GetStream())
            {
                var oldImage = new UIImage(NSData.FromStream(photoStream));

                thePhoto.Image = oldImage;

                photoStream.Position = 0;

                var results = await vision.AnalyzeImageAsync(photoStream,
                    new List<VisualFeature>
                    {
                        VisualFeature.Categories,VisualFeature.Description,VisualFeature.Faces, VisualFeature.Tags, VisualFeature.Color,
                    }, null);

                ChangeImageViewBackground(results?.Color);

                OutputAllSceneInfo(results);

                DrawFaceRects(oldImage, results?.Faces);

                loading.Hide();
                loading = null;

                await SpeakFaceInfo(results?.Faces);

                await SpeakSceneInfo(results?.Description);
            }
        }

        void ChangeImageViewBackground(Color color)
        {
            if (color?.AccentColor == null)
                return;


            var redColor = Convert.ToInt32(color.AccentColor.Substring(0, 2), 16);
            var greenColor = Convert.ToInt32(color.AccentColor.Substring(2, 2), 16);
            var blueColor = Convert.ToInt32(color.AccentColor.Substring(4, 2), 16);

            var imageBackground = UIColor.FromRGBA(redColor, greenColor, blueColor, 90);

            thePhoto.BackgroundColor = imageBackground;
        }

        async Task<bool> AskCameraPermission()
        {
            var permission = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

            if (permission != PermissionStatus.Granted)
            {
                var request = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);

                if (request.ContainsKey(Permission.Camera))
                    permission = request[Permission.Camera];
            }

            return permission == PermissionStatus.Granted;
        }

        async Task<MediaFile> TakePhoto()
        {
            if (!await AskCameraPermission())
                return null;

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                return null;

            var photo = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions { CompressionQuality = 50, PhotoSize = PhotoSize.Medium, SaveToAlbum = false }
            );

            return photo;
        }
        async Task<bool> AskPhotoLibraryPermission()
        {
            var permission = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);

            if (permission != PermissionStatus.Granted)
            {
                var request = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Photos);

                if (request.ContainsKey(Permission.Photos))
                    permission = request[Permission.Photos];
            }

            return permission == PermissionStatus.Granted;
        }

        async Task<MediaFile> PickPhoto()
        {
            if (!await AskPhotoLibraryPermission())
                return null;

            if (!CrossMedia.Current.IsPickPhotoSupported)
                return null;

            var photo = await CrossMedia.Current.PickPhotoAsync(
                new PickMediaOptions { CompressionQuality = 50, PhotoSize = PhotoSize.Medium }
            );

            return photo;
        }

        async Task SpeakFaceInfo(Face[] faces)
        {
            if (faces == null || faces.Length == 0)
                return;


            if (faces.Length > 2)
            {
                await CrossTextToSpeech.Current.Speak($"There are {faces.Length} faces");
            }

            foreach (var face in faces)
            {
                await CrossTextToSpeech.Current.Speak($"I see a {face.Age} year old {face.Gender}");
            }
        }

        async Task SpeakSceneInfo(Description description)
        {
            if (description?.Captions == null)
                return;

            var orderedCaptions = description.Captions.ToList().OrderByDescending(c => c.Confidence);

            int captionNumber = 1;
            foreach (var caption in orderedCaptions)
            {
                if (captionNumber == 1)
                    await CrossTextToSpeech.Current.Speak($"I'm looking at a {caption.Text}");
                else
                    await CrossTextToSpeech.Current.Speak($"And a {caption.Text}");

                captionNumber += 1;
            }
        }

        void DrawFaceRects(UIImage oldImage, Face[] faces)
        {
            if (faces == null || faces.Length == 0)
                return;

            UIGraphics.BeginImageContext(oldImage.Size);

            oldImage.Draw(new CGPoint(0, 0));

            var ctx = UIGraphics.GetCurrentContext();

            ctx.SetLineWidth(10);

            foreach (var face in faces)
            {
                var rectColor = UIColor.Red.CGColor;
                ctx.SetStrokeColor(rectColor);

                var right = (nfloat)(face.FaceRectangle.Left + face.FaceRectangle.Width);
                var bottom = (nfloat)(face.FaceRectangle.Top + face.FaceRectangle.Height);

                var left = (nfloat)face.FaceRectangle.Left;
                var top = (nfloat)face.FaceRectangle.Top;

                var factRect = CGRect.FromLTRB(left, top, right, bottom);

                ctx.StrokeRect(factRect);
            }

            var newImage = UIGraphics.GetImageFromCurrentImageContext();

            UIGraphics.EndImageContext();

            thePhoto.Image = newImage;
        }

        void OutputAllSceneInfo(AnalysisResult result)
        {
            var mutable = new NSMutableAttributedString();

            // First do the faces
            var headingAttributes = new UIStringAttributes
            {
                Font = UIFont.PreferredHeadline
            };
            var subHeadingAttr = new UIStringAttributes
            {
                Font = UIFont.PreferredSubheadline
            };

            var breakLine = new NSAttributedString(Environment.NewLine, new UIStringAttributes { Font = UIFont.PreferredBody });

            var descriptionHeading = new NSAttributedString("Description", headingAttributes);

            if (result?.Description != null)
            {
                mutable.Append(descriptionHeading);
                mutable.Append(breakLine);

                if (result.Description?.Captions != null && result.Description.Captions.Count() > 0)
                {
                    var captionHeading = new NSAttributedString("Caption", subHeadingAttr);
                    mutable.Append(captionHeading);
                    mutable.Append(breakLine);

                    var orderedCaptions = result.Description.Captions.ToList().OrderByDescending(c => c.Confidence);

                    foreach (var caption in orderedCaptions)
                    {
                        var captionInfo = $" - {caption.Text}";
                        var captionString = new NSAttributedString(captionInfo, new UIStringAttributes { Font = UIFont.PreferredBody });

                        mutable.Append(captionString);
                        mutable.Append(breakLine);
                    }
                }
            }

            var faceHeading = new NSAttributedString("Faces", headingAttributes);

            if (result?.Faces != null && result.Faces.Count() > 0)
            {
                mutable.Append(faceHeading);
                mutable.Append(breakLine);
                foreach (var face in result.Faces)
                {
                    var faceInfo = $" - {face.Gender} - {face.Age} years old.";
                    var faceString = new NSAttributedString(faceInfo, new UIStringAttributes { Font = UIFont.PreferredBody });

                    mutable.Append(faceString);
                    mutable.Append(breakLine);
                }
            }

            var tagHeading = new NSAttributedString("Tags", headingAttributes);

            if (result?.Tags != null && result.Tags.Count() > 0)
            {
                mutable.Append(tagHeading);
                mutable.Append(breakLine);
                var orderedTags = result.Tags.ToList().OrderByDescending(t => t.Confidence);
                foreach (var tag in orderedTags)
                {
                    var tagInfo = $" - {tag.Name}";
                    var tagString = new NSAttributedString(tagInfo, new UIStringAttributes { Font = UIFont.PreferredBody });

                    mutable.Append(tagString);
                    mutable.Append(breakLine);
                }
            }

            var categoryHeading = new NSAttributedString("Categories", headingAttributes);

            if (result?.Categories != null && result.Categories.Count() > 0)
            {
                mutable.Append(categoryHeading);
                mutable.Append(breakLine);
                var orderedCategories = result.Categories.ToList().OrderByDescending(c => c.Score);
                foreach (var category in orderedCategories)
                {
                    var categoryInfo = $"  - {category.Name}";
                    var categoryString = new NSAttributedString(categoryInfo, new UIStringAttributes { Font = UIFont.PreferredBody });

                    mutable.Append(categoryString);
                    mutable.Append(breakLine);
                }
            }

            theText.AttributedText = mutable;
        }
    }
}
