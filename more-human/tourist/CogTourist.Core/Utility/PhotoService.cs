using System;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Media;
using System.IO;

namespace CogTourist.Core
{
    public class PhotoService
    {
        public async Task<MediaFile> PickPhoto()
        {
            try
            {
                if (!await CheckPhotoLibraryPermissions())
                    return null;

                if (!CrossMedia.Current.IsPickPhotoSupported)
                    return null;

                return await CrossMedia.Current.PickPhotoAsync(GetPickOptions());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<MediaFile> TakePhoto()
        {
            try
            {
                if (!await CheckCameraPermissions())
                    return null;

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    return null;

                return await CrossMedia.Current.TakePhotoAsync(GetPhotoOptions());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        PickMediaOptions GetPickOptions()
        {
            return new PickMediaOptions
            {
                CompressionQuality = 50,
                PhotoSize = PhotoSize.Large
            };
        }

        StoreCameraMediaOptions GetPhotoOptions()
        {
            return new StoreCameraMediaOptions
            {
                SaveToAlbum = false,
                PhotoSize = PhotoSize.Medium,
                CompressionQuality = 50
            };
        }
        async Task<bool> CheckCameraPermissions()
        {
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

            if (cameraStatus != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                {
                    // TODO: Show a dialog
                }

                var grantedPermissions = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);

                if (grantedPermissions.ContainsKey(Permission.Camera))
                    cameraStatus = grantedPermissions[Permission.Camera];
            }

            return cameraStatus == PermissionStatus.Granted;
        }

        async Task<bool> CheckPhotoLibraryPermissions()
        {
            var photoStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);

            if (photoStatus != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Photos))
                {
                    // TODO: show a dialog
                }

                var grantedPermissions = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Photos);

                if (grantedPermissions.ContainsKey(Permission.Photos))
                    photoStatus = grantedPermissions[Permission.Photos];
            }

            return photoStatus == PermissionStatus.Granted;
        }
    }
}
