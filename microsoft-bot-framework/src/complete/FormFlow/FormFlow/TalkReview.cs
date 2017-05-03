using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace FormFlow
{
    [Serializable]
    public class TalkReview
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public StarRating Rating { get; set; }
        public string Comments { get; set; }
        [Prompt("Is there anything I could do better?")]
        public string WhatCouldIDoBetter { get; set; }

        public static IForm<TalkReview> BuildForm()
        {
            return new FormBuilder<TalkReview>()
                .Message("Would you provide some feedback on this talk?")
                .Field(nameof(EmailAddress))
                .AddRemainingFields()
                .Build();
        }

    }

    
    
    public enum StarRating
    {
        OneStar = 1,
        TwoStars,
        ThreeStars,
        FourStars,
    }
}