using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Google.YouTube.Player;

namespace Second_Aid.Droid
{
    public abstract class YouTubeFailureRecoveryActivity : YouTubeBaseActivity, IYouTubePlayerOnInitializedListener
    {
        private static int RECOVERY_DIALOG_REQUEST = 1;
        public void OnInitializationFailure(IYouTubePlayerProvider provider, YouTubeInitializationResult errorReason)
        {
            if (errorReason.IsUserRecoverableError)
            {
                errorReason.GetErrorDialog(this, RECOVERY_DIALOG_REQUEST).Show();
            }
            else
            {
                String errorMessage = String.Format("2131034122", errorReason.ToString());
                Toast.MakeText(this, errorMessage, ToastLength.Long).Show();
            }
        }

        public virtual void OnInitializationSuccess(IYouTubePlayerProvider provider, IYouTubePlayer player, bool wasRestored)
        {
            //throw new NotImplementedException ();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            //base.OnActivityResult (requestCode, resultCode, data);
            if (requestCode == RECOVERY_DIALOG_REQUEST)
                GetYouTubePlayerProvider().Initialize(Constants.YOUTUBE_API_KEY, this);
        }

        protected abstract IYouTubePlayerProvider GetYouTubePlayerProvider();

    }
}

