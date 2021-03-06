﻿using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using UIKit;
using Demo.Core.ViewModels;
using MvvmCross.iOS.Support.SidePanels;
using Demo.iOS.Views.Base;

namespace Demo.iOS.Views
{
	[Register("ArtistView")]
	[MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ActivePanel, true)]
	public class ArtistView : BaseViewController<ArtistViewModel>
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var viewModel = this.ViewModel;

			var scrollView = new UIScrollView(View.Frame)
			{
				ShowsHorizontalScrollIndicator = false,
				AutoresizingMask = UIViewAutoresizing.FlexibleHeight
			};

			var infoButton = new UIButton();
			infoButton.SetTitle("Show Info ViewModel", UIControlState.Normal);
			infoButton.BackgroundColor = UIColor.Blue;
			scrollView.AddSubviews(infoButton);

			Add(scrollView);

			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			View.AddConstraints(
				scrollView.AtLeftOf(View),
				scrollView.AtTopOf(View),
				scrollView.WithSameWidth(View),
				scrollView.WithSameHeight(View));
			scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			var set = this.CreateBindingSet<ArtistView, ArtistViewModel>();
			set.Bind(infoButton).To("GoToInfoCommand");
			set.Apply();

			scrollView.AddConstraints(

				infoButton.Below(scrollView).Plus(10),
				infoButton.WithSameWidth(scrollView),
				infoButton.WithSameLeft(scrollView)
				);
		}

		public override void ViewWillAppear(bool animated)
		{
			Title = "Artistas";
			base.ViewWillAppear(animated);
		}
	}
}

